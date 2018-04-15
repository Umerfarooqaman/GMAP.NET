using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace GMAP.NET.Utils
{

    internal class SnakeCasePropertyNameContractResolver : DefaultContractResolver
    {
        /// <summary>Resolves the name of the property.</summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Resolved name of the property.</returns>
        protected override string ResolvePropertyName(string propertyName)
        {
            for (var i = propertyName.Length - 1; i >= 0; i--)
            {
                if (propertyName != null && (i > 0 && char.IsUpper(propertyName[i])))
                {
                    propertyName = propertyName.Insert(i, "_");
                }
            }
            return propertyName?.ToLower();
        }

       
    }
}

