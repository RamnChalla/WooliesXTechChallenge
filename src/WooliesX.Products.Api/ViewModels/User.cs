using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WooliesX.Products.Api.ViewModels
{
    /// <summary>
    /// A User view model.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        /// <example>Niel</example>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user token.
        /// </summary>
        /// <example>xyz</example>
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
