namespace RestSharp.Newtonsoft.Json.NetCore
{
    using System.IO;
    using global::Newtonsoft.Json;
    using RestSharp.Serializers;
    using JsonSerializer = global::Newtonsoft.Json.JsonSerializer;

    public class NewtonsoftJsonSerializer : ISerializer
    {
        private readonly JsonSerializer serializer;


        /// <summary>
        /// Default serializer
        /// </summary>
        public NewtonsoftJsonSerializer()
        {
            ContentType = "application/json";
            this.serializer = new JsonSerializer();
            this.serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
            this.serializer.NullValueHandling = NullValueHandling.Include;
            this.serializer.DefaultValueHandling = DefaultValueHandling.Include;
        }

        /// <summary>
        /// Default serializer with overload for allowing custom Json.NET settings
        /// </summary>
        public NewtonsoftJsonSerializer(JsonSerializer serializer)
        {
            ContentType = "application/json";
            this.serializer = serializer;
        }

        /// <summary>
        /// Serialize the object as JSON
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns>JSON as String</returns>
        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';

                    this.serializer.Serialize(jsonTextWriter, obj);

                    var result = stringWriter.ToString();
                    return result;
                }
            }
        }

        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string DateFormat { get; set; }
        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string RootElement { get; set; }
        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// Content type for serialized content
        /// </summary>
        public string ContentType { get; set; }
    }
}