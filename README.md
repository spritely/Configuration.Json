[![Build status](https://ci.appveyor.com/api/projects/status/s1kxde16dkewk5mt/branch/master?svg=true)](https://ci.appveyor.com/project/Spritely/configuration-json/branch/master)

[![NuGet Status](http://nugetstatus.com/Spritely.Configuration.Json.png)](http://nugetstatus.com/packages/Spritely.Configuration.Json)

# Spritely.Configuration.Json
This is a simple project for harmonizing JSON settings. Specifically this is json.net serializer settings set to do camel cased properties, enumerations, and the ability to deserialize SecureString types as well. To use include the reference:

```csharp
using Spritely.Configuration.Json;
```

Then use json.net's JsonConvert while passing in Json.SerializerSettings.

```csharp
  var myObject = JsonConvert.DeserializeObject<MyObject>(serializedValue, Json.SerializerSettings);

  var serialized = JsonConvert.SerializeObject(myObject, Json.SerializerSettings);
```

That's it.
