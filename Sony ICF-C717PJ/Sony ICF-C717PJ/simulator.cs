using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Sony_ICF_C717PJ
{
    public partial class simulator : Form
    {
        Alarmes ListAlarmes = new Alarmes();


        public simulator()
        {
            InitializeComponent();

         
        }


        private void alarm_a_toggle_btn_MouseHover(object sender, EventArgs e)
        {

        }

        private void alarm_a_toggle_btn_Click(object sender, EventArgs e)
        {
            ListAlarmes.ListAlarmes[0].Activate();
        }

        private void waves_button_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.waves1);
            player.Play();
        }

        private void birds_button_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.birds1);
            player.Play();
        }

        private void rain_button_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.rain1);
            player.Play();
        }

        private void river_button_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.rain1);
            player.Play();
        }

        private void aquatic_btn_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.aquarium);
            player.Play();
        }

        private void alarm_off_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void simulator_Load(object sender, EventArgs e)
        {
   
        }
    }
}
