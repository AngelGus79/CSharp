using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace MakeUIResponsive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            label1.Text = "Processing the information";
            await ComplicatedMethod();
            
            
        }

        private Task ComplicatedMethod()
        {
            Task myTask = Task.Run(() =>
            {
               
                for (int i = 0; i < 1000; i++)
                {
                    Thread.Sleep(10);
                    

                }
               
            });

            return myTask;
            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Execute Normal Method Asynchronously";
            await ExecuteNormalMethod();
        }

        private async Task ExecuteNormalMethod()
        {
            await ExecuteComplicatedMethod();
        }

        private Task ExecuteComplicatedMethod()
        {
            Task myTask = Task.Run(() =>
            {
                Thread.Sleep(5000);
            });

            return myTask;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int result = await ComplicatedReturnValueMethod();

            label1.Text = "The number returned is " + result.ToString();
        }

        private Task<int> ComplicatedReturnValueMethod()
        {
            var myTask = Task.Run(() =>
            {
                Thread.Sleep(5000);
                return 10;
            });

            return myTask;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            Func<Task> myLamdaMethod = (async () =>
            {
                await myComplicatedMethod();
            });

            await myLamdaMethod();
            label1.Text = "hello my lamda method";
        }

        private Task myComplicatedMethod()
        {
            Task myTask = Task.Run(() =>
            {
                Thread.Sleep(4000);
            });

            return myTask;
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            //            Unlike Thread.Sleep, Task.Delay doesn’t block the current thread.Instead it makes a logical delay for a
            //specified period of time.Task.Delay is intended to run asynchronously.Await is used with Task.Delay
            //because it returns a Task.

            label1.Text = "Hello Task.Delay";
            await Task.Delay(5000);
            label1.Text = "Bye Task.Delay";
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            label1.Text = "The Data is processing...";

            Task myTask = Task.Run( () => {
                this.BeginInvoke(new Action(() =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        listBox1.Items.Add(i);
                    }
                }));


           });

            await myTask;

            label1.Text = "";

        }
    }
}
