<?php

class Bnesis
{
    private static $service = null;

    public static $bNesisToken = null;

    public static $bNesisAPIServerURL = null;

    public static $bNesisDeveloperId = null;

    # Initialize bNesis APIs server access before using services APIs
    # <param name="$serviceInput">Name of used Cloud Service</param>
    #<param name="$bNesisTokenInput">bNesis Cloud Service access token</param>
    #<param name="$bNesisAPIServerURLInput">bNesis APIs server URL (use: https://server2.bnesis.com for demonstration)</param>
    # <param name="$bNesisDeveloperIdInput">bNesis developer ID, visit: https://admin.bnesis.com to get here</param>
    public static function Init($bNesisAPIServerURLInput, $bNesisTokenInput, $serviceInput, $bNesisDeveloperIdInput)
    {
        self::$service = $serviceInput;
        self::$bNesisToken = $bNesisTokenInput;
        self::$bNesisAPIServerURL = $bNesisAPIServerURLInput;
        self::$bNesisDeveloperId = $bNesisDeveloperIdInput;
    }


    # Execute Cloud Service API
    # <param name="$apiMatrix">API execute perameters string</param>
    # <param name="$serviceInput">Name of used Cloud Service</param>
    # <param name="$bNesisTokenInput">bNesis Cloud Service access token</param>
    # <param name="$bNesisAPIServerURLInput">bNesis APIs server URL (use: https://server2.bnesis.com for demonstration)</param>
    # <param name="$bNesisDeveloperIdInput">bNesis developer ID, visit: https://admin.bnesis.com to get here</param>
    # <returns>API result</returns>
    public static function Call($apiMatrix, $bNesisAPIServerURLInput = null, $bNesisTokenInput = null, $serviceInput = null, $bNesisDeveloperIdInput = null)
    {

        $result = "Bad API parameters: ";
        try {
            if (!isset($apiMatrix)) {
                $result .= "api content is empty, please set parameter 'api' value";
            } else
                if (!isset(self::$service) && !isset($serviceInput)) {
                    $result .= "Service content is empty, please set parameter 'Service' value";
                } else

                    if (!isset(self::$bNesisToken) && !isset($bNesisTokenInput)) {
                        $result .= "bNesisToken content is empty, please set parameter 'bNesisToken' value";
                    } else

                        if (!isset(self::$bNesisAPIServerURL) && !isset($bNesisAPIServerURLInput)) {
                            $result .= "bNesisAPIServerURL content is empty, please set parameter 'bNesisAPIServerURL' value";
                        } else

                            if (!isset(self::$bNesisDeveloperId) && !isset($bNesisDeveloperIdInput)) {
                                $result .= "bNesisDeveloperId content is empty, please set parameter 'bNesisDeveloperId' value";
                            } else {
                                self::$service = isset($serviceInput) ? $serviceInput : self::$service;
                                self::$bNesisToken = isset($bNesisTokenInput) ? $bNesisTokenInput : self::$bNesisToken;
                                self::$bNesisAPIServerURL = isset($bNesisAPIServerURLInput) ? $bNesisAPIServerURLInput : self::$bNesisAPIServerURL;
                                self::$bNesisDeveloperId = isset($bNesisDeveloperIdInput) ? $bNesisDeveloperIdInput : self::$bNesisDeveloperId;
                                $apiMatrix = substr($apiMatrix, 1, strlen($apiMatrix) - 2);
                                #Create full API Matrix
                                $apiMatrix = '={"devid":"' . self::$bNesisDeveloperId . '","token":"' . self::$bNesisToken . '","server":"' . self::$bNesisAPIServerURL . '","service":"' . self::$service . '",' . $apiMatrix . '}';
                                //echo "apiMatrix : " . $apiMatrix . "<br><br>";
                                #Create Server URL for execute API Matrix
                                self::$bNesisAPIServerURL = self::$bNesisAPIServerURL . 'api/serviceclient/calljson';
                                //echo "bNesisAPIServerURL : ".self::$bNesisAPIServerURL  . "<br><br>";
                                #Initialization Curl
                                $curl = curl_init();
                                curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
                                curl_setopt($curl, CURLOPT_URL, self::$bNesisAPIServerURL);
                                curl_setopt($curl, CURLOPT_POST, 1);
                                curl_setopt($curl, CURLOPT_POSTFIELDS, $apiMatrix);
                                curl_setopt($curl, CURLOPT_HTTPHEADER, array('Content-Type: application/x-www-form-urlencoded'));
                                curl_setopt($curl, CURLOPT_SSL_VERIFYPEER, 0);
                                curl_setopt($curl, CURLOPT_SSL_VERIFYHOST, 0);
                                #Execute request to the service
                                $result = curl_exec($curl);
                                //echo "result4 : " . $result . "<br><br>";
                                if (!isset($result) || $result == 'null')
                                    $result = "The service return empty result, it maybe you need REFRESH bNesis Token for access to this service, cose token live time is end";
                                $code = curl_getinfo($curl, CURLINFO_HTTP_CODE);
                                if ($code != 200)
                                    $result = "bNesis API server response, API call not success, HTTP Status code: " . $code;

                                return $result;
                            }

        } catch (Exception $e) {
            $result = "bNesis API Server or API parameters problem (please check your service access bNesis token first): " . $e->getMessage();
        }
        return $result;
    }

}