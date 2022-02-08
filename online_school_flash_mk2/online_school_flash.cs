using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace online_school_flash_mk2
{
    public partial class online_school_flash : Form
    {
        public online_school_flash()
        {
            InitializeComponent();
        }

        string link;
        string browser;
        bool offwebcam = false;
        bool offmic = false;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception)
            {
                MessageBox.Show("Errore nell'accedere al collegamento. Ecco il link: https://pastebin.com/XgwBqUtk");
            }
        }

        private void VisitLink()
        {
            linkLabel1.LinkColor = Color.Red;
            System.Diagnostics.Process.Start("https://pastebin.com/XgwBqUtk");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            link = textBox1.Text;

            if (checkBox1.Checked)
                browser = "Chrome";
            if (checkBox2.Checked)
                browser = "Firefox";

            if (checkBox4.Checked)
                offwebcam = true;
            if (checkBox5.Checked)
                offmic = true;

            MessageBox.Show("Dopo il tuo ok mi collegherò. Assicurati di non usare il computer nel frattempo o potresti interferire");

            Process.Start(browser);

            System.Threading.Thread.Sleep(2500);

            SendKeys.Send(link);
            SendKeys.Send("{Enter}");

            System.Threading.Thread.Sleep(4500);

            if (offwebcam)
                SendKeys.Send("^e");
            if (offmic)
                SendKeys.Send("^d");
        }
    }
}
