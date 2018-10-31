<html>
<head>
    <title>bNesis Examples!!!!</title>
</head>
<body>
<?php
include "Bnesis.php";

# This is simple example how to using bNesis SDK to get the list and size of all Google Drive files.
# To use this example, you need to get Google Drive access token, for do this:
#     - go to link and choose the Google Drive service http://socialpilot.bnesis.com/Data/TokenReceiver?adminId=28
#     - copy the token into this example source code.
# Please note: life time of Google Drive access token 1 hour.

#To use APIs of the service you have to enter the name of the service:
static $service = "GoogleDrive";
#PLEASE PAY ATTENTION HERE: Your bNesis Google Drive access token here
static $bNesisToken = "Put your bNesis Google Drive access token here"; //to get token visit here: http://socialpilot.bnesis.com/Data/TokenReceiver?adminId=28
#Address of the demo bNesis APIs server
static $bNesisApiServer = "https://server2.bnesis.com/";
#To use the bNesis SDK in your applications, you must have the bNesis Developer ID - the key that signs your copy of the bNesis SDK:
static $bNesisDevId = "LtyTYPBW9Zca01mUBZy+YhAvHiw93/lcDOZGyqy/l/5ROWASzNCF6kzrm/kiUdqf3G+cZOy8r2OyVmk5s/mSnw==";
#bNesis parameter for get list of all Google Drive files
static $getFullListAPI ='{"api":"GetFullList","parameters":null}';
#bNesis parameter for get count and size of all Google Drive files
static $getFullSizeAPI ='{"api":"GetFullSize","parameters":null}';

#Using bNesis Init method to connect to bNesis APIs server
Bnesis::Init($bNesisApiServer, $bNesisToken,$service,$bNesisDevId);
#Call (execute) GetFullList from bNesis APIs server
$resultMethodFirst = Bnesis::Call($getFullListAPI);
echo "Result first's call method: ".$resultMethodFirst . "<br><br>";

#(execute) GetFullSize from bNesis APIs server without using Init method
$resultMethodSecond = Bnesis::Call($getFullSizeAPI,$bNesisApiServer, $bNesisToken,$service,$bNesisDevId);
echo "Result second's call method: ".$resultMethodSecond . "<br><br>";

?>
</body>
</html>