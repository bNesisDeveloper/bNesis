
**bNesis** allows developers to easily use the authorization of cloud services and their APIs in the Web, mobile and desktop applications.

 --------------------------------------------------------------------------------


## **Comfortable service programming with bNesis**
 

Authorization in the cloud service is the most difficult part of programing the cloud services because of the complexity of the OAuth 2.0 protocol and OpenID identity. In addition, network programming requires the use of a wide range of technical knowledge. The bNesis SDK represents all of it as simple well-known program elements. It makes coding process easier and more intuitive. Code examples demonstrate how to use the bNesis SDK in C# (.NET), Java and JavaScript for connection to cloud services. Any changes and updates of cloud services' APIs are handled by versions of bNesis SDK for C# (.NET), Java and JavaScript. bNesis SDK significantly reduces coding time and project expenses. 


## **bNesis API layers**


bNesis SDK APIs provide a wrapper over the "low-level" of cloud services APIs - also are known as bNesis SDK API layers. There are three layers:  

* **Raw API**. By using this layer of bNesis SDK APIs, developer obtains a full response from the service including all fields and status codes which is provided by service owners. There are two reasons for supporting APIs of raw layer.  
The first reason is used when there is a code working properly with connected cloud service and developer wants to start using of bNesis SDK. In this case developer can save his code created for service responses processing. Adopting of existing code to the bNesis SDK does not need global changes.  
The second reason is used when there is not a complete correspondence of the original documentation and service working. It is not usual and informative way but it is possible. By the way, responses with errors often contain detailed descriptions which is useful for debug mode.  

* **Formalized API**. At this layer bNesis SDK APIs return to developer the response as a complete data structure with fields corresponding to the original service response fields. Developer operates with data structures in the programming language. Of course, formalized API is very effective when complex data structure is waited as a response.  
* **Unified API**. At this layer bNesis SDK APIs return to developer the response as complete data structure with fields corresponding to the original service response fields. Developer operates with data structures in the programming language. Universal data structures for similar API groups are used for similar services.  Unified API is used by developers for implementing cross-service solutions, when the same part of a program code, has to work with different services without changes,.

## **Providing Rich and Thin client architecture**  
  

Planing of using cloud services in your applications system, designer determines optimal architecture depending on whether lengthy computations must be accomplished by the client or by the server. bNesis SDK provides an opportunity to realize these two modes - Rich client mode and Thin client mode. At the API level, functionality of Thin client mode is fully compatible with Rich client mode. The only difference is that in the case of Thin client, the OAUTH authorization takes place on the side and in the context of bNesis API Server.  
    

**Rich client mode**. In this case, bNesis SDK is delivered as a library and all the accesses to cloud services are direct:

* Middleware server is not used.

* OAUTH authentication is performed on the side of your application. 

* Multiple applications can use one installed bNesis SDK library.

* NuGet install packages and version control support is provided.

* Handlers for different services are stored in separate libraries, so you can control the size of bNesis SDK package, depending on the number of services your application uses.
     

**Advantages:** *ability to use multiple applications, independence from intermediate servers*.


**Thin client mode**. In this case, bNesis SDK is delivered as a library and works with cloud services through **bNesis API Server** provided as the server software:  

* At the API level, functionality of Thin client is fully compatible with Rich client. The only difference is that in the case of Thin client, the OAUTH authorization takes place on the side and in the context of bNesis API Server. In particular, it allows you to distribute OAUTH authorization for a single account across multiple workstations.

* NuGet install packages and version control support is provided.

* In the case of changes in the cloud services' API, you don't need to update your application.

* bNesis SDK Thin client is a completely cross-platform and multi-lingual solution. In this case, all the functionality is moved to bNesis API Server, only RESTful API interface is on the client's side.
      

**Advantages:** *small size, cross-platform, authorization distribution*.


**bNesis API Server** is a full-featured server with RESTful API interface to place on customer's side. It can be used in the most convenient way for you - as a local office server or placed in the cloud, or on a dedicated site in the Internet.  
For test use of Thin Client, you can access the bNesis Demo Server with the address https://server2.bnesis.com, which is fully functional analogue of bNesis API Server. So you can see the work and the benefits of a server solution, develop several test applications and only after that make a decision about purchasing bNesis API Server.


**Advantages:** *traffic control - number of connections and your servers load, safe and easy to control the sources of access and the amount of transmitted data*.

--------------------------------------------------------------------------------


## **Before start** 

**bNesis Developer ID**. To use the bNesis SDK in your applications, you have to obtain the bNesis Developer ID - the key that signs your copy of the bNesis SDK. To study bNesis SDK, tests and demonstrations, you can get this key after registration, free of charge.
  

**Cloud service setup**. It is required to register your application in all cloud services you are planing to use. Such parameters as clientID, clientSecret, redirectURI will be obtained from the service after registration. Exact set of parameters depends of each cloud service. 
	
 --------------------------------------------------------------------------------


## **First step**
A tool that visualizes the work with **services API Caller**.

Specially developed online software that represents a work with services in the form of a graphical userinterface (UI). All APIs of all services supported by bNesis are available for use. There is no need to immediately start programming using the bNesis SDK in order to learn its capabilities. Or if you follow the goal to explore the capabilities of the services - what data the service returns and what parameters are required for this. It does not need to investigate the service documentation or to be engaged in programming.


We have developed a special demonstrative service that explains the work with bNesis step by step. This service is completely free and includes learning examples, from the simplest, to the more complex ones. For example, you can find out the weather in London or get NASA information, using calls to relevant services.  
  

**[Try API Caller demonstrative service right now](/Api/Caller?instanceId=8f14e45fceea167a5a36dedd4bea2543&Service=DemoService)**

--------------------------------------------------------------------------------


## **bNesis account**

Create your own account.

We suggest you to create your own account to manage the services you need. This account is purely demonstrative and helps you to explore the capabilities of the bNesis SDK and bNesis API Servers. bNesis account allows you to get bNesis developer ID and to use bNesis SDK (Rich and Thin variants), absolutely free of charge in the introductory order.  
  

**[Create bNesis account](/Account/Login#signup)**

--------------------------------------------------------------------------------


## **bNesis API help**

Services' APIs' help documentation about all supported services APIs and data types includes a full description of all supported services and their APIs. The information is presented in sections. Also, bNesis implements joint called unified APIs. In this case several services can be used by the same bNesis API.  
  

**[APIs help](/Help)**

--------------------------------------------------------------------------------


## **bNesis SDK**


bNesis offers any SDK for any multiple platforms and programming languages to work with all supported services and all their APIs.  
  

**[To learn more](/Documentation/Examples) [GitHub](https://github.com/bNesisDeveloper/bNesis)**


**Versions**:


bNesis SDK 1.7 [AGAVA] Core.  


bNesis SDK 1.8 [BELLADONNA] Core.


