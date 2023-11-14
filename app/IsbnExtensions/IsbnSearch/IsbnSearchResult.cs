using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsbnExtensions.IsbnSearch
{

    public class IsbnSearchResult
    {
        [JsonProperty("publishers")]
        public List<string> Publishers { get; set; } = new List<string>();

        [JsonProperty("number_of_pages")]
        public int? NumberOfPages { get; set; }

        [JsonProperty("publish_date")]
        public string PublishDate { get; set; }

        [JsonProperty("lc_classifications")]
        public List<string> LcClassifications { get; set; } = new List<string>();
    }
}