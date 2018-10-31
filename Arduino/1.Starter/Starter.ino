#include <Bnesis.h>
#include <ESP8266WiFi.h>

//Network name
const char* ssid     = "Stix";
//Password for the network
const char* password = "SETDOMA1";

void setup() {  

  //Speed of the prot
  Serial.begin(115200);
  delay(100);
    
  Serial.println();
  Serial.println();
  Serial.print("Connecting to router ");
  Serial.println(ssid);
  
  // Set WiFi to station mode and disconnect from an AP if it was previously connected
  WiFi.mode(WIFI_STA);
  WiFi.disconnect();
  WiFi.begin(ssid, password);

  delay(500);

  //Checking of the connection status 
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");  
  }
    Serial.println();
    Serial.println("Wi-Fi connected");

// Get token, server and developer id here:
//http://socialpilot.bnesis.com/Data/TokenReceiver?adminId=28
    
//Data with name of api and parameters in json
char* api = "{'api':'GetFullList','parameters':null}";

//Data with name of api and parameters in json
char* api2 = "{'api':'GetFullSize','parameters':null}";

//Service
char* Service = "GoogleDrive";

//bNesis Token
char* bNesisToken = "eVdhWElXR3NxT3psMG05ZnN3ckdodjliNWJ4VGdLUEUya0grK3R6VE9iU25md2VLTjliTWhZNzZXb0VzUllDY01tTHNubWY4dkRpTFpDamVoeGZMVUpSNm5HL3YyYkVpTTJFVlpmQndSUUhYL0dPQ0s2KzBoZWVZS3FCSHpBTm41SGsyZUlFV3JFREpVR1Q0TlB4WkJ4SHlXMFMyb3YvcHNXQ0lmV2VLWnB3RXF5eHJUMDR2YUJjVko3ZDZQSVJOTzIzNkNTWGRkZ2tSMzJ6Sm1PRGxjUkxwcDdjZmlCVENORjNuL0xpNEFYQmZZWDc1U3czRjJrNHVkQ2JLVTM5cA";

//bNesis server for getting data
char* bNesisAPIServerURL = "server2.bnesis.com";

//bNesis developer id
char* bNesisDeveloperId = "LtyTYPBW9Zca01mUBZy+YhAvHiw93/lcDOZGyqy/l/5ROWASzNCF6kzrm/kiUdqf3G+cZOy8r2OyVmk5s/mSnw==";

//First example

//Constructor with parameters: Service, bNesisToken, bNesisAPIServerURL, bNesisDeveloperId.
bNesis bNesisCaller (Service, bNesisToken, bNesisAPIServerURL, bNesisDeveloperId);

//Getting data using method call with one parameter
char* Response = bNesisCaller.Call(api);

//Print response from bNesis server
Serial.println();
Serial.println("Response 1: ");
Serial.println(Response);
Serial.println();

//Secont example

//Constructor without parameters
bNesis bNesisCaller2;

//Getting data using method call with parameters: Service, bNesisToken, bNesisAPIServerURL, bNesisDeveloperId.
char* Response2 = bNesisCaller2.Call(api2, Service,bNesisToken, bNesisAPIServerURL, bNesisDeveloperId);

//Print response from bNesis server
Serial.println();
Serial.println("Response 2: ");
Serial.println(Response2);
Serial.println();
}

void loop() {
  

}
