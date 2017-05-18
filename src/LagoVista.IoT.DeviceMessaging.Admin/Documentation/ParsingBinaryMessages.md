[Home](Index.md)

# Parsing a Binary Message

## Intro 
Parsing a binary message is fairly complex but there are many options to specify how values should be extracted from the message payload.

## Endiness
The device may produce data in either [Little Endian](https://en.wikipedia.org/wiki/Endianness#Little) or [Big Endian](https://en.wikipedia.org/wiki/Endianness#Big).  Unless the firmware of your device is customizable this will be dictated by the device.  This is set at the device level since the device will send all its values in one format or the other and not mixed. 

## Data Types Available
The following are the available data types that can be extracted from a binary message
* char - Big or Little Endian
* byte - Big or Little Endian
* Int16 - Big or Little Endian
* UInt16 - Big or Little Endian
* Int32 - Big or Little Endian
* UInt32 - Big or Little Endian
* Int64 - Big or Little Endian
* UInt64 - Big or Little Endian
* Boolean - 0 = False, Not 0 = true
* String ([configurable](#Parsing-String-Values))
* Single Precision Floating Point as defined by by [IEEE 754-1985](https://en.wikipedia.org/wiki/IEEE_754-1985)
* Double Precision Floating Point as defined by by [IEEE 754-1985](https://en.wikipedia.org/wiki/IEEE_754-1985)

## Extracting Values
Values are extracted by index into the message.  These can be either relative or absolute.


##


## Parsing String Values 
At this time only single byte ASCII text is supported Unicode characters are not supported.

There are two ways extracting strings are supported in binary messages, null terminated prefixing the string by the string length.  If your string is null terminated the parser will start looking for the string at the defined index and start reading characters until either the null (0x00) terminated is found or you reach the end of the message.

If the string length is prefixed to the string you need to set the following options
* Number of Bytes - You need to specify how many bytes are used to define the string length.  Currently 1, 2 and 4 are supported.
* Endiness - (will be inheritied from the message if applicable, but need to specify if you are searching for Message or Device Ids
