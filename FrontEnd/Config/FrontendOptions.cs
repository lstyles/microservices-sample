using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Config
{
    public class FrontendOptions
    {
        public string ResponseText { get; set; }
        public List<string> BackendServices { get; set; } = new List<string>();
    }
}
