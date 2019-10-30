using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sony_ICF_C717PJ
{
    class AllTime
    {
        //Constantes

        private string AM_STRING = "AM";
        private string PM_STRING = "PM";

        //Champs

        private DateTime _heureActuelle;
        private DateTime _dateActuelle;
        private Timer _timerHeureActuelle;
        private int _anneeActuelle;
        private bool _tempsEnEditon;
        private int _etapeEdition;
        private bool _heureSurLecran;
        private bool _heureModifie;

        

        //Propriétés

        public DateTime HeureActuelle { get => _heureActuelle; set => _heureActuelle = value; }
        public DateTime DateActuelle { get => _dateActuelle; set => _dateActuelle = value; }
        public int AnneeActuelle { get => _anneeActuelle; set => _anneeActuelle = value; }
        public bool TempsEnEditon { get => _tempsEnEditon; set => _tempsEnEditon = value; }
        public int EtapeEdition { get => _etapeEdition; set => _etapeEdition = value; }
        public Timer TimerHeureActuelle { get => _timerHeureActuelle; set => _timerHeureActuelle = value; }
        public bool HeureSurLecran { get => _heureSurLecran; set => _heureSurLecran = value; }
        public bool HeureModifie { get => _heureModifie; set => _heureModifie = value; }

        //Constructeur

        public AllTime()
        {
            HeureActuelle = DateTime.Now;
            DateActuelle = DateTime.Today;
            AnneeActuelle = DateTime.Today.Year;
            TempsEnEditon = false;
            EtapeEdition = -1;
            TimerHeureActuelle = new Timer();
            HeureSurLecran = true;
            HeureModifie = false;
        }

        //Methodes

        //Initialiser l'heure

        public void InitHeure(Label hour, Label min, Label points_heure, Label am_pm)
        {
            hour.Show();
            min.Show();
            am_pm.Show();
            points_heure.Show();
            points_heure.Text = ":";
            hour.Text = HeureActuelle.Hour.ToString();
            min.Text = HeureActuelle.Minute.ToString();

            if (HeureActuelle.Hour > 12)
            {
                am_pm.Text = PM_STRING;
            }
            else
            {
                am_pm.Text = AM_STRING;
            }

        }

        public void InitHeure(Label hour, Label min, DateTime dt)
        {

            hour.Text = dt.Hour.ToString();
            min.Text = dt.Minute.ToString();

        }
        public void AfficherLheureActuelle(Label hour, Label min)
        {
            hour.Text = HeureActuelle.Hour.ToString();
            min.Text = HeureActuelle.Minute.ToString();

        }

        //TIMER

        
        public void InitTimer()
        {
            TimerHeureActuelle.Interval = 1000;
            TimerHeureActuelle.Start();
        }

        public void PasserEnModeHeureModifie() 
        {
            TimerHeureActuelle.Interval = 1000;
            HeureModifie = true;
        }

        //Changer l'affichage du temps

        public void ChangerAffichageHeure(Label hour, Label min, int indexDicTemps, Label points_heure, Label am_pm)
        {
            string annee = AnneeActuelle.ToString();
            switch (indexDicTemps)
            {
                case 1:
                    HeureSurLecran = false;
                    hour.Text = DateActuelle.Day.ToString();
                    min.Text = DateActuelle.Month.ToString();
                    break;
                case 2:
                    HeureSurLecran = true;
                    InitHeure(hour,min,points_heure,am_pm);
                    break;
                case 3:
                    HeureSurLecran = false;
                    hour.Text = annee[0].ToString() + annee[1];
                    min.Text = annee[2].ToString() + annee[3];
                    break;
                default:
                    break;
            }
        }

        //Changer l'affichage du temps en édition

        public void ChangerAffichageHeureEnEditon(Label hour, Label min, int EditonEtape, Label points_heure, Label am_pm)
        {
            if (EditonEtape < 2)
            {
                ChangerAffichageHeure(hour, min, 2, points_heure, am_pm);
            }
            else if (EditonEtape < 4)
            {
                ChangerAffichageHeure(hour, min, 1, points_heure, am_pm);
            }
            else
            {
                ChangerAffichageHeure(hour, min, 3, points_heure, am_pm);
            }

        }


        //*********************** EDITER L'HEURE *********************************//

        public void IncrementerSeconde()
        {
            HeureActuelle = HeureActuelle.AddSeconds(1);
        }
        public void ProchaineEtapeEditionHeure()
        {
            EtapeEdition++;
        }
        public void EditerHeure(int TempsAjoute)
        {
            HeureActuelle = HeureActuelle.AddHours(TempsAjoute);
        }

        public void EditerMinutes(int TempsAjoute)
        {
            HeureActuelle = HeureActuelle.AddMinutes(TempsAjoute);
        }

        public void EditerAnnee(int TempsAjoute)
        {
            AnneeActuelle = AnneeActuelle + TempsAjoute;
        }

        public void EditerMois(int TempsAjoute)
        {
            DateActuelle = DateActuelle.AddMonths(TempsAjoute);
        }
        public void EditerJour(int TempsAjoute)
        {
            DateActuelle = DateActuelle.AddDays(TempsAjoute);
        }
        
        public void ActiverModeEditon()
        {
            TempsEnEditon = true;
            TimerHeureActuelle.Stop();

        }

        public void DesactiverModeEditon()
        {
            TempsEnEditon = false;
        }

        public void ResetEtapEditon()
        {
            EtapeEdition = -1;
        }



    }
}
