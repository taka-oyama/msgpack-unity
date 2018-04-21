# Changelog

## 2.0.0 (2018-04-22)

### Changed
- namespace has been changed to `SouthPointe.Serialization.MessagePack`
- Slight performance boost for real world string usage
- Attributes `NonSerialized`, `OnSerialized`, `OnSerializing`, `OnDeserialized`, `OnDeserializing` no longer rely on `System.Runtime.Serialization`

### Removed
- `MessagePack` was removed so people can implement a wrapper using that name

## 1.1.0 (2018-04-15)

### Added
- `MessagePack.AsJson(byte[])` for debugging and logging
- `Format.NeverUsed (0xc1)` was added for better testing
- `SnakeCaseNamingStragegy` for out of box compatibility with ruby

## 1.0.0 (2018-04-08)

- Initial Release
