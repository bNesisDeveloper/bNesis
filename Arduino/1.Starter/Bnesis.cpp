#include "bNesis.h"
#include "Arduino.h"
#include <ESP8266WiFi.h>
#include <string.h>
#include <cstring>

//Constructor without parameters
bNesis::bNesis() {	

Init(NULL, NULL, NULL, NULL);
}

//Constructor with parameters: Service, bNesisToken, bNesisAPIServerURL, bNesisDeveloperId
bNesis::bNesis(char* Service, char* bNesisToken, char* bNesisAPIServerURL, char* bNesisDeveloperId) {	

Init(Service, bNesisToken, bNesisAPIServerURL, bNesisDeveloperId);
}

//private void Init
void bNesis::Init(char* Service, char* bNesisToken, char* bNesisAPIServerURL, char* bNesisDeveloperId) {
	
	 this->Service = Service;
	 this->bNesisToken = bNesisToken;
	 this->bNesisAPIServerURL = bNesisAPIServerURL;
	 this->bNesisDeveloperId = bNesisDeveloperId;	
}

//method call with parameter api
char* bNesis::Call( char* api) {
	 
return Call(api, Service, bNesisToken, bNesisAPIServerURL, bNesisDeveloperId);
} 

//method call with parameter  api, _Service, _bNesisToken, _bNesisAPIServerURL, _bNesisDeveloperId
char* bNesis::Call(char* api, char* _Service, char* _bNesisToken, char* _bNesisAPIServerURL, char* _bNesisDeveloperId) {
	    
	char* dataString = CreationDataString(api, _Service, _bNesisToken, _bNesisAPIServerURL, _bNesisDeveloperId);
	
    WiFiClient client;
	const int httpPort = 80;
    
    if (!client.connect(_bNesisAPIServerURL, httpPort)) {
    Serial.println("Client connection failed");
    return "Client connection failed";
    }
		
    Serial.println("Client connection successeful");
	
	Serial.println();
	
	//http request
    client.println("POST /api/serviceclient/calljson HTTP/1.1");
    client.print("Host: ");
    client.println(_bNesisAPIServerURL);
    client.print("Content-Length: ");
    client.println(std::strlen(dataString));
	client.println("Content-Type: application/x-www-form-urlencoded");    
    client.println("User-Agent: arduino-ethernet");        
    client.println("Connection: close");
    client.println();
    client.print(dataString);
    client.println();

    Serial.print("Please, wait 30 seconds for getting responce from server");
    delay(30000);
		
	String Responce="";
	
    // Read all the lines of the reply from server
  while(client.available()){
    Responce += client.readStringUntil('\r'); 
    }
     
    Serial.println();
      
    client.stop();
    client.flush();
	
    char* ResponceCharArray = new char [Responce.length()+1];
    strcpy (ResponceCharArray, Responce.c_str());
 
    return ResponceCharArray;
}

//method creates string with data in json format for client request
char* bNesis::CreationDataString(char* api, char* _Service, char* _bNesisToken, char* _bNesisAPIServerURL, char* _bNesisDeveloperId){
	
	char* serviceString = new char[std::strlen("'service':'") + std::strlen(_Service)+3];
	std::strcpy(serviceString,"'service':'");
    std::strcat(serviceString,_Service);
	std::strcat(serviceString, "',");
	
	api++;
	
	char* dataString = new char[std::strlen("={") + std::strlen(serviceString)+std::strlen(api)+  
	std::strlen(",'token':'") + std::strlen(_bNesisToken) + std::strlen("','") +
	std::strlen("server':'") + std::strlen(_bNesisAPIServerURL) + std::strlen("','") +
	std::strlen("devid':'") + std::strlen(_bNesisDeveloperId) + std::strlen("'}") ];
	std::strcpy(dataString,"={");
    std::strcat(dataString,serviceString);
	std::strcat(dataString, api);
	
	size_t indexOfNullTerminator = strlen(dataString);
    dataString[indexOfNullTerminator - 1] = '\0';
	 
	char* tokenString = new char[std::strlen(",'token':'") + std::strlen(_bNesisToken) + std::strlen("','") + std::strlen(dataString)+1];
	std::strcpy(tokenString,",'token':'");
	std::strcat(tokenString,_bNesisToken);
	std::strcat(tokenString,"','");
	std::strcat(dataString, tokenString);
	    
	char* serverString = new char[std::strlen("server':'") + std::strlen(_bNesisAPIServerURL) + std::strlen("','") + std::strlen(dataString)+1];
	std::strcpy(serverString,"server':'");
	std::strcat(serverString,_bNesisAPIServerURL);
	std::strcat(serverString,"','");
	std::strcat(dataString, serverString);
	
	char* devIDString = new char[std::strlen("devid':'") + std::strlen(_bNesisDeveloperId) + std::strlen("'}") + std::strlen(dataString)+1];
    std::strcpy(devIDString,"devid':'");
	std::strcat(devIDString,_bNesisDeveloperId);
	std::strcat(devIDString,"'}");
	std::strcat(dataString, devIDString);
	
      for (int i = 0; i < std::strlen(dataString); i++)
        {
           if (dataString[i] == '\'') dataString[i] = '\"';	
        }
    
    dataString[std::strlen(dataString)] = '\0';
		 	
	return dataString;
	
}