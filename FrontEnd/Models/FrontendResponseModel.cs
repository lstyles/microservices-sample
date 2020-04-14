using System.Collections.Generic;

namespace Frontend.Models
{
    public class FrontendResponseModel
    {
        public string ResponseText { get; set; }
        public Dictionary<string, string> BackendResponses { get; set; } = new Dictionary<string, string>();
    }
}
