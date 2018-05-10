bNesis SDK Facebook sample.

This web application example shows how to use bNesis SDK initialization, authentication and to get the person's political views in Facebook service. Use with the scope "user_religion_politics". All data will be wroten to the XML file.

Introduction
bNesis SDK for JS is one of bNesis SDK for web applications and allows developers easily use cloud services authorization and API in web applications developed in JavaScript programing language.

Comfortable service programming with bNesis SDK
The authorization is most common challenge of cloud services programing because complexity of OAuth 2.0 protocol and OpenID identity layer. Also network programing required havening wide range of tech knowledge. The bNesis SDK represented all of it as simple well-known program elements and it makes coding process easier and more intuitive. Code examples demonstrated how to use the bNesis SDK for JS for connection of cloud services in web applications and relevant guides are also provided. Any changes and updates of cloud services APIs are handled by versions of bNesis SDK for JS. bNesis SDK for JS significantly reduces coding time and project expenses.

bNesis API layers
bNesis SDK APIs provide an wrappers over the "low-level" of services APIs - also known as bNesis SDK API layers. There are three layers:

Unified API. At this layer bNesis SDK APIs return to developer the response as complete data structure with fields corresponding to the original service response fields. Developer operates with data structures in the C# programming language. Universal data structures for similar API groups are used for similar services. Unified API is used by developers for implementing cross-service solutions, when the same program code, without changes, has to work with different services.

Formalized API. At this layer bNesis SDK APIs return to developer the response as complete data structure with fields corresponding to the original service response fields. Developer operates with data structures in the C# programming language. Of course, formalized API is very effective when complex data structure is waited as response.

Raw API. By using this layer of bNesis SDK APIs, developer obtain full response from service including all fields and status codes which is provided by service owners. There are two reasons for supporting API of raw layer. The first is then there is code working properly with connected service and developer want to start using of bNesis SDK. In this case developer can save his code of service responses processing i.e adopting of exiting code to bNesis SDK does not need global changes. The second is a complete correspondence of the original documentation to the service. It is not usual and not informative but there can can be and vice versa. By the way, often responses with errors contain detailed descriptions which is useful for debug mode.

Providing architecture
bNesis SDK for JS is delivered as a scripts library and works with cloud services through bNesis API Server provided as the server software:

Thin client architecture is provided, the OAUTH authorization takes place on the side and in the context of bNesis API Server. In particular, it allows you to distribute OAUTH authorization for a single account across multiple workstations.
In the case of changes in the cloud services API, you don't need to update your application.
bNesis SDK Thin client is completely a cross-platform and multi-lingual solution. In this case, all the functionality is moved to bNesis API Server, only RESTful API interface is on the client side.
Advantages: small size, cross-platform, authorization distribution.

bNesis API Server is full-featured server with RESTful API interface to place on customer side. It can be used in the most convenient way for you - as a local office server or placed in the cloud, or on a dedicated site in the Internet. For test use of Thin Client, you can access the bNesis Demo Server with address https://server2.bnesis.com which is fully functional analogue of bNesis API Server. So you can see the work and the benefits of a server solution, develop several test applications and only after that make a decision about purchasing bNesis API Server.

Advantages: traffic control - number of connections and your servers load, safe and easy to control the sources of access and the amount of data transmitted.

Before start
bNesis Developer ID. To use the bNesis SDK in your applications, you have to obtain the bNesis Developer ID - the key that signs your copy of the bNesis SDK. To study bNesis SDK, tests and demonstrations, you can get the key from https://api.bnesis.com site, free of charge.

Cloud services setup. It is required to register your application in all cloud services you are planing to use. Such parameters as clientId, clientSecret, and redirectUri will be obtained from service after registration. Exact set of parameters depends of each cloud service.

Supported services
Social networks: LinkedIn, Facebook, VKontakte
eCommerce: Amazon ,BigCommerce, PrestaShop, Shopify, OpenCart
Files storage: BaiduBCS , Box, Dropbox, GoogleDrive, Mega, SugarSync
Analytics: GoogleAnalytics
Delivery services: UkrPoshta
Payment services: PayPal, LiqPay,Stripe
Government registry: Prozorro.
Versions
Current version of bNesis SDK for JS is 1.7.

Installation
Get the SDK

Download bNesis SDK for JS from GitHub: https://github.com/bNesisDeveloper/bNesis/tree/master/Sdk/JavaScript . The bNesis SDK for JS also uses the jQuery library (version 1.6 or higher is required), so you also need to include a following tag to your application:

< script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
Also include the following tags in your client-side code, specifying the correct path to the files on your site:

< script type="text/javascript" src="/YOUR_PATH/bNesis.Sdk.js"></script>
< script type="text/javascript" src="/YOUR_PATH/bNesisHTTPClient.js"></script>
< script type="text/javascript" src="/YOUR_PATH/bNesisServiceClient.js"></script>
Using
You need access to bNesis API Server. Address of the demo bNesis API server https://server2.bnesis.com

To use the bNesis SDK in your applications, you must have the bNesis Developer ID - the key that signs your copy of the bNesis SDK. To study bNesis SDK, tests and demonstrations, you can get the key from https://api.bnesis.com site, free of charge.

The bNesis SDK developers offer you to adhere to the following sequence of API usage:

3.1 Include bNesis SDK .js file with corresponding cloud service name to your application by adding the following tags:

< script type="text/javascript" src="/YOUR_PATH/bNesis.Sdk.FileStorages.DropBox.js"></script>
As example, the cloud service Dropbox was added. It is possible to include as much cloud services as supported by bNesis SDK.

3.2 Use the bNesis SDK ServiceManager class to initialize client.

3.3 After initialization, you must select the service with which you plan to work at your application and implement your application authorization procedure for the selected service using ServiceManager.CreateInstance method. You also need to specify bNesis Developer Id in this method parameter.

3.4 After successful authorization, your application accesses the resources of your chosen service through the methods of the Instance class (access to the service API).

The life cycle of an application using the bNesis SDK can be represented in three simple steps:

Step 1. bNesis > Initialize

Step 2. bNesis > Auth (bNesis Developer Id, clientId, clientSecret, redirectUri)

Step 3. bNesis > Call service API # 1

Step 4. bNesis > Call service API # 2

Step N. bNesis > Call service API #M

Contacts
For public https://bnesis.com

For developers https://api.bnesis.com