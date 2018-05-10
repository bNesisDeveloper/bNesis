bNesis SDK Dropbox sample.

This console example shows how to use bNesis SDK initialization, authentication in Dropbox service.

About

bNesis SDK is a unified API for working with cloud services for mobile, desktop, web and servers. With such versatility, it is better first to explain separately about bNesis SDK for mobile, desktop and web. If you are a mobile developer, it will be more interesting for you to learn about the implementation of bNesis SDK for Android, and if you are a Web developer, please read first the section about web applications and servers.

bNesis SDK for Desktop
In this case, there are two ways to use bNesis SDK – as a Rich client and as a Thin client 

bNesis SDK Desktop Rich client
In this case, bNesis SDK is delivered as a library and examples of its use for .NET and Win32 platforms.

bNesis SDK Desktop Thin client
In this case, bNesis SDK desktop library works with cloud services through bNesis Server we provide you as the server software to be placed on your sites, more information can be found here


Installation (for .NET)

Solution 1, Install 'bNesis SDK' from 'Nuget Package Manager':
1. Open your project on which you want install bNesis SDK, then choose 'References'.
2. Press right click mouse button on 'References'.
3. Choose 'Manage Nuget Packages...'
4. In 'Nuget Package Manager' select 'Browse'.
5. Write on search line 'bNesis.Sdk'.
6. Choose bNesis.Sdk.RichClient or bNesis.Sdk.ThinClient.
7. Install selected package.
(If you need install both packets repeat 6 and 7 step.)

Solution 2, Install 'bNesis SDK' from 'Package Manager Console':
1. Open your solution/project, choose on Visual Studio menu 'Tools > NuGet Package Manager > Package Manager Console'.
2. In 'Package Manager Console' click on 'Default Project'.
3. Select your project on which you want install bNesis SDK.
4. After 'PM>' write one of command:
	Install Rich Client command:
	Install-Package bNesis.Sdk.RichClient 
	Install Thin Client command:
	Install-Package bNesis.Sdk.ThinClient 
Example: 
            PM> Install-Package bNesis.Sdk.RichClient
            PM> Install-Package bNesis.Sdk.ThinClient
5. Run it(Press Enter).
            (If you need install both packets repeat 4 and 5 step.)

Solution 3, get bNesis SDK in Source Code from GitHub:
1. Download bNesis SDK from https://github.com/bNesisDeveloper/bNesisSDKCS
2. Build the source code at Visual Studio 2015-2017.
3. Add references for your application to bNesis SDK library.


Using 

1. If you use Thin Client mode, you need access to bNesis API Server. Address of the demo bNesis API server https://server2.bnesis.com
2. To use the bNesis SDK in your applications, you must have the bNesis Developer ID - the key that signs your copy of the bNesis SDK. To study bNesis SDK, tests and demonstrations, you can get the key from https://api.bnesis.com site, free of charge.
3. The bNesis SDK developers offer you to adhere to the following sequence of API usage:
3.1 Connect bNesis SDK modules to your application.
3.2 Use the bNesis SDK ServiceManager class to initialize clients of different modes:
	The InitializeRich method for RichClient
	The InitializeThin method for RichThin
3.3 After initialization, you must select the service with which you plan to work at your application and implement your application authorization procedure for the selected service using ServiceManager.CreateInstance method. You also need to specify bNesis Developer Id in this method parameter.
3.4 After successful authorization, your application accesses the resources of your chosen service through the methods of the Instance class. (access to the service API).

The life cycle of an application using the bNesis SDK can be represented in three simple steps:
1. bNesis ? Initialize (Rich client or Thin client)
2. bNesis ? Auth (bNesis Developer Id, service name)
3. bNesis ? Call service API # 1
   bNesis ? Call service API # 2
   ...
   bNesis ? Call service API #N 

 
Contacts:

https://bnesis.com – public
https://api.bnesis.com – developers
