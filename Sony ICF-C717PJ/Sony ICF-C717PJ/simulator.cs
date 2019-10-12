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
        bool summerTimeActivated;
        bool alarmActive;
        string weekendActive;
        int lightLevel;
        int displayLevel;
        int volume;
        bool alarmAActivated;
        bool alarmBActivated;

        const int SUMMER_MONTH = 3;
        const int WINTER_MONTH = 11;
        const string WEEKDAY = "weekday";
        const string WEEKEND = "weekend";
        const string EVERYDAY = "everyday";
        const string A = "A";
        const string B = "B";

        public simulator()
        {
            InitializeComponent();

            date = DateTime.Now;
            weekDay = date.DayOfWeek;
            weekendActive = WEEKDAY;
            lightLevel = 1;
            displayLevel = 1;
            volume = 10;
            alarmAActivated = false;
            alarmBActivated = false;

            checkAutoSummerTime();
            setTemperature();
            setWeekend(weekendActive);
            setHour();
        }

        private void setHour()
        {
            string hour = date.Hour.ToString();
            string minute = date.Minute.ToString();
            
            hour_unit.Text = hour;

            minuts_units.Text = minute;

            vol.Visible = true;
        }

        private void setDate(bool printYear)
        {
            string day = date.Day.ToString();
            string month = date.Month.ToString();
            string year = date.Year.ToString();
            
            if(printYear)
            {
                hour_unit.Text = year.Substring(0,2);

                minuts_units.Text = year.Substring(2);

                vol.Visible = true;
            }
            else
            {
                hour_unit.Text = month;

                minuts_units.Text = day;

                vol.Visible = true;
            }
        }

        private void setDate()
        {
            setDate(false);
        }

        private void checkAutoSummerTime()
        {
            // Check if there is currently a automatic summer time and if we are currently in
            if (date.Month >  SUMMER_MONTH && date.Month < WINTER_MONTH)
            {
                summerTime.Visible = false;
                vol.Visible = true;
            }
            else
            {
                summerTime.Visible = true;
                vol.Visible = true;
            }
        }

        private void setWeekend(string activated)
        {
            if (activated == WEEKEND)
            {
                weekendActive = WEEKEND;
                weekend.Visible = false;
                weekday.Visible = true;
                vol.Visible = true;
            }
            else if(activated == WEEKDAY)
            {
                weekendActive = WEEKDAY;
                weekend.Visible = true;
                weekday.Visible = false;
                vol.Visible = true;
            }
            else
            {
                weekendActive = EVERYDAY;
                weekend.Visible = false;
                weekday.Visible = true;
                vol.Visible = true;
            }
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

            temp_value.Text = parsedTemperature;

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

        public void setAlarm(string alarmName)
        {
            switch (alarmName)
            {
                case A:
                    if (alarmAActivated)
                    {
                        A_Alarm.Visible = true;
                        alarmAActivated = false;
                    }
                    else
                    {
                        A_Alarm.Visible = false;
                        alarmAActivated = true;
                    }
                    break;
                case B:
                    if (alarmBActivated)
                    {
                        B_Alarm.Visible = true;
                        alarmBActivated = false;
                    }
                    else
                    {
                        B_Alarm.Visible = false;
                        alarmBActivated = true;
                    }
                    break;
                default:
                    throw new Exception();
                    break;
            }
        }

        private void snooze_btn_Click(object sender, EventArgs e)
        {
            setLight();
        }

        private void date_time_zone_btn_Click(object sender, EventArgs e)
        {
            switch (displayLevel)
            {
                case 1:
                    setHour();
                    displayLevel++;
                    break;
                case 2:
                    setDate();
                    displayLevel++;
                    break;
                case 3:
                    setDate(true);
                    displayLevel = 1;
                    break;
                default:
                    throw new OverflowException();
                    break;
            }
        }

        private void vol_minus_btn_Click(object sender, EventArgs e)
        {
            if (volume > 0) {
                volume--;
                hour_unit.Text = volume.ToString();
                minuts_units.Text = "";
                vol.Visible = false;
            }
        }

        private void vol_plus_btn_Click(object sender, EventArgs e)
        {
            if (volume < 30)
            {
                volume++;
                hour_unit.Text = volume.ToString();
                minuts_units.Text = "";
                vol.Visible = false;
            }

            
        }

        private void alarm_a_toggle_btn_Click(object sender, EventArgs e)
        {
            setAlarm(A);
        }

        private void alarm_b_toggle_btn_Click(object sender, EventArgs e)
        {
            setAlarm(B);
        }
    }   
}
