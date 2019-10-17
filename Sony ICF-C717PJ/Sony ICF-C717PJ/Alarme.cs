using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Sony_ICF_C717PJ
{
    class Alarme
    {

        //Champs

        private string _name;
        private DateTime _heure;
        private SoundPlayer _sound;
        private bool _modeEditActivated;
        private bool _activated;
        private bool _weekActivated;
        private bool _weekendActivated;

        //Propriétés

        public DateTime Heure { get => _heure; set => _heure = value; }
        public bool WeekActivated { get => _weekActivated; set => _weekActivated = value; }
        public bool WeekendActivated { get => _weekendActivated; set => _weekendActivated = value; }
        public SoundPlayer Sound { get => _sound; set => _sound = value; }
        public bool Activated { get => _activated; set => _activated = value; }
        public string Name { get => _name; set => _name = value; }


        //Constructeur
        public Alarme(string name, DateTime heure, SoundPlayer sound,bool activated, bool weekActivated, bool weekendActivated)
        {
            Name = name;
            Heure = heure;
            Sound = sound;
            Activated = activated;
            WeekActivated = weekActivated;
            WeekendActivated = weekendActivated;
        }
        public Alarme()
        {
            Heure = new DateTime();
            Sound = new SoundPlayer();
            Activated = false;
            WeekActivated = false;
            WeekendActivated = false;
        }

        public void Activate()
        {
            if (Activated)
            {
                Activated = false;
                Console.WriteLine("Alarme "+this.Name+" activée");
            }
            else
            {
                Activated = true;
                Console.WriteLine("Alarme " + this.Name + " désactivée");
            }
        }
        public void ActivateWeek()
        {
            if (WeekActivated)
            {
                Activated = false;
            }
            else
            {
                Activated = true;
            }
        }
        public void ActivateWeekEnd()
        {
            if (WeekendActivated)
            {
                Activated = false;
            }
            else
            {
                Activated = true;
            }
        }
        

    }
}
