using System;
using System.Xml.XPath;
using System.Xml;

namespace textxpath
{
    class XPathTest
    {
        static void Main(string[] args)
        {
            XPathDocument doc = new XPathDocument("airports.xml");
            XPathNavigator nav = doc.CreateNavigator();

            XPathNavigator airport = nav.SelectSingleNode("/airports/airport[IATA='LAX']");
            airport.MoveToChild("Latitude", "");
            airport.MoveToParent();
            airport.MoveToChild("Longitude", "");
            Console.WriteLine(airport.Value);
        }
    }
}
