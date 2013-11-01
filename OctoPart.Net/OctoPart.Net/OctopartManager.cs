using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;

namespace OctoPart.Net
{
    public class OctopartManager
    {
        public string BaseUrl { get; private set; }

        private RestClient _client;

        private readonly Dictionary<Type, String> urls = new Dictionary<Type, string>
        {
            {typeof (Part), "parts"},
            {typeof (Brand), "brands"},
            {typeof (Category), "categories"},
            {typeof (Seller), "sellers"},
        };

        public OctopartManager()
        {
            BaseUrl = "http://octopart.com/api/v3/";
            _client = new RestClient();
        }

        public PartsMatchResponse GetMatchObject<T>(PartsMatchQuery queries, APIArguments APIArgs, bool exact_only) where T : class, new()
        {

            var type = typeof(T);

            if (type == typeof(Part))
            {
                var request = new RestRequest(Method.GET);
                request.Resource = urls[type] + "/match";
                AddAPIOptions(queries, APIArgs, request);

                return Execute<PartsMatchResponse>(request);
            }
            else
            {
                throw new Exception("Only Part Item is Supported");
            }

        }

        public SearchResponse GetSearchObject<T>(SearchAPIArguments APIArgs) where T : class, new()
        {
            var type = typeof(T);

            if (!urls.ContainsKey(type)) return null;

            var request = new RestRequest(Method.GET);
            request.Resource = urls[type] + "/search";
            AddAPIOptions(APIArgs, request);

            IRestResponse response = Execute(request);

            return Deserialize<SearchResponse>(response);
        }

        public T GetObject<T>(string uid, APIArguments options) where T : class, new()
        {
            var type = typeof(T);

            if (!urls.ContainsKey(type)) return null;

            var request = new RestRequest(Method.GET);
            request.Resource = urls[type] + "/" + uid;
            AddAPIOptions(options, request);

            return Execute<T>(request);
        }

        public Dictionary<string, Endpoint> GetMultiObject<T>(GetMultiAPIArguments options) where T : class, new()
        {
            var type = typeof(T);

            if (!urls.ContainsKey(type)) return null;

            var request = new RestRequest(Method.GET);
            request.Resource = urls[type] + "/get_multi";
            AddAPIOptions(options, request);

            IRestResponse response = Execute(request);

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.Converters.Add(new EndPointSerializer());

            return Deserialize<Dictionary<string, Endpoint>>(response, serializerSettings);
        }

        private static void AddAPIOptions(SearchAPIArguments APIArgs, RestRequest request)
        {
            request.AddParameter("q", APIArgs.q);
            request.AddParameter("start", APIArgs.start);
            request.AddParameter("limit", APIArgs.limit);
            if (APIArgs.sortby != null)
            {
                request.AddParameter("sortby", APIArgs.sortby);
            }

            request.AddParameter("apikey", APIArgs.apikey);
            request.AddParameter("pretty_print", APIArgs.pretty_print);
            request.AddParameter("suppress_status_codes", APIArgs.suppress_status_codes);

            if (APIArgs.datasheets == true) request.AddParameter("include[]", "datasheets");
            if (APIArgs.compliance_documents == true) request.AddParameter("include[]", "compliance_documents");
            if (APIArgs.descriptions == true) request.AddParameter("include[]", "descriptions");
            if (APIArgs.specs == true) request.AddParameter("include[]", "specs");
            if (APIArgs.imagesets == true) request.AddParameter("include[]", "imagesets");
            if (APIArgs.category_uids == true) request.AddParameter("include[]", "category_uids");
            if (APIArgs.external_links == true) request.AddParameter("include[]", "external_links");

            foreach (string Show in APIArgs.ShowDirectives)
            {
                request.AddParameter("show[]", Show);
            }
            foreach (string Hide in APIArgs.HideDirectives)
            {
                request.AddParameter("hide[]", Hide);
            }

        }

        private static void AddAPIOptions(GetMultiAPIArguments APIArgs, RestRequest request)
        {
            foreach (string uid in APIArgs.uids)
            {
                request.AddParameter("uid[]", uid);
            }

            request.AddParameter("apikey", APIArgs.apikey);
            request.AddParameter("pretty_print", APIArgs.pretty_print);
            request.AddParameter("suppress_status_codes", APIArgs.suppress_status_codes);

            if (APIArgs.datasheets == true) request.AddParameter("include[]", "datasheets");
            if (APIArgs.compliance_documents == true) request.AddParameter("include[]", "compliance_documents");
            if (APIArgs.descriptions == true) request.AddParameter("include[]", "descriptions");
            if (APIArgs.specs == true) request.AddParameter("include[]", "specs");
            if (APIArgs.imagesets == true) request.AddParameter("include[]", "imagesets");
            if (APIArgs.category_uids == true) request.AddParameter("include[]", "category_uids");
            if (APIArgs.external_links == true) request.AddParameter("include[]", "external_links");

            foreach (string Show in APIArgs.ShowDirectives)
            {
                request.AddParameter("show[]", Show);
            }
            foreach (string Hide in APIArgs.HideDirectives)
            {
                request.AddParameter("hide[]", Hide);
            }

        }

        private static void AddAPIOptions(APIArguments APIArgs, RestRequest request)
        {
            request.AddParameter("apikey", APIArgs.apikey);
            request.AddParameter("pretty_print", APIArgs.pretty_print);
            request.AddParameter("suppress_status_codes", APIArgs.suppress_status_codes);

            if (APIArgs.datasheets == true) request.AddParameter("include[]", "datasheets");
            if (APIArgs.compliance_documents == true) request.AddParameter("include[]", "compliance_documents");
            if (APIArgs.descriptions == true) request.AddParameter("include[]", "descriptions");
            if (APIArgs.specs == true) request.AddParameter("include[]", "specs");
            if (APIArgs.imagesets == true) request.AddParameter("include[]", "imagesets");
            if (APIArgs.category_uids == true) request.AddParameter("include[]", "category_uids");
            if (APIArgs.external_links == true) request.AddParameter("include[]", "external_links");

            foreach (string Show in APIArgs.ShowDirectives)
            {
                request.AddParameter("show[]", Show);
            }
            foreach (string Hide in APIArgs.HideDirectives)
            {
                request.AddParameter("hide[]", Hide);
            }
        }

        private static void AddAPIOptions(PartsMatchQuery queries, APIArguments APIArgs, RestRequest request)
        {
            string CompleteQuery = "[" + JsonConvert.SerializeObject(queries) + "]";
            request.AddParameter("queries", CompleteQuery);

            AddAPIOptions(APIArgs, request);

        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient { BaseUrl = BaseUrl };
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new ApplicationException(message, response.ErrorException);
                throw twilioException;
            }
            return response.Data;
        }

        public IRestResponse Execute(RestRequest request)
        {
            var client = new RestClient { BaseUrl = BaseUrl };

            IRestResponse response = client.Execute(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new ApplicationException(message, response.ErrorException);
                throw twilioException;
            }
            //Need to check for errors
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Exception();
            }

            return response;
        }

        private T Deserialize<T>(IRestResponse response) where T : class, new()
        {

            return Deserialize<T>(response, null);
        }

        private T Deserialize<T>(IRestResponse response, JsonSerializerSettings settings) where T : class, new()
        {
            var content = response.Content; // raw content as string
            return JsonConvert.DeserializeObject<T>(content, settings);
        }
    }
}
