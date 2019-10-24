using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.XPath;

namespace FewestConnections
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class FewestConnections : IFewestConnections
    {
        public string calculate(string airport1, string airport2)
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/routes.xml");
            XPathDocument doc = new XPathDocument(path);
            XPathNavigator nav = doc.CreateNavigator();

            HashSet<string> visited = new HashSet<string>();
            Queue<Stack<string>> allPaths = new Queue<Stack<string>>();
            Stack<string> head = new Stack<string>();
            head.Push(airport1);
            visited.Add(airport1);

            allPaths.Enqueue(head);
            bool found = false;

            while(allPaths.Count > 0 && !found)
            {
                head = allPaths.Dequeue();
                string currentAirport = head.Peek();

              
                    XPathNodeIterator neighbors = nav.Select(string.Format("/routes/route[Source='{0}']/Dest", currentAirport));
                    while (neighbors.MoveNext() && !found)
                    {
                        string neighbor = neighbors.Current.Value;
                        if (neighbor.Equals(airport2))
                        {
                            head.Push(neighbor);
                            found = true;
                        }
                        else if (!visited.Contains(neighbor))
                        {
                            Stack<string> newPath = new Stack<string>(new Stack<string> (head));
                            newPath.Push(neighbor);
                            allPaths.Enqueue(newPath);
                            visited.Add(neighbor);
                        }
                    }
                

            }
            if (found)
            {
                Stack<string> reverser = new Stack<string>();
                while (head.Count > 0)
                {
                    reverser.Push(head.Pop());
                }
                StringBuilder sb = new StringBuilder();
                foreach (string s in reverser)
                {
                    sb.AppendLine(s);
                }
                return sb.ToString();
            }
            else
            {
                return "No path found";
            }



        }
    }
}
