using GoogleMapDistanceMatrix.Exceptions;

namespace GMAP.NET.Utils
{
    public class RequestLocation
    {

        public double Latitude { get; }
        public double Longitude { get; }

        public string location { get; }

        public LocationType? LocationType { get; }

        public RequestLocation(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            LocationType = null;
        }

        public RequestLocation(string location, LocationType locationType)
        {
            if (locationType is Utils.LocationType.Coordinates)
            {
                throw new InvalidOptionsException("Cannot set Location type to Coordinate .");
            }
            this.location = location;
            this.LocationType = locationType;

        }

        public string ToLocationString()
        {
            switch (LocationType)
            {

                case Utils.LocationType.Address:
                    return location;

                case Utils.LocationType.PlaceID:
                    return "place_id" + location;

                case Utils.LocationType.Polyline:
                    return "enc:" + location + ":";

                default:
                    return Latitude + "," + Longitude;

            }

        }



    }

    public enum LocationType
    {
        Address,
        PlaceID,
        Polyline,
        Coordinates
    }
}