using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sony_ICF_C717PJ
{
    class Radios
    {
        //Constantes
        private string AM_STRING = "AM";
        private string PM_STRING = "PM";
        private int DEFAULT_COUNT_RADIO_PRESET = 5;
        //Champs

        private double _radioActuel;
        private double _maxRadioAm;
        private double _maxRadioFm;
        private double _minRadoiAm;
        private double _minRadioFm;
        private bool _active;
        
        private Dictionary<int, double> _amPreSet;
        private Dictionary<int, double> _fmPreSet;

        //Propriétés

        public double RadioActuel { get => _radioActuel; set => _radioActuel = value; }
        public double MaxRadioAm { get => _maxRadioAm; set => _maxRadioAm = value; }
        public double MaxRadioFm { get => _maxRadioFm; set => _maxRadioFm = value; }
        public double MinRadoiAm { get => _minRadoiAm; set => _minRadoiAm = value; }
        public double MinRadioFm { get => _minRadioFm; set => _minRadioFm = value; }
        public Dictionary<int, double> AmPreSet { get => _amPreSet; set => _amPreSet = value; }
        public Dictionary<int, double> FmPreSet { get => _fmPreSet; set => _fmPreSet = value; }
        public bool Active { get => _active; set => _active = value; }


        //Constructeur

        public Radios(double currentRadio, double maxRadioAm, double maxRadioFm, double minRadoiAm, double minRadioFm)
        {
            RadioActuel = currentRadio;
            MaxRadioAm = maxRadioAm;
            MaxRadioFm = maxRadioFm;
            MinRadoiAm = minRadoiAm;
            MinRadioFm = minRadioFm;
            Active = false;
            AmPreSet = new Dictionary<int, double>();
            FmPreSet = new Dictionary<int, double>();

            for (double i = 0; i <= DEFAULT_COUNT_RADIO_PRESET ; i++)
            {
                AmPreSet.Add((int)i, i*4+0.7);
                FmPreSet.Add((int)i, i*7.6+0.3);
            }

        }

        

        //Methodes

        //Initialiser la radio automatiquement

       public void InitRadio(Label first, Label second, Label points_heure, PictureBox am, PictureBox fm)
        {
            int fisrtunit = (int)RadioActuel;
            double secondunit = (double)RadioActuel - fisrtunit;

            first.Show();
            second.Show();
            points_heure.Show();
            points_heure.Text = ".";
            first.Text = fisrtunit.ToString();
            second.Text = secondunit.ToString()[2].ToString();

        }

        //Initialiser la radio avec une nouvelle fréquance

        public void InitRadio(Label first, Label second, double radio)
        {
            int fisrtunit = (int)radio;
            double secondunit = (double)radio - fisrtunit;

            first.Text = fisrtunit.ToString();
            second.Text = secondunit.ToString()[2].ToString();
        }



        //*********************** EDITER LES RADIOS *********************************//


        public void DefinirRadio(double radio, int btn, string antene)
        {
            if (antene == AM_STRING)
            {
                AmPreSet[btn] = radio;
            }
            if (antene == PM_STRING)
            {
                FmPreSet[btn] = radio;
            }
        }


        public void ActiverRadio()
        {
            Active = true;
        }

        public void DesactiverRadio()
        {
            Active = false;
        }

        public void RadioSuivant()
        {
            RadioActuel = RadioActuel + 0.1;
        }

        public void RadioAvant()
        {
            RadioActuel = RadioActuel - 0.1;
        }
    }
}
