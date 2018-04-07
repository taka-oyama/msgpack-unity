# MessagePack For Unity

This is a messagepack (aka MsgPack) serialization library written in C# specifically for [Unity](https://unity3d.com/unity).


## Features

- Implements the latest (as of 2018) [specification](https://github.com/msgpack/msgpack/blob/master/spec.md)
- Compatible with legacy scripting runtime (.NET 3.5)
- Compatible with other message pack libraries written in other languages such as PHP/Ruby/Javascript
- Works with all types out of the box
- Add or replace custom serialization handler for any definable type
- Supports callback attributes `OnSerializing` `OnSerialized` `OnDeserializing` `OnDeserialized`
- Options to change how types like DateTime and Enums are serialized
- Options to change how map field names are packed/unpacked (like changing names to snake case on pack.. etc)

## Installation
- [Download the latest .unitypackage in the releases section](https://github.com/taka-oyama/msgpack-unity/releases) 
- Goto the top menu bar and choose **Assets > Import Package > Custom Package... > (Select msgpack-unity)**

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

DateTime date = DateTime.Now;
byte[] bytes = MessagePack.Pack(date, context); // DateTime packed as double instead of Default Ext format.
```

Defining different context for different occations

```cs
SerializationContext context = new SerializationContext();
context.dateTimeOptions.packingFormat = DateTimePackingFormat.Epoch;

int[] result = MessagePack.Unpack<int[]>(bytes, context);
```

Using Attributes

```cs
using System.Runtime.Serialization;

public class MapWithCallbacks
{
    public int a = 1;

    [NonSerialized]
    public int b = 2; // ignored

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
