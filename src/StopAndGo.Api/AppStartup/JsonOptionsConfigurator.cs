using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace StopAndGo.Api.AppStartup
{
    public static class JsonOptionsConfigurator
    {
        public static void Configure(MvcJsonOptions options)
        {
            var serializerSettings = options.SerializerSettings;
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializerSettings.Converters.Add(new StringEnumConverter());
            serializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            serializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
            serializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        }
    }
}
