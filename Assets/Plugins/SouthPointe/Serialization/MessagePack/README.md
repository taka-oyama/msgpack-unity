# MessagePack For Unity

- Source: https://github.com/taka-oyama/msgpack-unity
- Author: [Takayasu Oyama](https://github.com/taka-oyama)
- License: MIT

This is a MessagePack (aka MsgPack) serialization library written in C# specifically for [Unity](https://unity3d.com/unity).

## Features

- Implements the latest [specification](https://github.com/msgpack/msgpack/blob/master/spec.md) (as of 2018)
- Compatible with .NET 3.5 scripting runtime
- Compatible with other message pack libraries written in other languages such as PHP/Ruby/Javascript
- Works with all types out of the box (as long as it has a default constructor)
- Add or replace custom serialization handler for any definable type
- Supports callback attributes `OnSerializing` `OnSerialized` `OnDeserializing` `OnDeserialized`
- Options to change how types like DateTime and Enums are serialized
- Options to change how map field names are packed/unpacked (like changing names to snake case on pack.. etc)
- Decode as JSON for easy debugging

## Installation
- [Download the latest .unitypackage in the releases section](https://github.com/taka-oyama/msgpack-unity/releases)
- Goto menu bar and choose **Assets > Import Package > Custom Package... > (Select the downloaded package)**

## Usage

Basic Usage for Packing/Unpacking

```cs
int[] values = { 1, 2, 3 };
byte[] bytes = MessagePack.Pack(values);
int[] result = MessagePack.Unpack<int[]>(bytes);
```

Change options

```cs
SerializationContext.Default.dateTimeOptions.packingFormat = DateTimePackingFormat.Epoch;

byte[] bytes = MessagePack.Pack(DateTime.Now); // DateTime packed as double instead of Ext format.
```

Defining different context for different occasions

```cs
SerializationContext context = new SerializationContext();
int[] result = MessagePack.Unpack<int[]>(bytes, context);
```

Pack to and Unpack from snake cased maps

```cs
public class Map
{
    public int fooBar = 1;
}

SerializationContext.Default.mapOptions.namingStrategy = new SnakeCaseNamingStrategy();

MessagePack.Pack(new Map()); // serialized as  { foo_bar: 1 }
```

Using Attributes

```cs
using System.Runtime.Serialization;

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
byte[] bytes = MessagePack.Pack(map);
```

Add A Custom Type Handler

```cs
using MessagePack;

public class MyCustomClassHandler : ITypeHandler
{
    public object Read(Format format, FormatReader reader)
    {
        // unpack your object instance and return it
    }

    public void Write(object obj, FormatWriter writer)
    {
        // pack your object instance
    }
}

Type type = typeof(MyCustomClass);
ITypeHandler handler = new MyCustomClassHandler();
SerializationContext.Default.typeHandlers.SetHandler(type, handler);
```

Checkout the implementations of [other types](https://github.com/taka-oyama/msgpack-unity/tree/master/Assets/Plugins/MessagePack/TypeHandlers) for reference.

## Debugging

You can debug your packed binary by converting it to JSON by using `MessagePack.AsJson(byte[])`


```cs
public class Map
{
    public int foo = 1;
    public int[] bar = {1, 2};
}

Map value = new Map();
byte[] bytes = MessagePack.Pack(value);
string json = MessagePack.AsJson(bytes);

Debug.Log(json); // {"foo":1,"bar":[1,2]}
```
