using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Burazer
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebRequest wr = WebRequest.Create(textBox1.Text);
            wr.Credentials = CredentialCache.DefaultCredentials;
            wr.Method = "POST";

            string postData = "This is a test that posts this string to a Web server";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            wr.ContentType = "application/x-www-form-urlencoded";

            Stream dataStream = wr.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse wrs = wr.GetResponse();
            Stream data = wrs.GetResponseStream();
            string tekst;
            using (StreamReader rdr = new StreamReader(data, Encoding.UTF8))
            {
                tekst = rdr.ReadToEnd();
            }
            textBox2.Text = tekst;



        }
    }
}
