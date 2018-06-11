
**bNesis** allows developers easily use cloud services authorization and API at Web, mobile and desktop applications.

 --------------------------------------------------------------------------------

## **Comfortable service programming with bNesis**
 
The authorization is most common challenge of cloud services programing because complexity of OAuth 2.0 protocol and OpenID identity layer. Also network  programing required havening wide range of tech knowledge. The bNesis SDK represented all of it as simple well-known program elements and it makes coding process easier and more intuitive. Code examples demonstrated how to use the bNesis SDK for C# (.NET) for connection of cloud services in .NET applications and relevant guides are also provided. Any changes and updates of cloud services APIs are handled by versions of bNesis SDK for C# (.NET).  bNesis SDK for C# (.NET) significantly reduces coding time and project expenses. 

## **bNesis API layers**

bNesis SDK APIs provide an wrappers over the "low-level" of services APIs - also known as bNesis SDK API layers. There are three layers:
  
* **Unified API**. At this layer bNesis SDK APIs return to developer the response as complete data structure with fields corresponding to the original service response fields. Developer operates with data structures in  the C# programming language. Universal data structures for similar API groups are used for similar services.  Unified API is used by developers for implementing cross-service solutions, when the same program code, without changes, has to work with different services.

	
* **Formalized API**. At this layer bNesis SDK APIs return to developer the response as complete data structure with fields corresponding to the original service response fields. Developer operates with data structures in  the C# programming language. Of course, formalized API is very effective when complex data structure is waited as response. 

* **Raw API**. By using this layer of bNesis SDK APIs, developer obtain full response from service including all fields and status codes which is provided by service owners. There are two reasons for supporting API of raw layer. The first is then there is code working properly with connected service and developer want to start using of bNesis SDK. In this case developer can save his code of service responses processing i.e adopting of exiting code to bNesis SDK does not need global changes.  The second is a complete correspondence of the original documentation to the service. It is not usual and not informative but there can can be and vice versa. By the way, often responses with errors contain detailed descriptions which is useful for debug mode.   
 
## **Providing Rich and Thin clients architecture** 
  
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

--------------------------------------------------------------------------------

## **Before start** 
**bNesis Developer ID**. To use the bNesis SDK in your applications, you have to obtain the bNesis Developer ID - the key that signs your copy of the bNesis SDK. To study bNesis SDK, tests and demonstrations, you can get the key after registration, free of charge.
	  
**Cloud services setup**. It is required to register your application in all cloud services you are planing to use. Such parameters as clientId, clientSecret, and redirectUri will be obtained from service after registration. Exact set of parameters depends of each cloud service. 
	
 --------------------------------------------------------------------------------

## **First step**
A tool that visualizes the work with **services API Caller**.

Specially developed online software that represents work with services in the form of a graphical userinterface (UI). All APIs of all services supported by bNesis are available for use. There is no need to immediately start programming using the bNesis SDK in order to learn its capabilities. Or if you follow the goal to explore the capabilities of the services - what data the service calls and what parameters are required for this, does not need to investigate the service documentation or is engaged in programming.

We have developed a special demonstration service that explains the work of bNesis step by step. This service is completely free and includes learning examples, from the simplest, to the more complex ones. For example, you can find out the weather in London or get NASA information - using calls to relevant services  
  
**[Try API Caller demonstration right now](~/Api/Caller?instanceId=8f14e45fceea167a5a36dedd4bea2543&Service=DemoService)**

--------------------------------------------------------------------------------

## **bNesis account**
Create your own account.

We suggest you create your own account to manage the services you need. This account is purely demonstrative - to explore the capabilities of the bNesis SDK and bNesis API Servers. bNesis account allows you to get bNesis developer ID and use bNesis SDK (Rich and Thin varints), absolutely free of charge in the introductory order.  
  
**[Create bNesis account](~/Account/Login#signup)**

--------------------------------------------------------------------------------

## **bNesis API help**
Services APIs helpdocumentation about all supported services APIs and data types.Includes a full description of all supported services and their APIs. The information is presented in sections. Also, bNesis implements so-called unified APIs, in this case several services can use the same API.  
  
**[APIs help](~/Help)**

--------------------------------------------------------------------------------

## **bNesis SDK**

bNesis offers an SDK for all supporded services and all APIs for multiple platforms and programming languages.  
  
**[To learn more](~/Documentation/Examples) [GitHub](https://github.com/bNesisDeveloper/bNesis)**

**Versions**:

bNesis SDK is 1.7 [AGAVA] Core 

bNesis SDK is 1.8 [BELLADONNA] Core


