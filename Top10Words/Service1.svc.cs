using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Top10Words
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string[] Top10Words(string url)
        {
            string text = getAllText(url);
            Dictionary<string, int> wordsAndCounts = parseText(text);
            

            SortedList<int, string> sortedWords = new SortedList<int, string>(11, new intComparer());

            foreach (KeyValuePair<string, int> kv in wordsAndCounts)
            {
                sortedWords.Add(kv.Value, kv.Key);
                if (sortedWords.Count > 10)
                {
                    sortedWords.RemoveAt(0);
                }
            }
            string[] top10 = new string[10];
            for (int i = 9; i >= 0; i--)
            {
                KeyValuePair<int, string> kv = sortedWords.ElementAt(i);
                top10[i] = sortedWords.ElementAt(i).Value;
            }
            return top10;

        }

        private class intComparer : Comparer<int>
        {
            override
            public int Compare(int a, int b)
            {
                int comp;
                if (a == b)
                    comp = 1;
                else
                    comp = a - b;
                return comp;
            }
        }


        private string getAllText(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument doc = htmlWeb.Load(url);
            return doc.DocumentNode.SelectSingleNode("//body").InnerText;
        }

        private Dictionary<string,int> parseText(string text)
        {
            Dictionary<string, int> allWords = new Dictionary<string, int>();
            Regex reg = new Regex("([a-z]+)");
            MatchCollection matches = reg.Matches(text.ToLower());
            foreach (Match match in matches)
            {
                string s = match.Value;
                if (allWords.ContainsKey(s))
                {
                    allWords[s] += 1;
                }
                else
                {
                    allWords.Add(s, 1);
                }
            }
            return allWords;
        }


    }
}
