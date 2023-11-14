using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dialUp
{
    public partial class Form1 : Form
    {
        int time = 0;
        SoundPlayer player=new SoundPlayer();
        public Form1()
        {
            InitializeComponent();
            Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled; //classic theme

        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.SoundLocation= @".\dial.wav";
            player.Load();
            progressBar1.Maximum = 28;
            player.Play();
            button1.Enabled = false;

            if (timer1.Enabled == false)
            {
                timer1.Start();
            }

            label1.Text = "dialing...";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            progressBar1.Increment(1);

            if (time >= 25)
            {
                label1.Text = "connecting...";
            }
            if (time > 27)
            {
                label1.Text = "connected!";
            }
            if(time > 29)
            {
                timer1.Stop();
                Close();
            }
        }
    }
}
