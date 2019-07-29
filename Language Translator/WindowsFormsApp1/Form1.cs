using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp1
{


    public partial class Form1 : Form
    {
        private List<String> AvailLangs;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var response = Requestservice(string.Format(AppCache.UrlDetectSrcLanguage, AppCache.API, textBox2.Text));
            var dict = JsonConvert.DeserializeObject<IDictionary>(response.Content);

            var statusCode = dict["code"].ToString();
            if  (statusCode.Equals("200"))
            {
                label1.Text = dict["lang"].ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var response = Requestservice(string.Format(AppCache.UrlTranslateLanguage,AppCache.API,textBox2.Text,AvailLangs[comboBox1.SelectedIndex]));
            var dict = JsonConvert.DeserializeObject<IDictionary>(response.Content);
            var statusCode = dict["code"].ToString();
            if (statusCode.Equals("200"))
            {

               textBox1.Text = string.Join(",",dict["text"]);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var response = Requestservice(string.Format(AppCache.UrlGetAvailableLanguages,AppCache.API,label1.Text));
            var dict = JsonConvert.DeserializeObject<IDictionary>(response.Content);
            foreach(DictionaryEntry entry in dict)
            {
                if (entry.Key.Equals("langs"))
                {
                    var availableConverts = (JObject)entry.Value;
                    AvailLangs = new List<string>();

                    comboBox1.Items.Clear();
                    foreach (var Lang in availableConverts)
                    {
                        if(!Lang.Equals(label1.Text))
                        {
                            comboBox1.Items.Add(Lang.Value);
                            AvailLangs.Add(Lang.Key);

                        }
                    }

                }
            }

        }

        private IRestResponse Requestservice(string strUrl)
        {
            var client = new RestClient()
            {
                BaseUrl = new Uri(strUrl)

            };
            var request = new RestRequest()
            {
                Method = Method.GET
            };
            return client.Execute(request);

         

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
