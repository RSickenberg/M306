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
        InterfaceController controller;
        SoundPlayer player;

        public simulator()
        {
            InitializeComponent();
            this.controller = new InterfaceController(this);

            this.player = new SoundPlayer();
            player.InitializeLifetimeService();
        }

        private void alarm_a_toggle_btn_Click(object sender, EventArgs e)
        {
            ListAlarmes.ListAlarmes[0].Activate();
        }

        private void waves_button_Click(object sender, EventArgs e)
        {
            this.player = new SoundPlayer(Properties.Resources.waves1);
            player.Play();
            
        }

        private void birds_button_Click(object sender, EventArgs e)
        {
            this.player = new SoundPlayer(Properties.Resources.birds1);
            player.Play();
        }

        private void rain_button_Click(object sender, EventArgs e)
        {
            this.player = new SoundPlayer(Properties.Resources.rain1);
            player.Play();
        }

        private void river_button_Click(object sender, EventArgs e)
        {
            this.player = new SoundPlayer(Properties.Resources.rain1);
            player.Play();
        }

        private void aquatic_btn_Click(object sender, EventArgs e)
        {
            this.player = new SoundPlayer(Properties.Resources.aquarium);
            player.Play();
        }

        private void alarm_off_btn_Click(object sender, EventArgs e)
        {
            this.player.Stop();
        }

        private void audio_in_btn_Click(object sender, EventArgs e)
        {
            this.controller.ChangeVisibility(this.audio_in, !this.audio_in.Visible);
        }
  }
}
