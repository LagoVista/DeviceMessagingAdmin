# Device Messaging

### Intro

Since in many cases you can't dictate what messages your devices will send, you can create contracts that define how data should be extracted from your messages.  Extracting this data is independent of the message source.  


### Message Components

Depending on the source of your message you will have different areas to extact fields from your mesage, in addition you will have meta data about the message (if applicable based on the listener you are using)

#### Headers
For HTTP sources such as REST or SOAP these are the HTTP Headers that come along with the message.  For other transport types additional data may be available.  See docuemtnation about the particular listener you are using.

#### Query String
This is primarily used for REST based protocols but can be used to extract values from a query string using key value pairs

#### Uri
In addition to the server and port number being available in your message if your message also specifies a resource address such as https://mydomain.coom/device/run/2342 the /device/run/2342 can be used to populate the message content.

### Body or Payload
If you have a REST message this will be the POST or PUT content, most transports have some mechanism for passing data along with your message.  They body can be either Binary or Text, a Text message can be one of the following
* String
* Delimited
* JSON
* XML