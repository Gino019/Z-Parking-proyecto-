/*
  PROYECTO FINAL - ESTACIONAMIENTO TACNA
  - Funcionalidad: Servo (Barrera), Servo (Techo Inteligente), Sensores IR, LCD, Buzzer
  - Lógica: Control de Lluvia con temporizador de 10 segundos.
*/

#include <Wire.h> 
#include <LiquidCrystal_I2C.h> 
#include <Servo.h> 

// --- PANTALLA LCD ---
// Dirección 0x27 es la estándar. Si no enciende, prueba 0x3F.
LiquidCrystal_I2C lcd(0x27, 16, 2);  

// --- PINES Y VARIABLES GLOBALES ---
const int SENSOR_PINES[5] = { 2, 3, 4, 5, 6 }; 
int estadoEspacios[5] = { 0, 0, 0, 0, 0 }; 

const int PIN_LLUVIA = A0; 
const int PIN_HUMO = A1;   
const int PIN_BARRERA_ENTRADA = 9;  
const int PIN_ALARMA_HUMO = 10;     
const int PIN_TECHO_SERVO = 11; // Usamos PIN 11 para el servo del techo

bool lluviaDetectada = false;
bool humoDetectado = false;
Servo barreraServo; 
Servo techoServo; 

// --- VARIABLES DEL TEMPORIZADOR (TECHO INTELIGENTE) ---
unsigned long tiempoLluviaDetenida = 0; // Guarda el millis() cuando deja de llover
const long INTERVALO_APERTURA = 10000; // 10 segundos
bool techoAbierto = true; 
int contadorFuego = 0; // Para filtro anti-ruido

// ----------------------------------------------------
// 1. FUNCIONES AUXILIARES (MOVIDAS AL INICIO)
// ----------------------------------------------------

void mostrarMensajeLCD(String linea1, String linea2) {
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print(linea1);
  lcd.setCursor(0,1);
  lcd.print(linea2);
}

void mostrarDefaultLCD() {
  lcd.setCursor(0,0);
  lcd.print(" ESTACIONAMIENTO");
  lcd.setCursor(0,1);
  lcd.print("   DISPONIBLE   ");
}

// ----------------------------------------------------
// 2. SETUP Y LOOP (El Cerebro Principal)
// ----------------------------------------------------

void setup() {
  Serial.begin(9600); 
  
  // Servos
  barreraServo.attach(PIN_BARRERA_ENTRADA);
  techoServo.attach(PIN_TECHO_SERVO); 
  
  barreraServo.write(0);  // Barrera Cerrada (0°)
  techoServo.write(90);   // Techo Abierto al inicio (90°)
  techoAbierto = true;

  // Pines (Inicializados igual)
  for (int i = 0; i < 5; i++) { 
    pinMode(SENSOR_PINES[i], INPUT);
  }
  pinMode(PIN_LLUVIA, INPUT);
  pinMode(PIN_HUMO, INPUT);
  pinMode(PIN_ALARMA_HUMO, OUTPUT);

  // LCD
  lcd.init();
  lcd.backlight();
  mostrarMensajeLCD(" ESTACIONAMIENTO", "   TACNA   ");
  delay(2000);
  mostrarDefaultLCD(); // 👈 Ahora el compilador ya la conoce
}

void loop() {
  if (Serial.available() > 0) {
    procesarComandoCsharp();
  }
  
  revisarEspacios();
  revisarAlertas(); 
  
  delay(100); 
}

// ----------------------------------------------------
// 3. FUNCIONES DE LÓGICA
// ----------------------------------------------------

void procesarComandoCsharp() {
  String cmd = Serial.readStringUntil('\n'); 
  cmd.trim(); 
  
  // BARRERA DE ENTRADA
  if (cmd.equals("ABRIR_ENTRADA")) {
    mostrarMensajeLCD("REGISTRO EXITOSO", "   BIENVENIDO   ");
    barreraServo.write(90); 
    delay(3000);
    barreraServo.write(0);
    mostrarDefaultLCD();
  }
  
  // COMANDO DE SALIDA (Abre la barrera para que el vehículo salga)
  if (cmd.equals("SALIDA")) { 
    mostrarMensajeLCD("  GRACIAS POR   ", "   SU VISITA    ");
    barreraServo.write(90); 
    delay(3000);
    barreraServo.write(0);  
    mostrarDefaultLCD();
  }
}

void revisarEspacios() {
  // ... (Lógica de revisión de espacios igual) ...
  for (int i = 0; i < 5; i++) { 
    int lecturaSensor = digitalRead(SENSOR_PINES[i]); 
    int estadoLogico = (lecturaSensor == LOW) ? 1 : 0; // Lógica Inversa
    
    if (estadoLogico != estadoEspacios[i]) {
      estadoEspacios[i] = estadoLogico; 
      Serial.print("ESPACIO:");
      Serial.print(i + 1); 
      Serial.print(":");
      Serial.println(estadoLogico); 
      
      if(estadoLogico == 1) {
         lcd.setCursor(0,0);
         lcd.print("AUTO EN ESPACIO ");
         lcd.print(i + 1);
         delay(1000); 
         mostrarDefaultLCD();
      }
    }
  }
}

void revisarAlertas() {
  // --- LLUVIA Y CONTROL DE TECHO ---
  int sensorLluvia = digitalRead(PIN_LLUVIA); 
  
  // PARTE 1: CUANDO EMPIEZA A LLOVER (sensor = 0)
  if (sensorLluvia == 0 && !lluviaDetectada) { 
    lluviaDetectada = true;
    
    // Cierra el techo
    techoServo.write(0); // Posición 0 grados (CERRADO)
    techoAbierto = false;
    
    Serial.println("ALERTA_LLUVIA:1");
    mostrarMensajeLCD("   LLUVIA!!!    ", " CERRANDO TECHO ");
    tiempoLluviaDetenida = 0; 
  } 
  
  // PARTE 2: CUANDO LA LLUVIA SE DETIENE (sensor = 1)
  else if (sensorLluvia == 1 && lluviaDetectada) {
    lluviaDetectada = false;
    Serial.println("ALERTA_LLUVIA:0");
    
    // 🔔 INICIA EL TEMPORIZADOR DE 10 SEGUNDOS
    tiempoLluviaDetenida = millis(); 
    mostrarMensajeLCD("LLUVIA STOPPED", " ESPERANDO 10s ");
  }
  
  // PARTE 3: GESTIÓN DEL TEMPORIZADOR
  if (!lluviaDetectada && techoAbierto == false && tiempoLluviaDetenida != 0) {
    
    if (millis() - tiempoLluviaDetenida >= INTERVALO_APERTURA) {
      
      // Abre el techo
      techoServo.write(90); // Posición 90 grados (ABIERTO)
      techoAbierto = true;
      
      tiempoLluviaDetenida = 0; 
      
      mostrarDefaultLCD();
    }
  }

  // --- FUEGO / HUMO (Lógica de Filtro igual) ---
  int sensorHumo = digitalRead(PIN_HUMO); 
  
  if (sensorHumo == HIGH) { 
      contadorFuego++;
  } else {
      contadorFuego = 0;
  }

  if (contadorFuego > 2 && !humoDetectado) { 
    humoDetectado = true;
    Serial.println("ALERTA_HUMO:1");
    digitalWrite(PIN_ALARMA_HUMO, HIGH); 
    mostrarMensajeLCD("!!! PELIGRO !!!", " FUEGO DETECTADO");
  } 
  else if (contadorFuego == 0 && humoDetectado) { 
    humoDetectado = false;
    Serial.println("ALERTA_HUMO:0");
    digitalWrite(PIN_ALARMA_HUMO, LOW); 
    mostrarDefaultLCD();
  }
}