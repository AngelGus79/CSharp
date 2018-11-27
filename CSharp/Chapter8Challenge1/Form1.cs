using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Chapter8Challenge1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string html = textBox1.Text;

            Task myTask = Task.Run(() =>
            {
                using (WebClient client = new WebClient())
                {
                    html = client.DownloadString(html);
                }

                this.BeginInvoke(new Action(() =>
                {
                    label1.Text = html;
                }));

                
            });

            await myTask;

            
        }

        
    }
}
