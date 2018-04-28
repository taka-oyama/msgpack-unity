# MessagePack For Unity

- Source: https://github.com/taka-oyama/msgpack-unity
- Author: [Takayasu Oyama](https://github.com/taka-oyama)
- License: MIT

This is a MessagePack (aka MsgPack) serialization library written in C# specifically for [Unity](https://unity3d.com/unity).

## Features

- Implements the latest [specification](https://github.com/msgpack/msgpack/blob/master/spec.md) (as of 2018)
- Compatible with .NET 3.5 scripting runtime
- Compatible with other MessagePack libraries written in other languages such as PHP/Ruby/Javascript
- Works with all types out of the box (as long as it has a default constructor)
- Add or replace custom serialization handler for any definable type
- Supports callback attributes `OnSerializing` `OnSerialized` `OnDeserializing` `OnDeserialized`
- Options to change how types like DateTime and Enums are serialized
- Options to change how map field names are serialized/deserialized (like changing names to snake case on serialize.. etc)
- Decode as JSON for easy debugging

## Installation
- [Download the latest .unitypackage in the releases section](https://github.com/taka-oyama/msgpack-unity/releases)
- Goto menu bar and choose **Assets > Import Package > Custom Package... > (Select the downloaded package)**

## Usage

* This library is under the namespace `SouthPointe.Serialization.MessagePack`

Basic Usage for Serializing/Deserializing

```cs
MessagePackFormatter formatter = new MessagePackFormatter();
int[] values = { 1, 2, 3 };
byte[] bytes = formatter.Serialize(values);
int[] result = formatter.Deserialize<int[]>(bytes);
```


Defining different context for different occasions

```cs
SerializationContext context = new SerializationContext();

MessagePackFormatter formatter = new MessagePackFormatter(context);
int[] result = formatter.Deserialize<int[]>(bytes, context);
```

Change options

```cs

SerializationContext context = new SerializationContext();
context.DateTimeOptions.PackingFormat = DateTimePackingFormat.Epoch;

MessagePackFormatter formatter = new MessagePackFormatter(context);
byte[] bytes = new MessagePackFormatter().Serialize(DateTime.Now); // DateTime serialized as double instead of Ext format.
```

Serialize to and Deserialize from snake cased maps

```cs
public class Map
{
    public int fooBar = 1;
}

SerializationContext context = new SerializationContext();
context.MapOptions.NamingStrategy = new SnakeCaseNamingStrategy();

MessagePackFormatter formatter = new MessagePackFormatter();
formatter.Serialize(new Map()); // serialized as  { foo_bar: 1 }
```

Using Attributes

```cs
public class MapWithCallbacks
{
    public int a = 1;

    [NonSerialized]
    public int b = 2; // ignored by serializer

    [OnSerializing]
    void T1()
    {
        // Called before serializing
    }

    [OnSerialized]
    void T2()
    {
        // Called after serializing
    }
}

MapWithCallbacks map = new MapWithCallbacks();
MessagePackFormatter formatter = new MessagePackFormatter();
byte[] bytes = formatter.Serialize(map);
```

Add A Custom Type Handler

```cs
using MessagePack;

public class MyCustomClassHandler : ITypeHandler
{
    public object Read(Format format, FormatReader reader)
    {
        // deserialize your object instance and return it
    }

    public void Write(object obj, FormatWriter writer)
    {
        // serialize your object instance
    }
}

Type type = typeof(MyCustomClass);
ITypeHandler handler = new MyCustomClassHandler();
SerializationContext.Default.typeHandlers.SetHandler(type, handler);
```

Checkout the implementations of other types in the TypeHandlers folder for reference.

## Debugging

You can debug your serialized binary by converting it to JSON by using `MessagePack.AsJson(byte[])`


```cs
public class Map
{
    public int foo = 1;
    public int[] bar = {1, 2};
}

Map value = new Map();
MessagePackFormatter formatter = new MessagePackFormatter();
byte[] bytes = formatter.Serialize(value);
string json = formatter.AsJson(bytes);

Debug.Log(json); // {"foo":1,"bar":[1,2]}
```
