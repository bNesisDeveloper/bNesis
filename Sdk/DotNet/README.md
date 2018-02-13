# bNesis SDK .NET C#
bNesis SDK is a unified API for working with cloud services for mobile, desktop, web and servers. With such versatility, it is better first to explain separately about bNesis SDK for mobile, desktop and web. If you are a mobile developer, it will be more interesting for you to learn about the implementation of bNesis SDK for Android, and if you are a Web developer, please read first the section about web applications and servers 

bNesis SDK for Desktop
In this case, there are two ways to use bNesis SDK – as a Rich client and as a Thin client

bNesis SDK Desktop Rich client
In this case, bNesis SDK is delivered as a library and examples of its use for .NETand Win32 platforms:

    middleware server is not used, all the accesses to cloud services are direct.
    OAUTH authentication is performed on the side of your application; in particular, it allows to add support for social networks in your application.
    Multiple applications can use one installed bNesis SDK library.
    NuGet install packages and version control support is provided.
    Handlers for cloud services are stored in separate libraries, so you can control the size of bNesis SDK package, depending on the number of services your application uses.
    We provide usage examples of bNesis SDK for popular languages and development environments such as C\C ++, C#, Delphi.

Advantages: ability to use multiple applications, independence from intermediate servers.

bNesis SDK Desktop Thin client
In this case, bNesis SDK desktop library works with cloud services through bNesis Server we provide you as the server software to be placed on your sites, more information can be found here

    bNesis Server 

    At the API level of functional bNesis SDK Thin client is fully compatible with Rich client, the only difference is that in the case of Thin client, the OAUTH authorization takes place on the side and in the context of bNesis Server. In particular, it allows you to distribute OAUTH authorization for a single account across multiple workstations.
    In the case of changes in the cloud services API, you don’t need to update your application.
    bNesis SDK Thin client is completely a cross-platform and multi-lingual solution. In this case, all the functionality is moved to bNesis Server, only RESTful API interface is on the client side.

Advantages: small size, cross-platform, authorization distribution.

