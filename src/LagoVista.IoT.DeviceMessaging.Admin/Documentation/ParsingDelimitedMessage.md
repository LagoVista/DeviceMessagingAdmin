[Device Messaging Home](Index.md)

# Parsing a Delimited Messaged

If you message content is text the values can be seperated by a delimiter.  This is generally a comma but is configurable but at this only one character delimiters are supported.

The delimiter will break your message into a 1-indexed array of values you can extract with a delimiter index.

### Quoted Text

Depending on how your device sends a message it may use quotes (") or ticks (') to denote strings.  If this is the case, select the quoted text option.  If you do not select this option the message does not support having embedded ticks or quotes.  If you select this option you can use traditional escaped characters such as \n \r \t, etc...


### Eamples
Here is an example of a message that does not use quoted text

`msg004,dev0001,324,52,45,off,overrange`

Here are the extracted values with their corresponding delimiter index

| Delimiter Index | Value      |
| --------------- | ---------- |
|               1 |  msg004    |
|               2 |  dev0001   |
|               3 |  324       |
|               4 |  52        |
|               5 |  45        |
|               6 |  off       |
|               7 |  overrange |


Here is an example of the same message using quoted text

`'msg004','dev0001',324,52,45,off,'overrange'`

| Delimiter Index | Value      |
| --------------- | ---------- |
|               1 |  msg004    |
|               2 |  dev0001   |
|               3 |  324       |
|               4 |  52        |
|               5 |  45        |
|               6 |  off       |
|               7 |  overrange |


