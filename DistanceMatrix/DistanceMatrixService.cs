using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using GMAP.NET.DistanceMatrix;
using GMAP.NET.DistanceMatrix.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GoogleMapDistanceMatrix
{
    public class DistanceMatrixService : IDistanceMatrixService
    {
        private string key;

        private string Baseuri = "https://maps.googleapis.com/maps/api/distancematrix/json?";

        public string Key { get => key; set => key = value; }

        private HttpClient _httpClient;

        public DistanceMatrixService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<DistanceMatrixResult> SendDistanceMatrixRequestAsync(DistanceMatrixRequest request)
        {
            Uri _uri = new Uri(Baseuri + request.ToURIString() + "&key=" + key);



            var responce =await _httpClient.GetAsync(_uri);

            var json =await responce.Content.ReadAsStringAsync();


            if (responce.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<DistanceMatrixResult>(json, new JsonSerializerSettings()
                {

                    ContractResolver = new SnakeCasePropertyNameContractResolver()
                });

                result.HttpStatusCode = responce.StatusCode;

                return result;
            }
            else
            {
                return new DistanceMatrixResult() { HttpStatusCode = responce.StatusCode };
            }



        }

        public DistanceMatrixResult SendDistanceMatrixRequest(DistanceMatrixRequest request)
        {
            Uri _uri = new Uri(Baseuri + request.ToURIString() + "&key=" + key);



            var responce = _httpClient.GetAsync(_uri);

            var json = responce.Result.Content.ReadAsStringAsync();



            if (responce.Result.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<DistanceMatrixResult>(json.Result, new JsonSerializerSettings()
                {

                    ContractResolver = new SnakeCasePropertyNameContractResolver()
                });

                result.HttpStatusCode = responce.Result.StatusCode;

                return result;
            }
            else
            {
                    return new DistanceMatrixResult(){HttpStatusCode = responce.Result.StatusCode};
            }





        }


    }
}
