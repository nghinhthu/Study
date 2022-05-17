using Newtonsoft.Json;

namespace FirebaseCloudMessaging.Models
{
    public class ResponseModel
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("message")]
        public bool Message { get; set; }
    }
}
