No longer maintained as a separate repository. It is now a recipe. See: https://github.com/spritely/Recipes/blob/master/Recipes/JsonConfiguration.cs


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
