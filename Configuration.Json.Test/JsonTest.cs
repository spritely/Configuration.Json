// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonTest.cs">
//   Copyright (c) 2015. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Configuration.Json.Test
{
    using Newtonsoft.Json;
    using NUnit.Framework;
    using System.Security;

    [TestFixture]
    public class JsonTest
    {
        private enum TestEnum
        {
            FirstType
        }

        [Test]
        public void Serializer_writes_camel_cased_properties()
        {
            var result = JsonConvert.SerializeObject(new CamelCasedPropertyTest(), Json.SerializerSettings);

            Assert.That(result, Is.EqualTo(@"{
  ""testName"": ""Hello""
}"));
        }

        [Test]
        public void Serializer_writes_camel_cased_enumerations()
        {
            var result = JsonConvert.SerializeObject(new CamelCasedEnumTest(), Json.SerializerSettings);

            Assert.That(result, Is.EqualTo(@"{
  ""first"": ""firstType""
}"));
        }

        private class CamelCasedPropertyTest
        {
            public string TestName = "Hello";
        }

        private class CamelCasedEnumTest
        {
            public TestEnum First = TestEnum.FirstType;
        }

        [Test]
        public void Serializer_reads_and_writes_SecureString_types()
        {
            var serializedValue = @"{
  ""secure"": ""password""
}";
            var deserialized = JsonConvert.DeserializeObject<SecureStringTest>(serializedValue, Json.SerializerSettings);

            var result = JsonConvert.SerializeObject(deserialized, Json.SerializerSettings);

            Assert.That(result, Is.EqualTo(serializedValue));
        }

        private class SecureStringTest
        {
            public SecureString Secure;
        }
    }
}
