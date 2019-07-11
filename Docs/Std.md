# Standard Library

## Math

|Name|Type Define|Description|
|:---|:---|:---|
|Math.max(number1, number2)|(`IceKoriInt`&#124;`IceKoriFloat`, `IceKoriInt`&#124;`IceKoriFloat`) => `IceKoriInt`&#124;`IceKoriFloat`|Returns the largest of zero or more numbers|
|Math.min(number1, number2)|(`IceKoriInt`&#124;`IceKoriFloat`, `IceKoriInt`&#124;`IceKoriFloat`) => `IceKoriInt`&#124;`IceKoriFloat`|Returns the lowest-valued number passed into it|
|Math.abs(number)|`IceKoriInt`&#124;`IceKoriFloat` => `IceKoriInt`&#124;`IceKoriFloat`|Returns the absolute value of a number|
|Math.floor(number)|`IceKoriInt`&#124;`IceKoriFloat` => `IceKoriInt`&#124;`IceKoriFloat`|Returns the largest integer less than or equal to a given number|
|Math.pow(number1, number2)|(`IceKoriInt`&#124;`IceKoriFloat`, `IceKoriInt`&#124;`IceKoriFloat`) => `IceKoriInt`&#124;`IceKoriFloat`|Returns the base to the exponent power|

## String

|Name|Type Define|Description|
|:---|:---|:---|
|String.match(value, regexp)|(`IceKoriString`, `IceKoriString`) => `IceKoriString`|Retrieves the result of matching a string against a regular expression|
|String.replace(value, oldValue, newValue)|(`IceKoriString`, `IceKoriString`, `IceKoriString`) => `IceKoriString`|Replaces the contents of newValue with the corresponding values in oldValue|
|String.split(value, separator)|(`IceKoriString`, `IceKoriString`) => `IceKoriArray<IceKoriString>`|Divides str into substrings based on a delimiter, returning an array of these substrings|

## Array

|Name|Type Define|Description|
|:---|:---|:---|
|Array.length(array)|(`IceKoriArray`) => `IceKoriInt`|Returns the number of elements in array. May be zero|
|String.include(array, value)|(`IceKoriArray`, `IceKoriBaseType`, `IceKoriBool`) => `IceKoriString`|determines whether an array includes a certain value among its entries|
