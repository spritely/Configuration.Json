// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Json.cs">
//   Copyright (c) 2015. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Configuration.Json
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    ///     Static container for Json settings defaults for all queries.
    /// </summary>
    public static class Json
    {
        /// <summary>
        ///     Initializes static members of the <see cref="Json" /> class.
        /// </summary>
        static Json()
        {
            SerializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter>
                {
                    new StringEnumConverter { CamelCaseText = true },
                    new SecureStringJsonConverter()
                }
            };
        }

        /// <summary>
        ///     Gets or sets the JSON serialization settings for Tearsheets commands.
        /// </summary>
        /// <value>
        ///     The JSON serialization settings for Tearsheets commands.
        /// </value>
        public static JsonSerializerSettings SerializerSettings { get; set; }
    }
}
