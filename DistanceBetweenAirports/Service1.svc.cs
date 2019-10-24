using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace DistanceBetweenAirports
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public double Distance(string airport1, string airport2)
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/airports.xml");
            XPathDocument doc = new XPathDocument(path);
            XPathNavigator nav = doc.CreateNavigator();

            double lat1, long1, lat2, long2;
            XPathNavigator airport = nav.SelectSingleNode(string.Format("/airports/airport[IATA ='{0}']", airport1));
            airport.MoveToChild("Latitude", "");
            lat1 = double.Parse(airport.Value);
            airport.MoveToParent();
            airport.MoveToChild("Longitude", "");
            long1 = double.Parse(airport.Value);
            ValueTuple<double, double> v = new ValueTuple<double, double>(lat1, long1);

            airport = nav.SelectSingleNode(string.Format("/airports/airport[IATA = '{0}']", airport2));
            airport.MoveToChild("Latitude", "");
            lat2 = double.Parse(airport.Value);
            airport.MoveToParent();
            airport.MoveToChild("Longitude", "");
            long2 = double.Parse(airport.Value);

            return greatCircle(lat1, long1, lat2, long2);           
        }

        private double greatCircle(double lat1, double long1, double lat2, double long2)
        {
            double radius_of_earth = 6371;
            double lat1_rad = degreesToRads(lat1),
                lat2_rad = degreesToRads(lat2),
                long1_rad = degreesToRads(long1),
                long2_rad = degreesToRads(long2);
            return radius_of_earth * Math.Acos(Math.Sin(lat1_rad) * Math.Sin(lat2_rad) +
                Math.Cos(lat1_rad) * Math.Cos(lat2_rad) * Math.Cos(long2_rad - long1_rad));
        }

        private double degreesToRads(double degrees)
        {
            return degrees * Math.PI / 180;
        }


    }
}