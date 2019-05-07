using System;
using Newtonsoft.Json;

namespace DummyBinding
{
    public class DummyMessage
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }
    }
}
