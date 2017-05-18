[Device Messaging Home](Index.md) > [Parsing Binary Messages] (ParsingBinaryMessage.md)

# Framing Bytes

When parsing a binary message you can use framing bytes to ensure your message is in the exact format you expect as well set check points for relative locations in your message (not implemented as of 5/18/2017)

Framing bytes consist of two parameters:

*Byte - Two character representation of the byte for example 0D would be 13 or CR
*Index - Index with in the message where this character should be located.

*NOTE* In this case the index or binary offset is 0 based which is different than parsing delimited values where the index of the delimited value is 1.

### Example
For example the binary message:

`01 32 02 43 52 08 03 04`

You could specify the following Framing Bytes:

| Position | Byte | Description |
|  0  | 01 | Look for SOH in the first position |
|  2  | 02 | Look for STX in the second position |
|  6  | 03 | Look for ETX in the sixth position |
|  7  | 04 | Look for EOT in the sevent position |

With the above message, the parsing would succeed.

If you use the same framing bytes with the message

`01 32 43 02 43 52 08 03 04`

The parsing of the message would fail since the character `02 (STX)` is located at position 3 not position 2.