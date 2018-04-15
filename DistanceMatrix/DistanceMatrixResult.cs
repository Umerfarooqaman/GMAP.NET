using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GMAP.NET.DistanceMatrix.Utils
{
    public class DistanceMatrixResult
    {
        public List<string> DestinationAddresses { get; set; }

        public List<string> OriginAddresses { get; set; }

        public TopLevelStatus Status { get; set; }

        public List<ElementRow> Rows { get; set; }

        public string ErrorMessage { get; set; }

        public HttpStatusCode HttpStatusCode { get; internal set; }


    }
}
