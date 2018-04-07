# MessagePack For Unity

This is a messagepack (aka MsgPack) serialization library written in C# specifically for [Unity](https://unity3d.com/unity).


### Core features

- Compatible with legacy scripting runtime (.NET 3.5)
- Compatible with other message pack libraries written in other languages such as PHP/Ruby/Javascript.
- Works with all types out of the box.
- Add or replace custom serialization handler for any definable type.
- Supports callback attributes `OnSerializing` `OnSerialized` `OnDeserializing` `OnDeserialized`
- Options to change how types like DateTime and Enums are serialized.
- Options to change how map field names are packed/unpacked (like changing names to snake case on pack.. etc)
