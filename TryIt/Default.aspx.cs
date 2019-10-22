using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace TryIt
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void FilterSubmit_Click(object sender, EventArgs e)
        {
            WordFilterService.Service1Client service1Client = new WordFilterService.Service1Client();
            FilterText.Text = service1Client.WordFilter(FilterText.Text);
        }

        protected void top10Submit_Click1(object sender, EventArgs e)
        {
            Top10WordsService.Service1Client service1Client = new Top10WordsService.Service1Client();
            string[] words = service1Client.Top10Words(top10URL.Text);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string word in words)
            {
                stringBuilder.Append(word);
                stringBuilder.Append(Environment.NewLine);
            }
            top10Results.Text = stringBuilder.ToString();
        }
    }
}