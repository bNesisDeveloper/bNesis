class bNesis {
  public:
   bNesis();
   bNesis(char* Service, char* bNesisToken, char* bNesisAPIServerURL, char* bNesisDeveloperId);
   char* Call(char* api);
   char* Call(char* api, char* _Service, char* _bNesisToken, char* _bNesisAPIServerURL, char* _bNesisDeveloperId);
 

 private:
    char* CreationDataString(char* api, char* _Service, char* _bNesisToken, char* _bNesisAPIServerURL, char* _bNesisDeveloperId);
    char* Service;
    char* bNesisToken;
    char* bNesisAPIServerURL;
    char* bNesisDeveloperId;
	char* api;
	void Init(char* Service, char* bNesisToken, char* bNesisAPIServerURL, char* bNesisDeveloperId);
	//char* Responce;

};
 