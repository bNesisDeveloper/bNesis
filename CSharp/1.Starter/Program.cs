using System;

namespace Starter
{
    /// <summary>
    /// This is simple example how to using bNesis SDK to get the list and size of all Google Drive files. 
    /// To use this example, you need to get Google Drive access token, for do this: 
    ///  - go to link and choose the Google Drive service http://socialpilot.bnesis.com/Data/TokenReceiver?adminId=28
    ///  - copy the token into this example source code.    
    /// Please note: life time of Google Drive access token 1 hour.    
    /// </summary>
    class Program
    {
        static string Service = "GoogleDrive";
        //PLEASE PAY ATTENTION HERE: Your bNesis Google Drive access token here
        static string bNesisToken = "Put your bNesis Google Drive access token here"; //to get token visit here: http://socialpilot.bnesis.com/Data/TokenReceiver?adminId=28               
        //Address of the demo bNesis APIs server
        static string bNesisAPIServerURL = "https://server2.bnesis.com/";
        //To use the bNesis SDK in your applications, you must have the bNesis Developer ID - the key that signs your copy of the bNesis SDK.
        static string bNesisDeveloperId = "LtyTYPBW9Zca01mUBZy+YhAvHiw93/lcDOZGyqy/l/5ROWASzNCF6kzrm/kiUdqf3G+cZOy8r2OyVmk5s/mSnw==";
        //bNesis parameter for get list of all Google Drive files
        static string GetFullListAPI = "{'api':'GetFullList','parameters':null}";
        //bNesis parameter for get count and size of all Google Drive files
        static string GetFullSizeAPI = "{'api':'GetFullSize','parameters':null}";
        
        static void Main(string[] args)
        {            
            //Using bNesis Init method to connect to bNesis APIs server 
            bNesis.Init(Service, bNesisToken, bNesisAPIServerURL, bNesisDeveloperId);            
            //Call (execute) GetFullList from bNesis APIs server
            string result = bNesis.Call(GetFullListAPI);            
            Console.WriteLine(result);
            //(execute) GetFullSize from bNesis APIs server without using Init method
            result = bNesis.Call(GetFullSizeAPI, Service, bNesisToken, bNesisAPIServerURL, bNesisDeveloperId);            
            Console.WriteLine(result);
            //waiting for user press Enter key
            Console.ReadLine();
        }
    }
}
