# Changelog

## 2.4.1 (2020-03-11)

### Fixed
- Fixed bug where Serializing Unity secific types like Vector3 would not be serialized in Map.

## 2.4.0 (2019-12-24)

### Fixed
- `MapOptions.RequireSerializableAttribute` was returning true when it shouldn't have.

### Added
- Added an option to ignore auto-property values in MapOptions. Due to this option, the auto-properties are no longer serialized unless specified.

## 2.3.2 (2018-05-27)

### Added
- Added custom menu to make it easier to export package

### Changed
- Refactored internal code for better readability
- String now allocates less memory when packing
- Floats and doubles now allocate less memory when packing/unpacking

## 2.3.1 (2018-05-19)

### Added
- Added better errors for deserialization when it fails to parse correctly
- Tests for naming strategies

### Changed
- Renamed some files internally for readability
- Refactored JsonCoverter for readability

## 2.3.0 (2018-05-10)

### Added
- Added file `CamelCaseNamingStrategy` for out of the box compatibility with PHP

### Changed
- The Formatter now requires that you add `System.Serializable` attribute to the class in order to serialize (you can force it to serialize without the attribute by setting `SerializationContext.MapOptions.RequireSerializableAttribute` to false)

### Fixed
- Fixed a case where circular referenced Maps were causing apps to crash
- Fixed a bug where multi-byte strings were not being packed correctly
- Rename `SerializationContext.JsonOptions.valueSeparator` to pascal case (`ValueSeparator`)

## 2.2.1 (2018-05-08)

### Fixed
- Formatter will return `null` if `null` is given as a argument for `Deserialize<T>(byte[])` and `AsJson(byte[])`

## 2.2.0 (2018-04-28)

### Changed
- Changed naming convention to match that of [MSDN's general naming conventions](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/general-naming-conventions)
- INamingStrategy now includes MapDefinition as a second argument

## 2.1.1 (2018-04-24)

### Fixed
- Remove `Vector2Int` and `Vector3Int` from versions older than 2017.2

## 2.1.0 (2018-04-24)

### Added
- Added an option to map so empty array can be deserialized as map (compatibility with `msgpack-php`)

### Fixed
- Zero length bytes no longer throw an error on Unpack (will return null instead)
- Fixed issue when DateTimeHandler threw an error if epoch time was represented as `long`/`ulong` 

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
