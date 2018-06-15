¹ Skrill registration

1. To Create an account, go by link: (https://www.skrill.com/en/).

![image001](https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/Skrill/image001.jpg)

2. Enter your e-mail and password.

![image002](https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/Skrill/image002.jpg)

3. Enter your Name, Surname and date of birth.

![image003](https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/Skrill/image003.jpg)

4. Enter your country and walute currency.

!(image004[(https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/Skrill/image004.jpg)

5. Enter your address.

![image005](https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/Skrill/image005.jpg)

6. Enter your phone number and press Open account.

![image006](https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/Skrill/image006.jpg)

7. Confirm your e-mail and start to use your account.

![image007](https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/Skrill/image007.jpg)

8. Your account’s ID.

![image008](https://raw.githubusercontent.com/bNesisDeveloper/bNesis/master/Docs/Services/Skrill/image008.jpg)

To enable the MQI and / or API:
1. Log in to your Skrill account at (www.skrill.com).
2. Go to Settings > Developer Settings.  Check the Enable service checkbox next to the services you want to enable.
3. Specify at least one IP address from which requests will be made. All requests from other IP addresses are denied. Access can be granted to:  
• A single IP address (e.g. 192.168.0.2).
• Multiple IP addresses, separated by space (e.g. 192.168.0.2 10.0.0.2).
• A subnet in CIDR notation (e.g. 192.168.0.0/24).

Enter a list of IPs or at least one IP address (or an IP range) in the text fields in the corresponding sections.

5. To apply your changes, click Save.  
Separate API and MQI password.  
You must use a separate password for making API or MQI requests. This ensures that the password you use to access your Skrill Digital Wallet account can be changed without affecting the API or MQI.  
To enable a separate API/MQI password:  
1. In the Settings > Developer Settings area, check the Enable separate API/MQI password checkbox.
2. Enter a new password and confirm it in the Re?type password box below.
3. Click Save.

¹¹ Secret word

The secret word is used for the following:  
• To construct the msid digital signature parameter. This parameter is sent to the return_url if the secure return_url option is enabled for your merchant account. This signature is used to verify the authenticity of the information sent to the return_url once payment is complete.
• To create the digital signature parameters used to verify the authenticity of the payment status information that Skrill sends to the status_url .
• For the email check tool to carry out anti?fraud checks on email addresses.

To insert a secret word:
1. Go to the Settings > Developer Settings section of your Skrill account.
2. In the Secret Word field, enter your secret word. The following restrictions apply:
• All characters must be in lowercase.
• The length should not exceed 10 characters.
• Special characters are not permitted (e.g. @, %, $, etc.).  
*Note:* If you insert any uppercase symbols, they will automatically be converted to lowercase.  
3. To apply your changes, click Save.
