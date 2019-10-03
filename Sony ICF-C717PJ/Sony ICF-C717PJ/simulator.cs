using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sony_ICF_C717PJ
{
    public partial class simulator : Form
    {
        DateTime date;
        DayOfWeek weekDay;
        bool weekendActive;
        bool summerTimeAuto;
        bool summerTime;
        bool alarmActive;

        const int SUMMER_MONTH = 3;
        const int WINTER_MONTH = 11;

        public simulator()
        {
            InitializeComponent();
        }

        private void simulator_Load(object sender, EventArgs e)
        {
            date = DateTime.Now;
            weekDay = date.DayOfWeek;
            weekendActive = false;
            summerTimeAuto = false;
            summerTime = false;
        }

        private void checkAutoSummerTime()
        {
            // Check if there is currently a automatic summer time and if we are currently in
            if (summerTimeAuto == true && date.Month >  SUMMER_MONTH && date.Month < WINTER_MONTH)
            {
                summerTime = true;
            }
        }

        private void checkWeekend()
        {
            // Check if the alarm is actived on weekend and if we are on the weekend
            if (alarmActive == true || (weekendActive == true && weekDay > DayOfWeek.Friday))
            {

            }
        }

        private int getTemperature()
        {
            // Get a random temperature (Using a API seems too complex)
            Random random = new Random();

            int temperature = random.Next(0, 31);

            return temperature;
        }
    }   
}
