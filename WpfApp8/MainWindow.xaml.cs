using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
namespace asdasdasd
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();





        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            //Command.Process process = new Command.Process();
            //Models.Properties properties = new Models.Properties();
            //properties.Name = nameTb.Text;
            //properties.Surname = surnameTb.Text;
            //properties.Email = emailTb.Text;
            if (JsonRb.IsChecked.Value)
            {
                string a = nameTb.Text + " - " + surnameTb.Text + " - " + emailTb.Text;
                var serializer = new JsonSerializer();
                using (var sw = new StreamWriter("Information.json"))
                {
                    using (var jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                        serializer.Serialize(jw, a);
                    }
                }
                //process.Start(2,properties);
            }
            else if (XmlRb.IsChecked.Value)
            {
                string a = nameTb.Text + " - " + surnameTb.Text + " - " + emailTb.Text;
                var xml = new XmlSerializer(typeof(string));
                using (var fs = new FileStream("Translator.xml", FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, a);
                }
                // process.Start(1,properties);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            nameTb.Text = "";
            surnameTb.Text = "";
            emailTb.Text = "";

        }
    }
}
