[Device Messaging Home](Index.md)

# Parsing a String Message

You can treat your message as a single string and then use a regular expession to extract the values from the string.  This is useful if your format changes and has optional values.

There are two steps to extract values from your message as a string

1) Define a regular expression including name groups to extract the values
2) Create fields that map to each value you wish to extract.  Each group will contain the regular expression group name to extract the value from the regular expressoin result.

For Example at the Message Level you would declare the Regular Expression

`<val1:(?'V1'[0-9]*)>`

Then add a field to the message with the group name `V1`

If the message parser receives a message similar to

`<val1:32>`

The field will be assigned to the field `32`

A great tool to test your regular expressions is [Regular Expressions 101](https://regex101.com/)