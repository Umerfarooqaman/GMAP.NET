using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMAP.NET.Enums;
using GMAP.NET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GMAP.NET.DistanceMatrix.Utils
{
    public class DistanceMatrixRequest
    {
       public DistanceMatrixRequest()
       {
           Origins = new List<RequestLocation>();
           Destinations=new List<RequestLocation>();
       }

        public List<RequestLocation> Origins;
        public List<RequestLocation> Destinations;



        [JsonConverter(typeof(StringEnumConverter))]
        public TravelMode? Mode { get; set; }
        /// <summary>
        /// <returns></returns>
        /// </summary>
        public string Language { get; set; }


        public string Region { get; set; }


        [JsonConverter(typeof(StringEnumConverter))]
        public Restrictions? Avoid { get; set; }


        [JsonConverter(typeof(StringEnumConverter))]
        public Unit? units { get; set; }


        public DateTime? ArrivalTime { get; set; }

        public DateTime? DepartureTime { get; set; }


        [JsonConverter(typeof(StringEnumConverter))]
        public TrafficModel? TrafficModel { get; set; }


        [JsonConverter(typeof(StringEnumConverter))]
        public TransitMode? TransitMode { get; set; }


        [JsonConverter(typeof(StringEnumConverter))]
        public TransitRoutingPreference? preference { get; set; }


        public string ToURIString()
        {
            string uri = "origins=";
            foreach (var orig in Origins)
            {
                if (orig != Origins.First())
                {
                    uri += "|";

                }
                uri += orig.ToLocationString();
            
            }

            uri += "&destinations=";
            foreach (var orig in Destinations)
            {
                if (orig != Destinations.First())
                {
                    uri += "|";

                }
                uri += orig.ToLocationString();

            }

            if (string.IsNullOrEmpty(Language))
            {
                uri += "&language=" + Language;
            }

            if (Mode!=null)
            {

                uri += "&mode=" + Mode.ToString();
            }

            if (Avoid!=null)
            {
                uri += "&avoid=" + Avoid.ToString();
            }

            if (string.IsNullOrWhiteSpace(Region))
            {
                uri += "&region=" + Region;
            }

            if (TrafficModel!=null)
            {
                uri += "&trafficmodel=" + TrafficModel.ToString();
            }

            if (TransitMode!=null)
            {
                uri += "&transit=" + TransitMode.ToString();
            }

            if (preference!=null)
            {
                uri += "&transit_routing_preference=" + preference.ToString();
            }

            return uri;
        }

    }
}
