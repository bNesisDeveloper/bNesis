**bNesis SDK** is a unified API for working with cloud services for mobile, desktop, web and servers. With such versatility, it is better first to explain separately about **bNesis SDK** for mobile, desktop and web. If you are a mobile developer, it will be more interesting for you to learn about the implementation of **bNesis SDK** for Android, and if you are a Web developer, please read first the section about web applications and servers  

|                                    |                            |                               |                                 |
| ---------------------------------- | -------------------------- | ----------------------------- | ------------------------------- |
| [bNesis SDK for Android](#android) | [Rich clien](#androidrich) | [Thin clien](#androidthin)    |                                 |
| [bNesis SDK for Desktop](#desktop) | [Rich clien](#desktoprich) | [Thin clien](#desktopthin)    | [bNesis Unified API](#unified)  |
| [bNesis SDK for Web](#webclient)   | [for Web app](#webclient)  | [for the Servers](#webserver) | [bNesis Server](#server)        |
  
  

Please note, [examples of the source code](/Documentation/Examples) for different use cases of bNesis SDK are also available for you.

#### bNesis SDK for Android

For Android, there are several options **bNesis SDK** \- Rich and Thin client.

**bNesis SDK Android Rich client**  
In the case of a Rich client, **bNesis SDK** is installed on the device as Android Service.  
This solution allows to solve several problems at once:

*   It makes possible to update **bNesis SDK** service regardless of Android applications using it. In this case, your Android app using **bNesis SDK** is protected from changes taking place with an API of cloud services it uses. For example, if the DropBox changes the API, you don’t need to rewrite and update your app - **bNesis SDK** Android service updates automatically, by regular means of Android update process for your application to be transparent.
*   If several applications installed on your Android device are using **bNesis SDK**, then the memory size occupied by the device should not be increased, as they use the same **bNesis SDK** Android service. In addition, each application is signed for **bNesis SDK** Service using separately.
*   No middleware servers, **bNesis SDK** Android service is working directly with cloud services.
*   We provide Android example applications demonstrating work with **bNesis SDK** Android service for Android Java and Xamarin C# (there is support for Xamarin NuGet).
*   You can use **bNesis SDK** online constructor to create a code of your Android apps using **bNesis SDK.**
*   By special agreement, we provide source code of bNesis Android Service.
*   OAUTH authentication for cloud services takes place on the side of the device. bNesis Service is a good opportunity to add quickly a support for social networks in your Android app.

**Advantages:** automatic updates, saving the device memory, no middleware server, compatibility with Java and C# programing languages.

**bNesis Android Thin client**  
In this implementation, the mobile application uses bNesis Server with bNesis RESTful API – the main bNesis feature is that we transfer the Server Software (bNesis Server) for more information, please read this

*   [bNesis Server](#server)

*   Functionally bNesis Android Thin client app is fully consistent with Rich client app, the only difference is in OAUTH authorization for cloud services, in this case it takes place on the server side and in the context of bNesis Server.
*   You can use the Rich client code, in the Thin client code the API interface is fully compatible.
*   We provide application examples for Android Java and Xamarin C# (there is support for Xamarin NuGet).
*   You can use bNesis online code constructor to build your Android application source code online, using step by step instructions.

**Advantages:** small size, independent from the update availability for the device, the ability to distribute OAUTH authorization of a single account across multiple devices

[top](#top)

#### bNesis SDK for Desktop

In this case, there are two ways to use **bNesis SDK** – as a Rich client and as a Thin client

**bNesis SDK Desktop Rich client**  
In this case, **bNesis SDK** is delivered as a library and examples of its use for .NETand Win32 platforms:  

*   middleware server is not used, all the accesses to cloud services are direct.
*   OAUTH authentication is performed on the side of your application; in particular, it allows to add support for social networks in your application.
*   Multiple applications can use one installed **bNesis SDK** library.
*   NuGet install packages and version control support is provided.
*   Handlers for cloud services are stored in separate libraries, so you can control the size of **bNesis SDK** package, depending on the number of services your application uses.
*   We provide usage examples of **bNesis SDK** for popular languages and development environments such as C\\C ++, C#, Delphi.

**Advantages:** ability to use multiple applications, independence from intermediate servers.

**bNesis SDK Desktop Thin client**  
In this case, bNesis SDK desktop library works with cloud services through bNesis Server we provide you as the server software to be placed on your sites, more information can be found here

*   [bNesis Server](#server)

*   At the API level of functional **bNesis SDK** Thin client is fully compatible with Rich client, the only difference is that in the case of Thin client, the OAUTH authorization takes place on the side and in the context of bNesis Server. In particular, it allows you to distribute OAUTH authorization for a single account across multiple workstations.
*   In the case of changes in the cloud services API, you don’t need to update your application.
*   **bNesis SDK** Thin client is completely a cross-platform and multi-lingual solution. In this case, all the functionality is moved to bNesis Server, only RESTful API interface is on the client side.

**Advantages:** small size, cross-platform, authorization distribution.

[top](#top)

#### bNesis for Web Applications

In this case, we also provide bNesis Server for placement on your site, more information can be found here

*   [bNesis Server](#server)

*   We provide examples of the use at JavaScript (JQuery library)
*   You can use bNesis code constructor to create your application online in a step-by-step

**Advantages:** the ability of quick integration of cloud services into the web browser.

[top](#top)

##### bNesis for the Server (Web server)

You can use bNesis Server for access from your backend server application. You can find more about bNesis Server here

*   [bNesis Server](#server)

*   The best solution is to use bNesis for Web applications together with bNesis Server. One of the features is a distributed authorization. You can access the cloud service received from the Web application on the side of your server even when the user is Offline

**Advantages:** Support for user session on the side of the back end, the ability to complement the functionality of the server.

[top](#top)

#### bNesis Server

The main feature of bNesis solution is that we provide a full-featured **bNesis SDK** Server with RESTful API interface to place on your site. You can use bNesis Server in the most convenient way for you - as a local office server or placed in the cloud, or on a dedicated site in the Internet.

In this case, right after your registration at bNesis website, we provide you with a place on one of bNesis Demo Servers. bNesis Demo Servers are fully functional analogues of API bNesis Server.

So you can see the work and the benefits of a server solution, develop several test applications and only after that make a decision about purchasing bNesis Server.

**Note:** bNesis Demo Server possibilities are limited by the number of users and the amount of information transmitted.

**Advantages:**

*   You control the traffic, number of connections and your servers load.
*   It is safe as it is easy to control the sources of access and the amount of data transmitted.
*   There is no "monthly" payment for the number of accesses to the API, the amount of traffic and so on.
*   By special arrangement, we transfer the source code to bNesis Server, which makes it completely safe to use - you can add features like encryption channel for your customers, monitoring and management of all server connections.
*   There are two ways of the server update:  
    • We provide you with a new version in files and libraries which you transfer to your server.  
    • By special agreement (in the case of an IIS server) you can provide us administration access and we publish bNesis Server new versions on your IIS server.

[top](#top)

#### Unified bNesis API

Earlier we mentioned about the fact that bNesis provides almost the same API sets for mobile, desktop and web, to Rich and Thin clients. Thus, if you develop both mobile - web application, you can use the already familiar to you mobile API to implement web applications. Commonality of API - when several similar functionality services provide an API for the same operations, **bNesis SDK** provides a single API for the operation; you need only to specify the service you want to perform this operation with.

For example:  
When you wrote a code for Android Java authorizing a user in GoogleDrive and uploading photos from your device on its drive, in case you use **bNesis SDK**, it is enough for you to change your code from Google Drive to DropBox and then your application will be able to upload photos to DropBox as well. In the same way, you can add all unified cloud storage supported **bNesis SDK**.

If we consider that **bNesis SDK** service for Android is updated independently at the user’s devices and the number of services increases, then your application will increase and add the number of supported services, even after the release, without the application updates.

[top](#top)

#### Conclusion

**Conclusion**  

**bNesis SDK** is a cross-platform client server solution that allows you to develop web, mobile and desktop applications. It is easy to switch from using the Rich to Thin clients and vice versa. So you get your own bNesis Server to implement all of your ideas associated with cloud services. bNesis is constantly increasing the amount of support cloud services and the unified API make it possible to expand the functionality of your applications without updating them.

The code written for one platform can be easily transferred to another one, and at the same time the sense and API functionality remains the same when switching between platforms, programming languages and architecture.

[top](#top)

#### If you are not familiar with working with bNesis

please follow three simple steps for that would create your first bNesis application:

**Step 0** Using [bNesis C# Code Constructor](/bNesisUI/Constructor) to create the source code of your first application online.

**Step 1** Registered in [bNesis Admin service](/bNesisUI/Settings) that would get your bNesis developer ID.

**Step 2** Install the NuGet package with bNesis library.

`PM> Install-Package bNesis.Sdk.ThinClient`

`PM> Install-Package bNesis.Sdk.RichClient`

##### SDK examples source

.NET C# examples [source code](https://github.com/bNesisDeveloper/bNesisSDKCS) on GitHub.

[top](#top)