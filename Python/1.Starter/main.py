from bNesis import bNesis

# This is simple example how to using bNesis SDK to get the list and size of all Google Drive files.
# To use this example, you need to get Google Drive access token, for do this:
#     - go to link and choose the Google Drive service http://socialpilot.bnesis.com/Data/TokenReceiver?adminId=28
#     - copy the token into this example source code.
# Please note: life time of Google Drive access token 1 hour.
def main():
	# To use APIs of the service you have to enter the name of the service:
    Service = "GoogleDrive"
	# PLEASE PAY ATTENTION HERE: Your bNesis Google Drive access token here
	# To get token visit here: http://socialpilot.bnesis.com/Data/TokenReceiver?adminId=28
    bNesisToken = "aXVxdDgrUlRTcjdXaml0eFZjUGxzWW5MWDRjM29sNnRkRVluRE1pdGRzdW56UnlrRkxkU2NyajM0QnRpbzdsK0tORGZRTkR6aG1ZWDFPeHpEUG1nQ2ZlWjU3OHViTzhnRE9hei9oUEpTcnk0azc5UmU4Q2JJUUZTT3pUTFdaaHlnZ0NpZlZodUgrNzNrSUtleS9wTm81amZ6SmJlcVhRTzh3c2l3R2NXT1lwZU5UK0hjcDZueWh0cXNDUVVQUU5lTmU4QnZGai92V3JoU3BKcHRhd0RPL3ZLOXJnTmJNRWlxUXlQRjhIckJ2MGNZUkg3Rjh0RWJybmVnVGdTZ3I2aQ" 
	# Address of the demo bNesis APIs server
    bNesisApiServer = "server2.bnesis.com"
	# To use the bNesis SDK in your applications, you must have the bNesis Developer ID - the key that signs your copy of the bNesis SDK:
    bNesisDeveloperId = "LtyTYPBW9Zca01mUBZy+YhAvHiw93/lcDOZGyqy/l/5ROWASzNCF6kzrm/kiUdqf3G+cZOy8r2OyVmk5s/mSnw=="
	# bNesis parameter for get list of all Google Drive files
    GetFullListApi = '{"service": "GoogleDrive","api": "GetFullList","parameters":null}'
	# bNesis parameter for get count and size of all Google Drive files
    GetFullSizeApi = '{"service": "GoogleDrive","api": "GetFullSize","parameters":null}'	
	
	# Using bNesis Init method to connect to bNesis APIs server
    bNesis.Init(Service, bNesisToken, bNesisApiServer, bNesisDeveloperId)	
	# Call (execute) GetFullList from bNesis APIs server
    result = bNesis.Call(GetFullListApi)
    print ( result.encode())
	#(execute) GetFullSize from bNesis APIs server without using Init method
    result = bNesis.Call(GetFullSizeApi, Service, bNesisToken, bNesisApiServer, bNesisDeveloperId)
    print ( result.encode())

if __name__ == '__main__':
    main()