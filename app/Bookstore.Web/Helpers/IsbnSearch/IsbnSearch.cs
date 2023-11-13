using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Bookstore.Web.Helpers.IsbnSearch
{
    /***
     * 
     * This demonstrates an external dependency (open ISBN).
     * It is written badly on purpose!!
     * I know WebRequest is deprecated, and this code is crummy!
     *
     */
    public class IsbnSearch
    {
        public const string ISBN_SEARCH_TEMPLATE = "https://openlibrary.org/api/books?bibkeys=ISBN:{0}&jscmd=details&format=json";

        public async Task<IsbnSearchResult> GetIsbnResults(string isbn)
        {
            try
            {
                WebRequest request = WebRequest.Create(string.Format(ISBN_SEARCH_TEMPLATE, isbn));
                request.Method = "GET";
                var response = await request.GetResponseAsync();

                var dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                var token = JObject.Parse(responseFromServer).SelectToken(string.Format("ISBN:{0}.details", isbn));

                var deserializedResult = token.ToObject<IsbnSearchResult>();

                return deserializedResult;
            }
            catch(Exception ex) 
            {
                //Log something here
                return new IsbnSearchResult();

            }

        }

    }
}