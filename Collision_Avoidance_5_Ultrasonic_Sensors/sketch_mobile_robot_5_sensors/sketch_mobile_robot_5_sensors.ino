// File: sketch_mobile_robot_5_sensors.ino
// Description: Intelligent Mobile Robot - Collision Avoidance
// Environment: Arduino IDE
//
// MIT License
// Copyright (c) 2018 Valentyn N Sichkar
// github.com/sichkar-valentyn
// Reference to:
// [1] Valentyn N Sichkar. Intelligent Navigation System of Mobile Robot // GitHub platform [Electronic resource]. URL: https://github.com/sichkar-valentyn/Intelligent_Mobile_Robot (date of access: XX.XX.XXXX)


// Variables for Trig and Echo of Ultrasonic Sensors
int trigPin_1 = 17;
int echoPin_1 = 16;
int trigPin_2 = 21;
int echoPin_2 = 20;
int trigPin_3 = 45;
int echoPin_3 = 44;
int trigPin_4 = 47;
int echoPin_4 = 46;
int trigPin_5 = 23;
int echoPin_5 = 22;

// Variables for reading data from Ultrasonic Sensors
int cm_1;
int cm_2;
int cm_3;
int cm_4;
int cm_5;
int duration;

// Variables for controlling the directions
int D1 = 12;
int D2 = 13;

// Variables for controlling the speed
int S1 = 10;
int S2 = 11;

// Variables for speed
int i_forward = 0;
int i_back = 0;

// Variable for inputs from Serial Port
char Char = 0;

// Setup code to run once
void setup() {
  // Setting the Pins we are going to work with as an OUTPUT and INPUT
  pinMode(echoPin_1, INPUT); 
  pinMode(trigPin_1, OUTPUT);
  pinMode(echoPin_2, INPUT); 
  pinMode(trigPin_2, OUTPUT);
  pinMode(echoPin_3, INPUT); 
  pinMode(trigPin_3, OUTPUT);
  pinMode(echoPin_4, INPUT); 
  pinMode(trigPin_4, OUTPUT);
  pinMode(echoPin_5, INPUT); 
  pinMode(trigPin_5, OUTPUT);
  
  pinMode(D1, OUTPUT);
  pinMode(D2, OUTPUT);
  pinMode(S1, OUTPUT);
  pinMode(S2, OUTPUT);

  // Setting the data rate  
  Serial.begin(9600);
}

// Main code to run repeatedly
void loop() {

  // First Ultrasonic Sensor
  digitalWrite(trigPin_1, LOW); // Ultrasonic Sensor doesn't send signal. Giving a LOW pulse beforehand to ensure a clean HIGH pulse.
  delay(20); // Setting delay 0,02 seconds
  digitalWrite(trigPin_1, HIGH); // Sending signal
  delayMicroseconds(500); // Setting delay 0,0005 seconds
  digitalWrite(trigPin_1, LOW); // Switching off sending signal
  duration = pulseIn(echoPin_1, HIGH); // Switching on getting signal
  cm_1 = duration / 58; // Calculating the distance in cm

  // Second Ultrasonic Sensor
  digitalWrite(trigPin_2, LOW); // Ultrasonic Sensor doesn't send signal. Giving a LOW pulse beforehand to ensure a clean HIGH pulse.
  delay(20); // Setting delay 0,02 seconds
  digitalWrite(trigPin_2, HIGH); // Sending signal
  delayMicroseconds(500); // Setting delay 0,0005 seconds
  digitalWrite(trigPin_2, LOW); // Switching off sending signal
  duration = pulseIn(echoPin_2, HIGH); // Switching on getting signal
  cm_2 = duration / 58; // Calculating the distance in cm

  // Third Ultrasonic Sensor
  digitalWrite(trigPin_3, LOW); // Ultrasonic Sensor doesn't send signal. Giving a LOW pulse beforehand to ensure a clean HIGH pulse.
  delay(20); // Setting delay 0,02 seconds
  digitalWrite(trigPin_3, HIGH); // Sending signal
  delayMicroseconds(500); // Setting delay 0,0005 seconds
  digitalWrite(trigPin_3, LOW); // Switching off sending signal
  duration = pulseIn(echoPin_3, HIGH); // Switching on getting signal
  cm_3 = duration / 58; // Calculating the distance in cm

  // Fourth Ultrasonic Sensor
  digitalWrite(trigPin_4, LOW); // Ultrasonic Sensor doesn't send signal. Giving a LOW pulse beforehand to ensure a clean HIGH pulse.
  delay(20); // Setting delay 0,02 seconds
  digitalWrite(trigPin_4, HIGH); // Sending signal
  delayMicroseconds(500); // Setting delay 0,0005 seconds
  digitalWrite(trigPin_4, LOW); // Switching off sending signal
  duration = pulseIn(echoPin_4, HIGH); // Switching on getting signal
  cm_4 = duration / 58; // Calculating the distance in cm

  // Fifth Ultrasonic Sensor
  digitalWrite(trigPin_5, LOW); // Ultrasonic Sensor doesn't send signal. Giving a LOW pulse beforehand to ensure a clean HIGH pulse.
  delay(20); // Setting delay 0,02 seconds
  digitalWrite(trigPin_5, HIGH); // Sending signal
  delayMicroseconds(500); // Setting delay 0,0005 seconds
  digitalWrite(trigPin_5, LOW); // Switching off sending signal
  duration = pulseIn(echoPin_5, HIGH); // Switching on getting signal
  cm_5 = duration / 58; // Calculating the distance in cm

  // Checking the distance for Alarm and make the mobile robot stop if the distance is critical
  if(cm_1 > 0 && cm_1 < 30) {
    if(i_forward > 0) { digitalWrite(D1, LOW); digitalWrite(D2, HIGH); analogWrite(S1, i_forward); analogWrite(S2, i_forward); delay(200); analogWrite(S1, 0); analogWrite(S2, 0); }
    if(i_back > 0) { digitalWrite(D1, HIGH); digitalWrite(D2, LOW); analogWrite(S1, i_back); analogWrite(S2, i_back); delay(200); analogWrite(S1, 0); analogWrite(S2, 0); }
    i_forward = 0; i_back = 0;
  }
  if(cm_2 > 0 && cm_2 < 30) {
    if(i_forward > 0) { digitalWrite(D1, LOW); digitalWrite(D2, HIGH); analogWrite(S1, i_forward); analogWrite(S2, i_forward); delay(200); analogWrite(S1, 0); analogWrite(S2, 0); }
    if(i_back > 0) { digitalWrite(D1, HIGH); digitalWrite(D2, LOW); analogWrite(S1, i_back); analogWrite(S2, i_back); delay(200); analogWrite(S1, 0); analogWrite(S2, 0); }
    i_forward = 0; i_back = 0;
  }
  if(cm_3 > 0 && cm_3 < 30) {
    if(i_forward > 0) { digitalWrite(D1, LOW); digitalWrite(D2, HIGH); analogWrite(S1, i_forward); analogWrite(S2, i_forward); delay(200); analogWrite(S1, 0); analogWrite(S2, 0); }
    if(i_back > 0) { digitalWrite(D1, HIGH); digitalWrite(D2, LOW); analogWrite(S1, i_back); analogWrite(S2, i_back); delay(200); analogWrite(S1, 0); analogWrite(S2, 0); }
    i_forward = 0; i_back = 0;
  }
  if(cm_4 > 0 && cm_4 < 30) {
    if(i_forward > 0) { digitalWrite(D1, LOW); digitalWrite(D2, HIGH); analogWrite(S1, i_forward); analogWrite(S2, i_forward); delay(200); analogWrite(S1, 0); analogWrite(S2, 0); }
    if(i_back > 0) { digitalWrite(D1, HIGH); digitalWrite(D2, LOW); analogWrite(S1, i_back); analogWrite(S2, i_back); delay(200); analogWrite(S1, 0); analogWrite(S2, 0); }
    i_forward = 0; i_back = 0;
  }
  if(cm_5 > 0 && cm_5 < 30) {
    if(i_forward > 0) { digitalWrite(D1, LOW); digitalWrite(D2, HIGH); analogWrite(S1, i_forward); analogWrite(S2, i_forward); delay(200); analogWrite(S1, 0); analogWrite(S2, 0); }
    if(i_back > 0) { digitalWrite(D1, HIGH); digitalWrite(D2, LOW); analogWrite(S1, i_back); analogWrite(S2, i_back); delay(200); analogWrite(S1, 0); analogWrite(S2, 0); }
    i_forward = 0; i_back = 0;
  }
 
  // Reading the input
  Char = Serial.read();

  // Checking the input and implementing the command - FORWARD
  if(Char == '1') { 
    
    // Checking if Mobile Robot is moving back
    if(i_back > 0) { i_back = 0; analogWrite(S1, 0); analogWrite(S2, 0);}
    
    // Setting the direction to forward
    digitalWrite(D1, HIGH);
    digitalWrite(D2, LOW);

    // Setting the speed
    if(i_forward <= 80) { i_forward = 80; }
    if(i_forward <= 185) { i_forward = i_forward + 15; }
    if(i_forward > 200) { i_forward = 250; }
    analogWrite(S1, i_forward);
    analogWrite(S2, i_forward);      
  }

  // Checking the input and implementing the command - BACK
  if(Char == '2') { 

    // Checking if Mobile Robot is moving forward
    if(i_forward > 0) { i_forward = 0; analogWrite(S1, 0); analogWrite(S2, 0);}

    // Setting the direction to back
    digitalWrite(D1, LOW);
    digitalWrite(D2, HIGH);

    // Setting the speed
    if(i_back <= 80) { i_back = 80; }
    if(i_back <= 185) { i_back = i_back + 15; }
    if(i_back > 200) { i_back = 250; }
    analogWrite(S1, i_back);
    analogWrite(S2, i_back);
  }

  // Checking the input and implementing the command - STOP
  if(Char == '0') {
    i_forward = 0;
    i_back = 0;
    analogWrite(S1, 0);
    analogWrite(S2, 0);
  }

  // Checking the input and implementing the command - LEFT
  if(Char == '3') {
     
    // Setting the direction to left-forward while standing still
    if(i_forward == 0 && i_back == 0) {
      digitalWrite(D1, HIGH);
      digitalWrite(D2, HIGH);
      
      // Setting the speed
      analogWrite(S1, 250);
      analogWrite(S2, 250);
      delay(400);
      analogWrite(S1, 0);
      analogWrite(S2, 0);
    }

    // Setting the direction to left-forward while moving
    if(i_forward > 0 && i_back == 0) {
      analogWrite(S1, i_forward + 50);
      analogWrite(S2, 0);
      delay(300);
      analogWrite(S1, i_forward);
      analogWrite(S2, i_forward);
    }

    // Setting the direction to left-back while moving
    if(i_back > 0 && i_forward == 0) {
      analogWrite(S1, 0);
      analogWrite(S2, i_back + 50);
      delay(300);
      analogWrite(S1, i_back);
      analogWrite(S2, i_back);
    }
  }

  // Checking the input and implementing the command - RIGHT
  if(Char == '4') {
     
    // Setting the direction to right-forward while standing still
    if(i_forward == 0 && i_back == 0) {
      digitalWrite(D1, LOW);
      digitalWrite(D2, LOW);
      
      // Setting the speed
      analogWrite(S1, 250);
      analogWrite(S2, 250);
      delay(400);
      analogWrite(S1, 0);
      analogWrite(S2, 0);
    }

    // Setting the direction to right-forward while moving
    if(i_forward > 0 && i_back == 0) {
      analogWrite(S1, 0);
      analogWrite(S2, i_forward + 50);
      delay(300);
      analogWrite(S1, i_forward);
      analogWrite(S2, i_forward);
    }

    // Setting the direction to right-back while moving
    if(i_back > 0 && i_forward == 0) {
      analogWrite(S1, i_back + 50);
      analogWrite(S2, 0);
      delay(300);
      analogWrite(S1, i_back);
      analogWrite(S2, i_back);
    }
  }

// Sending the string with data from Ultrasonic Sensors to Serial Port
Serial.print(cm_1);
Serial.print("_");
Serial.print(cm_2);
Serial.print("_");
Serial.print(cm_3);
Serial.print("_");
Serial.print(cm_4);
Serial.print("_");
Serial.println(cm_5);

}



