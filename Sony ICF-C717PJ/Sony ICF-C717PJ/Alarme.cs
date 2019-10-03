using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sony_ICF_C717PJ
{
    class Alarme
    {
        //Champs

        private DateTime _heure;
        private string _sound; 
        private bool _weekActivated;
        private bool _weekendActivated;
        private WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();


        //Propriétés

        public DateTime Heure { get => _heure; set => _heure = value; }
        public string Sound { get => _sound; set => _sound = value; }
        public bool WeekActivated { get => _weekActivated; set => _weekActivated = value; }
        public bool WeekendActivated { get => _weekendActivated; set => _weekendActivated = value; }


        //Constructeur
        public Alarme(DateTime heure, string sound, bool weekActivated, bool weekendActivated)
        {
            Heure = heure;
            Sound = sound;
            WeekActivated = weekActivated;
            WeekendActivated = weekendActivated;
        }
        public Alarme()
        {
            Heure = new DateTime();
            Sound = "";
            WeekActivated = false;
            WeekendActivated = false;

        }
        

    }
}
