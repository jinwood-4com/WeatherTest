using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using WeatherTest.Core.Interfaces;

namespace WeatherTest.Infrastructure.Services
{
    public class RestService : IRestService
    {
        public string Get(Uri uri)
        {
            var client = new RestClient
            {
                BaseUrl = uri,
            };

            var request = new RestRequest();
            request.AddHeader("Accept-Encoding", "gzip");

            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                //something went wrong, log
            }

            return response.StatusCode == HttpStatusCode.OK ? response.Content : string.Empty;
        }

        public T Deserialize<T>(string json)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
            catch (JsonReaderException ex)
            {
                //log error
                return default(T);
            }
            catch (JsonSerializationException ex)
            {
                //log error
                return default(T);
            }
        }

        public List<T> DeserializeList<T>(string json)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<List<T>>(json);
                return obj;
            }
            catch (JsonReaderException ex)
            {
                //log
                return new List<T>();
            }
        }

    }


}
