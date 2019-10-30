using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Sony_ICF_C717PJ
{

        //Enumérations
        enum TypeDeSon
        {
            Buzzer = 1,
            Nature,
            Radio
        }
        enum TypeSonNature
        {
            Birds = 1,
            Waves,
            Rain,
            Wind,
            Aquarium
        }
        enum TypeSonRadio
        {
            FM = 1,
            AM
        }
        class Alarme
        {
        //Champs

        private string _name;
        private DateTime _heure;
        private string _son;
        private TypeDeSon _typeDeSon;
        private TypeSonNature _typeSonNature;
        private TypeSonRadio _typeSonRadio;
        private int _volume;
        private bool _enModeEditon;
        private bool _alarmeActive;
        private bool _weekActive;
        private bool _weekEndActive;
        private int _etapeEditon;

        //Propriétés

        public string Name { get => _name; set => _name = value; }
        public DateTime Heure { get => _heure; set => _heure = value; }
        public string Son { get => _son; set => _son = value; }
        internal TypeDeSon TypeDeSon { get => _typeDeSon; set => _typeDeSon = value; }
        internal TypeSonNature TypeSonNature { get => _typeSonNature; set => _typeSonNature = value; }
        internal TypeSonRadio TypeSonRadio { get => _typeSonRadio; set => _typeSonRadio = value; }
        public int Volume { get => _volume; set => _volume = value; }
        public bool EnModeEditon { get => _enModeEditon; set => _enModeEditon = value; }
        public bool AlarmeActive { get => _alarmeActive; set => _alarmeActive = value; }
        public bool WeekActive { get => _weekActive; set => _weekActive = value; }
        public bool WeekEndActive { get => _weekEndActive; set => _weekEndActive = value; }
        public int EtapeEditon { get => _etapeEditon; set => _etapeEditon = value; }

        //Constructeur
       
        public Alarme(string name, DateTime heure, string son, TypeDeSon typeDeSon, TypeSonNature typeSonNature, TypeSonRadio typeSonRadio, int volume, bool enModeEditon, bool alarmeActive, bool weekActive, bool weekEndActive, int etapeEditon)
        {
            Name = name;
            Heure = heure;
            Son = son;
            TypeDeSon = typeDeSon;
            TypeSonNature = typeSonNature;
            TypeSonRadio = typeSonRadio;
            EnModeEditon = enModeEditon;
            Volume = volume;
            AlarmeActive = alarmeActive;
            WeekActive = weekActive;
            WeekEndActive = weekEndActive;
            EtapeEditon = etapeEditon;
        }


        //*********************** EDITER L'ALARME *********************************//

        public void ActiverAlarme()
        {
            if (AlarmeActive)
            {
                AlarmeActive = false;
            }
            else
            {
                AlarmeActive = true;
            }
        }

        public void ActiveModeEdition()
        {
            EnModeEditon = true;
        }

        public void DesactiveModeEdition()
        {
            EnModeEditon = false;
        }


        public void IncrementerHeure()
        {
            this.Heure = this.Heure.AddHours(1);
        }
        public void IncrementerMin()
        {
            this.Heure = this.Heure.AddMinutes(1);
        }
        public void DiminuerHeure()
        {
            this.Heure = this.Heure.AddHours(-1);
        }
        public void DiminuerMin()
        {
            this.Heure = this.Heure.AddMinutes(-1);
        }

        public void IncrementerVolume()
        {
            Volume++;
        }
        public void DiminuerVolume()
        {
            Volume--;
        }
        public void PasserEtape()
        {
            this.EtapeEditon++;
        }

        public void EditerSemaineActivation()
        {
            if (!WeekActive && !WeekEndActive)
            {
                WeekActive = true;
            }

            else if (WeekActive && !WeekEndActive)
            {
                WeekActive = false;
                WeekEndActive = true;
            }
            else if (!WeekActive && WeekEndActive)
            {
                WeekActive = true;
                WeekEndActive = true;
            }
            else if (WeekActive && WeekEndActive)
            {
                WeekActive = false;
                WeekEndActive = false;
            }
        }

        public void EditerTypeDeSon()
        {
            if (TypeDeSon == TypeDeSon.Radio)
            {
                TypeDeSon = TypeDeSon.Buzzer;
            }
            else
            {
                TypeDeSon = TypeDeSon + 1;
            }
        }
        public void EditerDeuxiemeSon()
        {
            if (this.TypeDeSon == TypeDeSon.Nature)
            {
                EditSoundNature();
            }
            else
            {
                EditSoundRadio();
            }
        }
        public void EditSoundNature()
        {
            if (this.TypeSonNature == TypeSonNature.Aquarium)
            {
                TypeSonNature = TypeSonNature.Birds;
            }
            else
            {
                TypeSonNature = TypeSonNature + 1;
            }
        }

        public void EditSoundRadio()
        {
            if (this.TypeSonRadio == TypeSonRadio.AM)
            {
                this.TypeSonRadio = TypeSonRadio.FM;
            }
            else
            {
                this.TypeSonRadio = TypeSonRadio.AM;
            }
        }

    }
}
