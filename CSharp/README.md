# **Examples of using bNesis SDK for C# (.NET)** 

## **Introduction** 
 
**bNesis SDK for C# (.NET)** allows developers easily use cloud services authorization and API in .NET applications developed in C# programing language. 

### **Comfortable service programming with bNesis SDK**
 
The authorization is most common challenge of cloud services programing because complexity of OAuth 2.0 protocol and OpenID identity layer. Also network  programing required havening wide range of tech knowledge. The bNesis SDK represented all of it as simple well-known program elements and it makes coding process easier and more intuitive. Code examples demonstrated how to use the bNesis SDK for C# (.NET) for connection of cloud services in .NET applications and relevant guides are also provided. Any changes and updates of cloud services APIs are handled by versions of bNesis SDK for C# (.NET).  bNesis SDK for C# (.NET) significantly reduces coding time and project expenses. 

### **bNesis API layers**

bNesis SDK APIs provide an wrappers over the "low-level" of services APIs - also known as bNesis SDK API layers. There are three layers:
  
* **Unified API**. At this layer bNesis SDK APIs return to developer the response as complete data structure with fields corresponding to the original service response fields. Developer operates with data structures in  the C# programming language. Universal data structures for similar API groups are used for similar services.  Unified API is used by developers for implementing cross-service solutions, when the same program code, without changes, has to work with different services.

	
* **Formalized API**. At this layer bNesis SDK APIs return to developer the response as complete data structure with fields corresponding to the original service response fields. Developer operates with data structures in  the C# programming language. Of course, formalized API is very effective when complex data structure is waited as response. 

* **Raw API**. By using this layer of bNesis SDK APIs, developer obtain full response from service including all fields and status codes which is provided by service owners. There are two reasons for supporting API of raw layer. The first is then there is code working properly with connected service and developer want to start using of bNesis SDK. In this case developer can save his code of service responses processing i.e adopting of exiting code to bNesis SDK does not need global changes.  The second is a complete correspondence of the original documentation to the service. It is not usual and not informative but there can can be and vice versa. By the way, often responses with errors contain detailed descriptions which is useful for debug mode.   
 
### **Providing Rich and Thin clients architecture** 
  
Planing of using cloud services in .NET applications system designer determines optimal architecture depending on whether lengthy computations must be accomplished by the client or the server. bNesis SDK for C# (.NET) provides an opportunity to realize these two modes - Rich client mode and Thin client mode. At the API level, functional of Thin client mode is fully compatible with Rich client mode, the only difference is that in the case of Thin client, the OAUTH authorization takes place on the side and in the context of bNesis API Server.  
    
**Rich client mode**. In this case, bNesis SDK is delivered as a library for .NET and all the accesses to cloud services are direct:
* Middleware server is not used.
* OAUTH authentication is performed on the side of your application; 
* Multiple applications can use one installed bNesis SDK library.
* NuGet install packages and version control support is provided.
* Handlers for different services are stored in separate libraries, so you can control the size of bNesis SDK package, depending on the number of services your application uses.
     
**Advantages:** *ability to use multiple applications, independence from intermediate servers*.

**Thin client mode**. In this case, bNesis SDK is delivered as a library for .NET and works with cloud services through **bNesis API Server** provided as the server software: 
* At the API level, functional of Thin client is fully compatible with Rich client, the only difference is that in the case of Thin client, the OAUTH authorization takes place on the side and in the context of bNesis API Server. In particular, it allows you to distribute OAUTH authorization for a single account across multiple workstations.
* NuGet install packages and version control support is provided.
* In the case of changes in the cloud services API, you don't need to update your application.
* bNesis SDK Thin client is completely a cross-platform and multi-lingual solution. In this case, all the functionality is moved to bNesis API Server, only RESTful API interface is on the client side.
      
**Advantages:** *small size, cross-platform, authorization distribution*.

**bNesis API Server** is full-featured server with RESTful API interface to place on customer side. It can be used in the most convenient way for you  -  as a local office server or placed in the cloud, or on a dedicated site in the Internet.  For test use of Thin Client, you can access the bNesis Demo Server with address https://server2.bnesis.com which is fully functional analogue of bNesis API Server. So you can see the work and the benefits of a server solution, develop several test applications and only after that make a decision about purchasing bNesis API Server.

**Advantages:** *traffic control - number of connections and your servers load, safe and easy to control the sources of access and the amount of data transmitted*.
	
## **Before start** 
**bNesis Developer ID**. To use the bNesis SDK in your applications, you have to obtain the bNesis Developer ID - the key that signs your copy of the bNesis SDK. To study bNesis SDK, tests and demonstrations, you can get the key from https://api.bnesis.com site, free of charge.
	  
**Cloud services setup**. It is required to register your application in all cloud services you are planing to use. Such parameters as clientId, clientSecret, and redirectUri will be obtained from service after registration. Exact set of parameters depends of each cloud service. 
	
## **Supported services**
* **Social networks**: LinkedIn, Facebook, VKontakte
* **eCommerce**: Amazon ,BigCommerce, PrestaShop, Shopify, OpenCart   
* **Files storage**: BaiduBCS , Box, Dropbox, GoogleDrive, Mega, SugarSync
* **Analytics**: GoogleAnalytics  
* **Delivery services**: UkrPoshta
* **Payment services**: PayPal, LiqPay, Stripe
* **Government registry**: Prozorro.  
 
## **Versions** 

Current version of bNesis SDK for C# (.NET) is 1.8
 
## **CSharp Examples solution** 

This solution contain set of examples written on C# which using bNesis SDK for intagration with any services providing API. 
Examples for each service are placed in separate folder. Folder name is corresponden to name service.
In subfolders conteining examples for using APIs of service.
 
## **Installation (for .NET)** 

**Solution 1.** Install 'bNesis SDK for C# (.NET)' from 'Nuget Package Manager':
1. Open your project on which you want install bNesis SDK, then choose 'References'.
1. Press right click mouse button on 'References'.
1. Choose 'Manage Nuget Packages...'
1. In 'Nuget Package Manager' select 'Browse'.
1. Write on search line 'bNesis.Sdk'.
1. Choose bNesis.Sdk.RichClient or bNesis.Sdk.ThinClient.
1. Install selected package. (If you need install both packets repeat 6 and 7 step.)

**Solution 2.** Install 'bNesis SDK for C# (.NET)' from 'Package Manager Console':

1. Open your solution/project, choose on Visual Studio menu 'Tools > NuGet Package Manager > Package Manager Console'.

2. In 'Package Manager Console' click on 'Default Project'.

3. Select your project on which you want install bNesis SDK.

4. After 'PM>' write one of command:

  Install Rich Client command: Install-Package bNesis.Sdk.RichClient
   
  Install Thin Client command: Install-Package bNesis.Sdk.ThinClient                 

  **Example**: 
  ```
  PM> Install-Package bNesis.Sdk.RichClient
  PM> Install-Package bNesis.Sdk.ThinClient  			  
  ``` 

5. Run it (Press Enter). (If you need install both packets repeat 4 and 5 step.)

**Solution 3.** get bNesis SDK for C# (.NET) in Source Code from GitHub:
1. Download bNesis SDK from https://github.com/bNesisDeveloper/bNesis/tree/master/Sdk/DotNet
1. Build the source code at Visual Studio 2015-2017.
1. Add references for your application to bNesis SDK library.


## **Using** 

1. If you use Thin Client mode, you need access to bNesis API Server. Address of the demo bNesis API server https://server2.bnesis.com
2. To use the bNesis SDK in your applications, you must have the bNesis Developer ID - the key that signs your copy of the bNesis SDK. To study bNesis SDK, tests and demonstrations, you can get the key from https://api.bnesis.com site, free of charge.
3. The bNesis SDK developers offer you to adhere to the following sequence of API usage:
 
    3.1 Connect bNesis SDK modules to your application.
 
    3.2 Use the bNesis SDK ServiceManager class to initialize clients of different modes:     
 
    The InitializeRich method for RichClient
     
    The InitializeThin method for RichThin

    3.3 After initialization, you must select the service with which you plan to work at your application and implement your application authorization procedure for the selected service using ServiceManager.CreateInstance method. You also need to specify bNesis Developer Id in this method parameter.
 
    3.4 After successful authorization, your application accesses the resources of your chosen service through the methods of the Instance class.(access to the service API).

		 
The life cycle of an application using the bNesis SDK can be represented in three simple steps:

*Step 1*. bNesis > Initialize (Rich client or Thin client)

*Step 2*. bNesis > Auth (bNesis Developer Id, clientId, clientSecret, redirectUri)
    
*Step 3*. bNesis > Call service API # 1
    
*Step 4*. bNesis > Call service API # 2  
    
*Step N*. bNesis > Call service API #M 

 
## **Contacts**

For public https://bnesis.com

For developers https://api.bnesis.com 