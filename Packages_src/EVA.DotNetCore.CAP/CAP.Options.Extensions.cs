// Copyright (c) .NET Core Community. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using DotNetCore.CAP;
using DotNetCore.CAP.Infrastructure;
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    //TODO change name
    public static class AdditionalCapOptionsExtensions
    {
        /// <summary>
        /// Add json converters for event content objects
        /// </summary>
        /// <param name="options">Options</param>
        /// <param name="jsonConverters">JsonDeSerializers</param>
        /// <returns></returns>
        public static CapOptions AddConverters(this CapOptions options, IList<JsonConverter> jsonConverters)
        {
            if (jsonConverters == null)
            {
                throw new ArgumentNullException(nameof(jsonConverters));
            }

            var settings = Helper.SerializerSettings;
            settings.Converters = settings.Converters.Concat(jsonConverters).ToList();

            return options;
        }
    }
}