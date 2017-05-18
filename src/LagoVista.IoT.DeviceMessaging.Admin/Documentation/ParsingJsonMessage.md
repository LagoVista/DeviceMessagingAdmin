[Home](Index.md)

# Parsing a Json Message

To Select a JSON value make sure the Search Location is set to Body

*Note* - Currently arrays are not supported in JSON format, this will likely change relatively soon after initial launch or sooner based on implementation requirements

The values can be extract by using a period (.) to denote the path to the object within the JSON document.

Assuming the following JSON:
~~~~
{
	'field1':'value1',
	'subset1':{
		'field3':'value2',
		'field4':'another value'
	}
}
~~~

Values can be extracted with the following JSON path.

`field` = value1
`subset1.field3` = value2
`subset1.field4` = another value