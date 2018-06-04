using System;

namespace FlightSimulator.Core.Common
{
    public class GPSUtility
    {
        /// <summary>
        /// Calculate the distance between two GPS points
        /// </summary>
        /// <returns>The distance in km</returns>
        public static double DistanceTo(double latitudePoint1, double longitudePoint1, double latitudePoint2, double longitudePoint2)
        {
            var rlat1 = Math.PI * latitudePoint1 / 180;
            var rlat2 = Math.PI * latitudePoint2 / 180;
            var rlon1 = Math.PI * longitudePoint1 / 180;
            var rlon2 = Math.PI * longitudePoint2 / 180;

            var theta = longitudePoint1 - longitudePoint2;
            var rtheta = Math.PI * theta / 180;

            var dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            dist = dist * 1.609344; 
            return dist;
        }
    }
}
