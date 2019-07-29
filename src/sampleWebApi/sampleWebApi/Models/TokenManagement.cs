using Newtonsoft.Json;

namespace sampleWebApi.Models
{
    public class TokenManagement
    {

        [JsonProperty("authorizationUrl")]
        public string AuthorizationUrl { get; set; }

        [JsonProperty("tokenUrl")]
        public string tokenUrl { get; set; }

        [JsonProperty("authority")]
        public string Authority { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("audience")]
        public string Audience { get; set; }

        [JsonProperty("accessExpiration")]
        public int AccessExpiration { get; set; }

        [JsonProperty("refreshExpiration")]
        public int RefreshExpiration { get; set; }
        [JsonProperty("appName")]
        public string AppName { get; set; }
        [JsonProperty("realm")]
        public string Realm { get; set; }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }
    }
}