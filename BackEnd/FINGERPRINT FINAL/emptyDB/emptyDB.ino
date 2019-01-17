#include <SoftwareSerial.h>
#include <FPM.h>
SoftwareSerial mySerial(2, 3);

FPM finger;

void setup()  
{
  Serial.begin(9600);

  mySerial.begin(57600);
  
  if (finger.begin(&mySerial)) {
    Serial.println("Found Fingerprint Sensor!");
//    Serial.print("Capacity: "); Serial.println(finger.capacity);
 //   Serial.print("Packet length: "); Serial.println(finger.packetLen);
  } else {
    Serial.println("Did Not Find Fingerprint Sensor :(");
    while (1);
  }
}

void loop() {
  int p = -1;
  while (p != FINGERPRINT_OK){
    p = finger.emptyDatabase();
    if (p == FINGERPRINT_OK){
      Serial.println("Database Deleted!");
    }
    else if (p == FINGERPRINT_PACKETRECIEVEERR) {
      Serial.print("Communication error!");
    }
    else if (p == FINGERPRINT_DBCLEARFAIL) {
      Serial.println("Could not clear database!");
    }
  }
  while (1);
}
