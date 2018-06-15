# PrestaShop registration

In order for you to view, edit and delete the data on your PrestaShop store through its web service, you first need to enable the web service feature, and then create an access key.

1. Go in the PrestaShop back office (Administrative mode). 

![image001](https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/PrestaShop/image001.jpg)

2. Open the "Webservice" page under the "Advanced Parameters" menu.

![image002](https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/PrestaShop/image002.jpg)

3. Then choose "Yes" for the "Enable PrestaShop's webservice". Save your change by pressing on "Diskette" icon.

![image003](https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/PrestaShop/image003.jpg)

4. Îpen the "Webservice" page under the "Advanced Parameters" menu.

![image004](https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/PrestaShop/image004.jpg)

5. Then click the "Add new webservice key " button to access the account configuration section. A long form appears:

![image005](https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/PrestaShop/image005.jpg)

6. Enter the Key description. The Status button has to be in "YES" position.  Set the resource permissions for this key by selection of top checkboxes.  Push the button "Generate!" to generate the Key. If you choose to use a custom passkey instead of a generated one, make sure it is very secure and that its rights are limited – and that it is 32 characters long!

**Key.** The API key serves as a main identifier for the webservice account you are creating. Click the "Generate" button to get an unique authentication key. You can also create your own (which must be 32 characters long), but using a generated key prevents wrong-doers from guessing your key too easily.  
Using this key, you and other selected users will be able to access the webservice.  
**Key description.** Helps you remember who you created that key for, what are the access rights assigned to it, etc. The description is not public, but make sure to put all the keywords pertaining to the user, so that you can find their key more quickly.  
**Status.** You can disable any key at any time.  
**Permissions.** This section is very important, as it enables you to assign rights for each resource you want to make available to this key. Indeed, you might want a user to have read and write access on some resources, but only read access on others – and no access to the more important ones.In the list of permissions, the checkbox most on the left enables you to define all the rights for a given resource. Likewise, the checkbox at the top of each column enables you to give the select right (View, Modify, etc.) to all the resources.  
Make sure to only select the rights needed for the usage of that key. Do not give all the rights for all resources to any key, keep that to yours and yours only.  
**Shop association.** This only appears in multistore mode. It enables you to choose which of your stores the key owner should have access to.

![image006](https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/PrestaShop/image006.jpg)

7. Save your change, press on "Diskette" icon.
 
![image007](https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/PrestaShop/image007.jpg)

8. The Key appears "Webservice" page under the "Advanced Parameters" menu.

![image008](https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/PrestaShop/image008.jpg)
