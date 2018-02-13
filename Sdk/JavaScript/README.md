# bNesis SDK JS#
bNesis SDK is a unified API for working with cloud services for mobile browsers, web and servers. With such versatility, it is better first to explain separately about bNesis SDK for mobile browsers,and web. If you are a mobile developer, it will be more interesting for you to learn about the implementation of bNesis SDK for Android, and if you are a Web developer, please read first the section about web applications and servers. 



bNesis SDK JS client
In this case, bNesis SDK client scripts work with cloud services through bNesis Server we provide you as the server software to be placed on your sites.

bNesis Server 

At the API level the OAUTH authorization takes place on the side and in the context of bNesis Server. In particular, it allows you to distribute OAUTH authorization for a single account across multiple workstations.

In the case of changes in the cloud services API, you don’t need to update your application. All the functionality is moved to bNesis Server, only RESTful API interface is on the client side.

Advantages: small size, cross-platform, authorization distribution.

