using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace WordFilter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static HashSet<string> functionWords = new HashSet<string>{ "the", "a", "an", 
            "is", "am", "are", "was", "were", "will", "be",
            "this", "that", "which", "then", "than",
            "in", "on", "of", "for", "by", "with", "if",
            "and", "but", "or",
            "he", "she", "it", "him", "her", "his", "hers", "its",
            "how", "who", "what", "where", "when"};

        public string WordFilter(string input)
        {
            Regex reg = new Regex("([A-z]+)");
            MatchCollection matches = reg.Matches(input);
            StringBuilder sb = new StringBuilder();

            foreach(Match match in matches)
            {
                string word = match.Value.ToLower();
                if (!functionWords.Contains(word))
                {
                    sb.Append(word);
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }
    }
}
