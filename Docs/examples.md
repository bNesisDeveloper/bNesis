**bNesis SDK** is a unified API for working with cloud services for mobile, desktop, web and servers. With such versatility, it is better first to explain separately about **bNesis SDK** for mobile, desktop and web. If you are a mobile developer, it will be more interesting for you to learn about the implementation of **bNesis SDK** for Android. If you are a Web developer, read first the section about web applications and servers.  
  

**Please note** that we show only source code for working with the bNesis SDK API. In these examples there is no UI design and other beauty. We did so to don't distract developers with unnecessary details.  
  

Below we offer you a table it will help you to choose the right type of application and programming language, to select an example and to click on the desired cell.  


| Type                 |  Web application    | Android                | Xamarin                | .NET                  | Win32                   |
| -------------------- | ------------------- | ---------------------- | ---------------------- | --------------------- | ----------------------- |

| Rich client          |          -         | [Yes](#AndroidRich)   | [Yes](#AndroidRich)   | [Yes](#NETRich)      | [Yes](#WinRich)        |
| Thin client          | [Yes](#WebThin)    | [Yes](#AndroidThin)   | [Yes](#AndroidThin)   | [Yes](#NETThin)      | [Yes](#WinThin)        |


**Please note.** To compile this examples source code, you need a bNesis Developer ID. It is freely available. Register and receive your bNesis Developer ID in the Settings section.


#### Web application examples


**bNesis SDK** examples for Web applications:  

In this case, we also provide bNesis Server for placement on your site:


*   [bNesis Server](/Documentation/About)


*   We provide examples of the use at JavaScript

*   We provide examples of the use at PHP


[top](#top)


#### Android Rich client examples


**bNesis SDK** Android Rich client examples:  


*   It makes possible to update **bNesis SDK** service regardless of Android applications using it. In this case, your Android app using **bNesis SDK** is protected from changes taking place with an APIs of used cloud services. For example, if DropBox changes its API, you don’t need to rewrite and to update your app. **bNesis SDK** Android service will be updated automatically, by regular means of Android update process for your application to be transparent.

*   If several installed on your Android device applications are using **bNesis SDK**, then the occupied by the device memory size should not be increased, as they use the same **bNesis SDK** Android service. In addition, each application is signed for **bNesis SDK** Service using separately.

*   No middleware servers. **bNesis SDK** Android service is working directly with cloud services.

*   We provide Android example applications to demonstrate working with **bNesis SDK** Android service for Android Java and Xamarin C# (there is a support for Xamarin NuGet).

*   You can use **bNesis SDK** online constructor to create a code of your Android apps using **bNesis SDK.**

*   By special agreement, we provide source code of bNesis Android Service.

*   OAUTH authentication for cloud services takes place on the side of the device. bNesis Service is a good opportunity to add a support for social networks in your Android app quickly.

[top](#top)


#### Android Thin client example


**bNesis SDK** Android Thin client examples:  

In this case, we also provide bNesis Server for placement on your site. More information can be found here.


*   [bNesis Server](/Documentation/About)


*   Functionally bNesis Android Thin client app is fully consistent with Rich client app. The difference is in OAUTH authorization for cloud services. In this case it takes place on the server side and in the context of bNesis Server.

*   You can use the Rich client mode. In the Thin client mode the API interface is fully compatible.

*   We provide application examples for Android Java and Xamarin C# (there is a support for Xamarin NuGet).


[top](#top)


#### .NET Rich client examples


**bNesis SDK** examples for .NET (Rich client):  


*   middleware server is not used, all accesses to cloud services are direct.

*   OAUTH authentication is performed on the side of your application. It allows to add support for social networks in your application.

*   Multiple applications can use one installed **bNesis SDK** library.

*   NuGet install packages and version control support is provided.

*   Handlers for cloud services are stored in separate libraries. So you can control the size of **bNesis SDK** package, depending on the number of services your application uses.


[top](#top)


#### .NET Thin client examples


**bNesis SDK** examples for .NET (Thin client).  

In this case, bNesis SDK desktop library works with cloud services through the bNesis Server, we provide it to you as the server software to be placed on your sites. More information can be found here: [bNesis Server](/Documentation/About)


*   At the API level of **bNesis SDK** functionality Thin client is fully compatible with the Rich client. The difference is that in the case of Thin client, the OAUTH authorization takes place on the side and in the context of the bNesis Server. In a special case it allows you to distribute OAUTH authorization for a single account across multiple workstations.

*   In the case of changes in the cloud services API, you don’t need to update your application.

*   **bNesis SDK** Thin client is a completely cross-platform and multi-lingual solution. In this case, all the functionality is moved to bNesis Server. Only RESTful API interface is on the client's side.


[top](#top)


#### Win32 Rich client examples


**bNesis SDK** examples for .NET (Rich client):  


*   middleware server is not used, all accesses to cloud services are direct.

*   OAUTH authentication is performed on the side of your application. In a special case it allows to add a support for social networks in your application.

*   Multiple applications can use one installed **bNesis SDK** library.


*   Handlers for cloud services are stored in separate libraries. So you can control the size of **bNesis SDK** package, depending on the number of services your application uses.

*   It is necessary to install .NET 4.5.2.

[top](#top)


#### Win32 Thin client example


**bNesis SDK** examples for Win32 (Thin client):  


*   [bNesis Server](/Documentation/About)


*   OS Windows XP has no .NET 4.5.2 and it is necessary to install it.

*   At the API level of functional **bNesis SDK** Thin client is fully compatible with the Rich client. The only difference is that in the case of Thin client, the OAUTH authorization takes place on the side and in the context of bNesis Server. In a special case it allows you to distribute OAUTH authorization for a single account across multiple workstations.

*   In the case of changes in the cloud services API, you don’t need to update your application.

*   **bNesis SDK** Thin client is a completely cross-platform and multi-lingual solution. In this case, all the functionality is moved to the bNesis Server. Only RESTful API interface is on the client side.

[top](#top)