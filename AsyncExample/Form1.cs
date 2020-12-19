using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startButtton_Click(object sender, EventArgs e)
        {
            int x = 5;
            DisplayWebResult();
            double y = Math.Pow(x, 20.0);
            txtMath.Text = y.ToString();
        }

        private async void DisplayWebResult()
        {
            lblStatus.Text = "Fetching......";
            using (HttpClient client = new HttpClient() )
            {
                Task<string> task = client.GetStringAsync("http://www.dctc.edu");
                string text = await task;
                txtResult.Text = text;
                lblStatus.Text = "Fetched......";
            }
        }
    }
}
