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
        string weekendActive;
        bool summerTimeActived;
        bool alarmActive;
        int lightLevel;

        const int SUMMER_MONTH = 3;
        const int WINTER_MONTH = 11;
        const string WEEKDAY = "weekday";
        const string WEEKEND = "weekend";
        const string EVERYDAY = "everyday";

        public simulator()
        {
            InitializeComponent();
        }

        private void simulator_Load(object sender, EventArgs e)
        {
            date = DateTime.Now;
            weekDay = date.DayOfWeek;
            weekendActive = WEEKDAY;
            summerTimeActived = false;
            lightLevel = 1;

            checkAutoSummerTime();
            setTemperature();
            setWeekend(weekendActive);
            setHour();
        }

        private void setHour()
        {
            string hour = date.Hour.ToString();
            string minute = date.Minute.ToString();

            if (hour.Length < 2)
            {
                hour = "0" + hour;
            }

            if (minute.Length < 2)
            {
                minute = "0" + minute;
            }

            first_hour_unit.Text = hour[0].ToString();
            second_hour_unit.Text =  hour[1].ToString();

            first_minuts_units.Text = minute[0].ToString();
            second_minuts_units.Text = minute[1].ToString();
        }

        private void checkAutoSummerTime()
        {
            // Check if there is currently a automatic summer time and if we are currently in
            if (date.Month >  SUMMER_MONTH && date.Month < WINTER_MONTH)
            {
                summerTimeActived = true;
                summerTime.Visible = false;
            }
            else
            {
                summerTimeActived = false;
                summerTime.Visible = true;
            }
        }

        private void setWeekend(string activated)
        {
            if (activated == WEEKEND)
            {
                weekendActive = WEEKEND;
                weekend.Visible = false;
                weekday.Visible = true;
            }
            else if(activated == WEEKDAY)
            {
                weekendActive = WEEKDAY;
                weekend.Visible = true;
                weekday.Visible = false;
            }
            else
            {
                weekendActive = EVERYDAY;
                weekend.Visible = false;
                weekday.Visible = true;
            }
        }

        private bool checkWeekend()
        {
            bool weekendState = false;

            // Check if the alarm is actived on weekend and if we are on the weekend
            if (alarmActive == true || (weekendActive == WEEKEND && weekDay > DayOfWeek.Friday))
            {
                weekendState = true;
            }

            return weekendState;
        }

        private int setTemperature()
        {
            // Get a random temperature (Using a API seems too complex)
            Random random = new Random();

            int temperature = random.Next(0, 31);

            string parsedTemperature = temperature.ToString();

            if (parsedTemperature.Length < 2)
            {
                parsedTemperature = " " + parsedTemperature;
            }

            first_temp_value.Text = parsedTemperature[0].ToString();
            second_temp_unit.Text = parsedTemperature[1].ToString();

            return temperature;
        }

        private void setLight()
        {
            switch (lightLevel)
            {
                case 0:
                    groupBox2.BackColor = Color.White;
                    lightLevel++;
                    break;
                case 1:
                    groupBox2.BackColor = Color.DeepSkyBlue;
                    lightLevel++;
                    break;
                case 2:
                    groupBox2.BackColor = Color.Cyan;
                    lightLevel = 0;
                    break;
                default:
                    throw new OverflowException();
                    break;
            }
        }

        private void snooze_btn_Click(object sender, EventArgs e)
        {
            setLight();
        }
    }   
}
