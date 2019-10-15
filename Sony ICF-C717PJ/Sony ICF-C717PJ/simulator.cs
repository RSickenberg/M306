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
        string weekendActiveState;
        int lightLevel;
        int displayLevel;
        int volume;
        bool alarmAActivated;
        bool alarmBActivated;
        bool DateTimeZoneHolded;
        int milisecondsHolded;
        bool changingClock;
        int DateTimeZoneOvertime;
        string currentMode;

        const int SUMMER_MONTH = 3;
        const int WINTER_MONTH = 11;
        const string WEEKDAY = "weekday";
        const string WEEKEND = "weekend";
        const string EVERYDAY = "everyday";
        const string A = "A";
        const string B = "B";
        const string CURRENT_MODE_YEAR = "year";
        const string CURRENT_MODE_MONTH = "month";
        const string CURRENT_MODE_DAY = "day";
        const string CURRENT_MODE_HOUR = "hour";
        const string CURRENT_MODE_MINUTE = "minute";
        const string ACTION_PLUS = "plus";
        const string ACTION_MOINS = "moins";

        public simulator()
        {
            lightLevel = 0;
            displayLevel = 0;
            date = DateTime.Now;
            weekDay = date.DayOfWeek;
            weekendActiveState = WEEKDAY;
            volume = 10;
            alarmAActivated = false;
            alarmBActivated = false;
            DateTimeZoneHolded = false;
            changingClock = false;

            InitializeComponent();

            checkAutoSummerTime();
            setTemperature();
            setWeekend(weekendActiveState);
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
                weekendActiveState = WEEKEND;
                weekend.Visible = false;
                weekday.Visible = true;
                vol.Visible = true;
            }
            else if(activated == WEEKDAY)
            {
                weekendActiveState = WEEKDAY;
                weekend.Visible = true;
                weekday.Visible = false;
                vol.Visible = true;
            }
            else
            {
                weekendActiveState = EVERYDAY;
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

        private void changeClock(string currentMode, string action)
        {
            switch (currentMode)
            {
                case CURRENT_MODE_YEAR:
                    if (action == ACTION_PLUS)
                    {
                        date = date.AddYears(1);
                    }
                    else if (action == ACTION_MOINS)
                    {
                        date = date.AddYears(-1);
                    }
                    else
                    {
                        throw new Exception();
                    }

                    setDate(true);
                    break;
                case CURRENT_MODE_MONTH:
                    if (action == ACTION_PLUS)
                    {
                        date = date.AddMonths(1);
                    }
                    else if (action == ACTION_MOINS)
                    {
                        date = date.AddMonths(-1);
                    }
                    else
                    {
                        throw new Exception();
                    }

                    setDate();
                    break;
                case CURRENT_MODE_DAY:
                    if (action == ACTION_PLUS)
                    {
                        date = date.AddDays(1);
                    }
                    else if (action == ACTION_MOINS)
                    {
                        date = date.AddDays(-1);
                    }
                    else
                    {
                        throw new Exception();
                    }
                    setDate();
                    break;
                case CURRENT_MODE_HOUR:
                    if (action == ACTION_PLUS)
                    {
                        date = date.AddHours(1);
                    }
                    else if (action == ACTION_MOINS)
                    {
                        date = date.AddHours(-1);
                    }
                    else
                    {
                        throw new Exception();
                    }
                    setHour();
                    break;
                case CURRENT_MODE_MINUTE:
                    if (action == ACTION_PLUS)
                    {
                        date = date.AddMinutes(1);
                    }
                    else if (action == ACTION_MOINS)
                    {
                        date = date.AddMinutes(-1);
                    }
                    else
                    {
                        throw new Exception();
                    }
                    setHour();
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
                case 0:
                    setHour();
                    displayLevel++;
                    break;
                case 1:
                    setDate();
                    displayLevel++;
                    break;
                case 2:
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

        private void holdDateTimeZone_Tick(object sender, EventArgs e)
        {
            if (DateTimeZoneHolded)
            {
                milisecondsHolded += 100;

                label1.Text = milisecondsHolded.ToString();

                if (milisecondsHolded  == 2000)
                {
                    changingClock = true;

                    DateTimeZoneHolded = false;

                    currentMode = CURRENT_MODE_YEAR;

                    setDate(true);

                    milisecondsHolded = 0;

                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        private void DateChangeTimer_Tick(object sender, EventArgs e)
        {
            if (changingClock)
            {
                DateTimeZoneOvertime += 100;

                if (DateTimeZoneOvertime == 65000)
                {
                    changingClock = false;
                    setHour();
                }
            }
        }

        private void time_set_minus_B_btn_Click(object sender, EventArgs e)
        {
            if (changingClock)
            {
                changeClock(currentMode, ACTION_MOINS);
            }
        }

        private void time_set_plus_B_btn_Click(object sender, EventArgs e)
        {
            if (changingClock)
            {
                changeClock(currentMode, ACTION_PLUS);
            }
        }

        private void time_set_plus_A_btn_Click(object sender, EventArgs e)
        {
            if (changingClock)
            {
                changeClock(currentMode, ACTION_PLUS);
            }
        }

        private void time_set_minus_A_btn_Click(object sender, EventArgs e)
        {
            if (changingClock)
            {
                changeClock(currentMode, ACTION_MOINS);
            }
        }

        private void display_clock_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (!changingClock)
            {
                DateTimeZoneHolded = true;
            }
        }

        private void display_clock_btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (!changingClock)
            {
                DateTimeZoneHolded = false;
            }
        }

        private void display_clock_btn_Click(object sender, EventArgs e)
        {
            if(changingClock)
            {
                switch(currentMode)
                {
                    case CURRENT_MODE_YEAR:
                        currentMode = CURRENT_MODE_MONTH;
                        setDate();
                        break;
                    case CURRENT_MODE_MONTH:
                        currentMode = CURRENT_MODE_DAY;
                        setDate();
                        break;
                    case CURRENT_MODE_DAY:
                        currentMode = CURRENT_MODE_HOUR;
                        setHour();
                        break;
                    case CURRENT_MODE_HOUR:
                        currentMode = CURRENT_MODE_MINUTE;
                        setHour();
                        break;
                    case CURRENT_MODE_MINUTE:
                        changingClock = false;
                        setHour();
                        break;
                    default:
                        throw new Exception();
                        break;
                }
            }
        }
    }   
}
