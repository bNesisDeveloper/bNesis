import http.client
import json
import base64

class bNesis(object):
    """description of class"""
    
    @staticmethod
    def Init( Service:str=None, bNesisToken:str=None, bNesisAPIServerURL:str=None, bNesisDeveloperId:str=None):
        """Initialize bNesis APIs server access before using services APIs
		Parameters
		----------
		Service : str
			Name of used Cloud Service
		bNesisToken : str
			bNesis Cloud Service access token
		bNesisAPIServerURL : str
			bNesis APIs server URL (use: https://server2.bnesis.com for demonstration)
		bNesisDeveloperId : str
			bNesis developer ID, visit: https://admin.bnesis.com to get here
		"""
        bNesis.Service = Service
        bNesis.bNesisToken = bNesisToken
        bNesis.bNesisAPIServerURL = bNesisAPIServerURL
        bNesis.bNesisDeveloperId = bNesisDeveloperId
    
    @staticmethod
    def Call(apiMatrix, _Service:str=None, _bNesisToken:str=None, _bNesisAPIServerURL:str=None, _bNesisDeveloperId:str=None) -> str:
        """
        Execute Cloud Service API (method Init must be called before call this method)
		Parameters
		----------
		api : 
			API execute perameters string
		_Service : str
			Name of used Cloud Service
		_bNesisToken : str
			bNesis Cloud Service access token
		_bNesisAPIServerURL : str
			bNesis APIs server URL (use: https://server2.bnesis.com for demonstration)
		_bNesisDeveloperId : str
			bNesis developer ID, visit: https://admin.bnesis.com to get here			
		Returns
		-------
		str
			API result
		"""
        if _Service is None:
            _Service = bNesis.Service	
        if _bNesisToken is None:
            _bNesisToken = bNesis.bNesisToken
        if _bNesisAPIServerURL is None:
            _bNesisAPIServerURL = bNesis.bNesisAPIServerURL
        if _bNesisDeveloperId is None:
            _bNesisDeveloperId = bNesis.bNesisDeveloperId

        result = "Bad API parameters: "
        if apiMatrix is None or not apiMatrix:
            result += "api content is empty, please set parameter 'api' value"
        elif _Service is None or not _Service:
            result += "Service content is empty, please set parameter 'Service' value"			
        elif _bNesisToken is None or not _bNesisToken:
            result += "bNesisToken content is empty, please set parameter 'bNesisToken' value"
        elif _bNesisAPIServerURL is None or not _bNesisAPIServerURL:
            result += "bNesisAPIServerURL content is empty, please set parameter 'bNesisAPIServerURL' value"
        elif _bNesisDeveloperId is None or not _bNesisDeveloperId:
            result += "bNesisDeveloperId content is empty, please set parameter 'bNesisDeveloperId' value"
        else: 
            headers = {
                "Content-type" : "application/x-www-form-urlencoded",
            }
            try :
                apiMethod = "/api/serviceclient/calljson"
                apiMatrix = apiMatrix[:1] + '"devid": "' + _bNesisDeveloperId +  '","server":"' + _bNesisAPIServerURL + '","token": "' + _bNesisToken +'",' + apiMatrix[1:]
                apiMatrixObj = json.JSONDecoder().decode(apiMatrix)
                conn = http.client.HTTPConnection(_bNesisAPIServerURL, timeout=2000)
                apiMatrix = '=' + "Base64String" + base64.b64encode(apiMatrix.encode()).decode()
                conn.request("POST", apiMethod, apiMatrix.encode('utf-8'),  headers = headers)
                response = conn.getresponse()

                print(response.status, response.reason)
                result = response.read().decode('utf-8')
                conn.close()
                return result
            except Exception as e:  
                print(Exception,":",e)
                #traceback.print_exc()
                return False 
        


