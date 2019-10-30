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

        //Champs

        Alarmes _lesAlarmes;
        //Dictionary<string, Button> NumberButtons = new Dictionary<string, Button>();
        AllTime _allTime = new AllTime();
        FormControlls _lesControles;
        AffichageController _controller;
        Radios _radios;
        Timer _timerClick = new Timer();
        SoundPlayer _playerSon;
        Alarme _a;
        Alarme _b;
        int _volumeSimulator;
        int _indexTemps = 1;

        //Propriétes

        internal Alarmes LesAlarmes { get => _lesAlarmes; set => _lesAlarmes = value; }
        internal AllTime AllTime { get => _allTime; set => _allTime = value; }
        internal FormControlls LesControles { get => _lesControles; set => _lesControles = value; }
        internal AffichageController Controller { get => _controller; set => _controller = value; }
        internal Radios Radios { get => _radios; set => _radios = value; }
        public Timer TimerClick { get => _timerClick; set => _timerClick = value; }
        public SoundPlayer PlayerSon { get => _playerSon; set => _playerSon = value; }
        internal Alarme A { get => _a; set => _a = value; }
        internal Alarme B { get => _b; set => _b = value; }
        public int VolumeSimulator { get => _volumeSimulator; set => _volumeSimulator = value; }
        public int IndexTemps { get => _indexTemps; set => _indexTemps = value; }

        //Constructeur
      
        public simulator()
        {
            InitializeComponent();

            PlayerSon = new SoundPlayer();
            Controller = new AffichageController(this);
            PlayerSon.InitializeLifetimeService();
            //Récuperer les alarmes
            LesAlarmes = new Alarmes(this);
            A = LesAlarmes.ListeAlarmes["A"];
            B = LesAlarmes.ListeAlarmes["B"];
            //Initialiser les radios
            Random RadioRandom = new Random();
            Radios = new Radios(RadioRandom.Next(0, 151) + 0.5, 100, 100, 0.1, 0.1);
            
            //INITIALISER LA CLASSE FORMCONTROLE ET AJOUTER TOUS LES HIDERS ET LES LABELS

            LesControles = new FormControlls(this);

            LesControles.AllControlls.Add(weekday_hider.Name, weekday_hider);
            LesControles.AllControlls.Add(weekend_hider.Name, weekend_hider);
            LesControles.AllControlls.Add(nature_sound_hider.Name,nature_sound_hider);
            LesControles.AllControlls.Add(radio_hider.Name, radio_hider);
            LesControles.AllControlls.Add(buzzer_hider.Name, buzzer_hider);
            LesControles.AllControlls.Add(vagues_hider.Name, vagues_hider);
            LesControles.AllControlls.Add(oiseaux_hider.Name, oiseaux_hider);
            LesControles.AllControlls.Add(pluie_hider.Name, pluie_hider);
            LesControles.AllControlls.Add(vent_hider.Name, vent_hider);
            LesControles.AllControlls.Add(poisson_hider.Name, poisson_hider);
            LesControles.AllControlls.Add(Alarme_A_petite_icone.Name, Alarme_A_petite_icone);
            LesControles.AllControlls.Add(Alarme_B_petite_icone.Name, Alarme_B_petite_icone);
            LesControles.AllControlls.Add(Alarme_A_icone.Name, Alarme_A_icone);
            LesControles.AllControlls.Add(Alarme_B_icone.Name, Alarme_B_icone);
            LesControles.AllControlls.Add(am_hider.Name, am_hider);
            LesControles.AllControlls.Add(fm_hider.Name, fm_hider);
            LesControles.AllControlls.Add(volume_hider.Name, volume_hider);

            //Ajout des Labels

            LesControles.AllLabels.Add(L_heure_unite.Name, L_heure_unite);
            LesControles.AllLabels.Add(L_minutes_unite.Name, L_minutes_unite);
            LesControles.AllLabels.Add(L_Alarme_heure_unite.Name, L_Alarme_heure_unite);
            LesControles.AllLabels.Add(L_Alarme_minutes_unite.Name, L_Alarme_minutes_unite);
            LesControles.AllLabels.Add(L_2points_heure.Name, L_2points_heure);
            LesControles.AllLabels.Add(L_2points_alarme.Name, L_2points_alarme);
            LesControles.AllLabels.Add(l_am_pm.Name, l_am_pm);
            
            //Afficher heure au démarrage
            
            LesAlarmes.CacherTousLesControls(LesControles);
            LesAlarmes.CacherTousLesLabels(LesControles);
            InitialiserHeure();
            AllTime.TimerHeureActuelle.Tick += MAJdeLheure;
            AllTime.InitTimer();
            

            //Variables LOCALES

            L_temperature.Show();
            HeureEte_hider.Hide();
            L_temperature.Text = "21";
            VolumeSimulator = 0;

            //Add number buttons

            //NumberButtons.Add(Btn_vagues_1.Name, Btn_vagues_1);
            //NumberButtons.Add(Btn_Oiseaux_2.Name,Btn_Oiseaux_2);
            //NumberButtons.Add(Btn_Pluie_3.Name, Btn_Pluie_3);
            //NumberButtons.Add(Btn_Vent_4.Name, Btn_Vent_4);
            //NumberButtons.Add(Btn_Poisson_5.Name, Btn_Poisson_5);
            
        }

        //Methodes 


        private void MAJdeLheure(object sender, EventArgs e)
        {
            Console.WriteLine(AllTime.HeureActuelle);

            //Met à jour l'heure sur l'écran que s'il est affiché

            if (!AllTime.TempsEnEditon && AllTime.HeureSurLecran && volume_hider.Visible)
            {
                AllTime.ChangerAffichageHeure(L_heure_unite, L_minutes_unite, 2, L_2points_heure, l_am_pm);

            }
                AllTime.IncrementerSeconde();

        }
        
        //Methode qui permet de modifier le volume du radio-reveil

        private void EditerVolume(object sender, EventArgs e)
        {
            //Si alarme en édition, sortir de la méthode

            foreach (var item in LesAlarmes.ListeAlarmes)
            {
                if (item.Value.EnModeEditon)
                {
                    return;
                }
            }

            Button btn = sender as Button;

            LesAlarmes.CacherTousLesControls(LesControles);
            volume_hider.Hide();

            //Bouton PLUS et MOINS 
         
            if (btn.Name == Btn_volume_plus.Name)
            {
                if (VolumeSimulator < 30)
                {
                    VolumeSimulator++;
                }
                
            }
            if (btn.Name == Btn_Volume_moins.Name)
            {
                if (VolumeSimulator > 0)
                {
                    VolumeSimulator--;
                }
                
            }


            L_heure_unite.Text = VolumeSimulator.ToString();
            L_minutes_unite.Text = "";

        }
        

        //Methode qui permet de éditer la frequence de la radio actuelle et la date

        private void EditerRadioEtDate(object sender, EventArgs e)
        {
            foreach (var item in LesAlarmes.ListeAlarmes)
            {
                if (item.Value.EnModeEditon)
                {
                    return;
                }
            }

            Button btn = sender as Button;


            //Incrémente les information de la date ou la fréquence de la radio

            if (btn.Name == Btn_Tuning_Plus.Name)
            {
                if (AllTime.TempsEnEditon)
                {
                    switch (AllTime.EtapeEdition)
                    {
                        case 0: AllTime.EditerHeure(1);
                            AllTime.ChangerAffichageHeure(L_heure_unite, L_minutes_unite, 2, L_2points_heure, l_am_pm);
                            break;
                        case 1:
                            AllTime.EditerMinutes(1);
                            AllTime.ChangerAffichageHeure(L_heure_unite, L_minutes_unite, 2, L_2points_heure, l_am_pm);
                            break;
                        case 2:
                            AllTime.EditerJour(1);
                            AllTime.ChangerAffichageHeure(L_heure_unite, L_minutes_unite, 1, L_2points_heure, l_am_pm);
                            break;
                        case 3:
                            AllTime.EditerMois(1);
                            AllTime.ChangerAffichageHeure(L_heure_unite, L_minutes_unite, 1, L_2points_heure, l_am_pm);
                            break;
                        case 4:
                            AllTime.EditerAnnee(1);
                            AllTime.ChangerAffichageHeure(L_heure_unite, L_minutes_unite, 3, L_2points_heure, l_am_pm);
                            break;
                        default: AllTime.DesactiverModeEditon();
                            AllTime.EtapeEdition = -1;
                            break;
                    }

                    
                }
                if (Radios.Active)
                {
                    Radios.RadioSuivant();
                    Radios.InitRadio(L_heure_unite, L_minutes_unite, L_2points_heure, am_hider, fm_hider);
                }
                  
            }

            //Diminue info date et fréquence radio

            if (btn.Name == Btn_tuning_moins.Name)
            {
                if (AllTime.TempsEnEditon)
                {
                    switch (AllTime.EtapeEdition)
                    {
                        case 0:
                            AllTime.EditerHeure(-1);
                            AllTime.ChangerAffichageHeure(L_heure_unite, L_minutes_unite, 2, L_2points_heure, l_am_pm);
                            break;
                        case 1:
                            AllTime.EditerMinutes(-1);
                            AllTime.ChangerAffichageHeure(L_heure_unite, L_minutes_unite, 2, L_2points_heure, l_am_pm);
                            break;
                        case 2:
                            AllTime.EditerJour(-1);
                            AllTime.ChangerAffichageHeure(L_heure_unite, L_minutes_unite, 1, L_2points_heure, l_am_pm);
                            break;
                        case 3:
                            AllTime.EditerMois(-1);
                            AllTime.ChangerAffichageHeure(L_heure_unite, L_minutes_unite, 1, L_2points_heure, l_am_pm);
                            break;
                        case 4:
                            AllTime.EditerAnnee(-1);
                            AllTime.ChangerAffichageHeure(L_heure_unite, L_minutes_unite, 3, L_2points_heure, l_am_pm);
                            break;
                        default:
                            AllTime.TempsEnEditon = false;
                            break;
                    }
                }


                if(Radios.Active)
                {
                    Radios.RadioAvant();
                    Radios.InitRadio(L_heure_unite, L_minutes_unite, L_2points_heure, am_hider, fm_hider);

                }

               
            }


        }

        //Methode qui permet d'initialiser l'heure automatiquement

        private void InitialiserHeure()
        {
            L_2points_heure.Text = ":";
            AllTime.InitHeure(L_heure_unite, L_minutes_unite, L_2points_heure, l_am_pm);
        }

        //Methodes appelée lorsqu'un button et appuyé et maintenu pour déclancher l'éditon 
        //de l'heure ou d'une alarme

        public void EditerControl(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            TimerClick = new Timer();
            TimerClick.Interval = 2000;
            TimerClick.Start();

            if (btn.Name == Btn_A_OnOff.Name)
            {
                TimerClick.Tick += EditerAlarmeA;
               
            }
            else if (btn.Name == Btn_B_OnOff.Name)
            {
                TimerClick.Tick += EditerAlarmeB;
            }

            else if (btn.Name == Btn_DateTime_Zone.Name)
            {
                TimerClick.Tick += EditerHeure;
            }

        }
        
        //Methode qui active le moode édtion de l'heure

        private void EditerHeure(object sender, EventArgs e)
        {
            
            AllTime.ActiverModeEditon();
            AllTime.PasserEnModeHeureModifie();
            Console.WriteLine("Mode edition heure activé " + AllTime.TempsEnEditon);
            InitialiserHeure();
            LesAlarmes.CacherTousLesControls(LesControles);
            AllTime.TimerHeureActuelle.Stop();
            TimerClick.Stop();

        }

        //Methodes qui active l'éditon de l'alarme A

        private void EditerAlarmeA(object sender, EventArgs e)
        {
            
            Console.WriteLine("Alarme A holded");
            LesAlarmes.ActiverModeEdition(A);
            LesAlarmes.CacherTousLesControls(LesControles);
            InitialiserHeure();
            LesAlarmes.MettreAJourAlarme(A, LesControles);
            TimerClick.Stop();

        }

        //Methodes qui active l'activation de l'alarme B

        private void EditerAlarmeB(object sender, EventArgs e)
        {

            Console.WriteLine("Alarme B holded");
            LesAlarmes.ActiverModeEdition(B);
            LesAlarmes.CacherTousLesControls(LesControles);
            InitialiserHeure();
            LesAlarmes.MettreAJourAlarme(B, LesControles);

            TimerClick.Stop();
        }
        
        //Methode pour activer l'affichage "Audio in" sur l'écran

        private void Afficher_Audio_in (object sender, EventArgs e)
        {
            foreach (var item in LesAlarmes.ListeAlarmes)
            {
                if (item.Value.EnModeEditon)
                {
                    return;
                }
            }
            Controller.ChangeVisibility(this.audio_in_hider, !this.audio_in_hider.Visible);
        }

        //Methodes pour stopper le Timer lorsqu'en leve la souris

        private void StopTimerClick(object sender, MouseEventArgs e)
        {
            TimerClick.Stop();
        }
        //Methode qui permet d'éditer les alarmes ainsi que les activer/desactiver

        public void EditerToutesLesAlarmes_Click(object sender, EventArgs e)
        {

            //Cacher les tous les controles sur l'écran

            LesAlarmes.CacherTousLesControls(LesControles);
            Radios.DesactiverRadio();
            Button Btn = sender as Button;


            //si en Editon alarme A

            if (A.EnModeEditon)
            {
                if (Btn.Name == Btn_A_Plus.Name)
                {
                    switch (A.EtapeEditon)
                    {
                        case 0:
                            A.IncrementerHeure();
                            break;
                        case 1:
                            A.IncrementerMin();
                            break;
                        case 2:
                            A.EditerSemaineActivation();
                            break;
                        case 3:
                            A.EditerTypeDeSon();
                            break;
                        case 4:
                            A.EditerDeuxiemeSon();
                            break;
                        case 5:
                            A.IncrementerVolume();
                            break;
                        default:
                            A.DesactiveModeEdition();
                            break;
                    }

                    LesAlarmes.MettreAJourAlarme(A, LesControles);
                }

            }

            //Si en Editon Alarme B

            if (B.EnModeEditon)
            {
                if (Btn.Name == Btn_B_Plus.Name)
                {
                    switch (B.EtapeEditon)
                    {
                        case 0:
                            B.IncrementerHeure();
                            break;
                        case 1:
                            B.IncrementerMin();
                            break;
                        case 2:
                            B.EditerSemaineActivation();
                            break;
                        case 3:
                            B.EditerTypeDeSon();
                            break;
                        case 4:
                            B.EditerDeuxiemeSon();
                            break;
                        default:
                            B.DesactiveModeEdition();
                            break;
                    }

                    LesAlarmes.MettreAJourAlarme(B, LesControles);

                }

            }

            // Passer une etape d'édition ou MAJ de l'heure alarme A

            if (Btn.Name == Btn_A_OnOff.Name)
            {
                if (A.EtapeEditon > 5)
                {
                    A.EnModeEditon = false;
                }
                LesAlarmes.ChangerEtatAlarme(A);
                LesAlarmes.MettreAJourAlarme(A, LesControles);
            }

            // Passer une etape d'édition ou MAJ de l'heure alarme B

            if (Btn.Name == Btn_B_OnOff.Name)
            {
                if (B.EtapeEditon > 5)
                {
                    B.EnModeEditon = false;
                }
                LesAlarmes.ChangerEtatAlarme(B);
                LesAlarmes.MettreAJourAlarme(B, LesControles);
            }

            InitialiserHeure();

        }

        // Methode qui permet, selon le boutton clické de lancer les son nature et choisir les radios mémorisées
        // Reset le système ou lancer le mode d'édition de l'Heure/Date/Année
        private void ButtonsFaceDessus_Click(object sender, EventArgs e)
        {
            Button Btn = sender as Button;

            LesAlarmes.CacherTousLesControls(LesControles);

            /////////////////// SONS ET RADIO PRESET ///////////////////////////////////

            if (Btn.Name == Btn_vagues_1.Name)
            {
                if (Radios.Active)
                {
                    Radios.InitRadio(L_heure_unite, L_minutes_unite, Radios.FmPreSet[1]);
                    Radios.RadioActuel = Radios.FmPreSet[1];
                    PlayerSon.Stop();
                    return;
                }
                else
                {
                    nature_sound_hider.Hide();
                    PlayerSon.Stream = Properties.Resources.waves1;
                    this.vagues_hider.Hide();
                    PlayerSon.Stop();
                    return;
                }

            }
            if (Btn.Name == Btn_Oiseaux_2.Name)
            {

                if (Radios.Active)
                {
                    Radios.InitRadio(L_heure_unite, L_minutes_unite, Radios.FmPreSet[2]);
                    Radios.RadioActuel = Radios.FmPreSet[2];
                    PlayerSon.Stop();
                    return;
                }
                else
                {
                    nature_sound_hider.Hide();
                    PlayerSon.Stream = Properties.Resources.birds1;
                    oiseaux_hider.Hide();
                }

            }
            if (Btn.Name == Btn_Pluie_3.Name)
            {

                if (Radios.Active)
                {
                    Radios.InitRadio(L_heure_unite, L_minutes_unite, Radios.FmPreSet[3]);
                    Radios.RadioActuel = Radios.FmPreSet[3];
                    PlayerSon.Stop();
                    return;
                }
                else
                {
                    nature_sound_hider.Hide();
                    PlayerSon.Stream = Properties.Resources.rain1;
                    pluie_hider.Hide();
                }

            }
            if (Btn.Name == Btn_Vent_4.Name)
            {

                if (Radios.Active)
                {
                    Radios.InitRadio(L_heure_unite, L_minutes_unite, Radios.FmPreSet[4]);
                    Radios.RadioActuel = Radios.FmPreSet[4];
                    PlayerSon.Stop();
                    return;
                }
                else
                {
                    nature_sound_hider.Hide();
                    PlayerSon.Stream = Properties.Resources.beach;
                    vent_hider.Hide();
                }

            }
            if (Btn.Name == Btn_Poisson_5.Name)
            {

                if (Radios.Active)
                {
                    Radios.InitRadio(L_heure_unite, L_minutes_unite, Radios.FmPreSet[5]);
                    Radios.RadioActuel = Radios.FmPreSet[5];
                    PlayerSon.Stop();
                    return;
                }
                else
                {
                    nature_sound_hider.Hide();
                    PlayerSon.Stream = Properties.Resources.aquarium;
                    poisson_hider.Hide();
                }

            }
            PlayerSon.Play();

            if (Btn.Name == Btn_Radio.Name)
            {
                PlayerSon.Stop();
                LesAlarmes.CacherTousLesControls(LesControles);
                LesAlarmes.CacherTousLesLabels(LesControles);
                Radios.InitRadio(L_heure_unite, L_minutes_unite, L_2points_heure, am_hider, fm_hider);
                Radios.ActiverRadio();
                AllTime.HeureSurLecran = false;
                fm_hider.Hide();
            }

            if (Btn.Name == Btn_Off_Reset.Name)
            {

                Radios.DesactiverRadio();
                AllTime.DesactiverModeEditon();
                AllTime.HeureSurLecran = true;
                PlayerSon.Stop();
                InitialiserHeure();

                foreach (var item in LesAlarmes.ListeAlarmes)
                {
                    item.Value.EnModeEditon = false;
                    item.Value.EtapeEditon = -1;
                }

            }

            /////////////////// CLICK HEURE EDITON ///////////////////////////////////

            if (Btn.Name == Btn_DateTime_Zone.Name)
            {
                //Si date en édition
                if (AllTime.TempsEnEditon)
                {
                    AllTime.ProchaineEtapeEditionHeure();
                    AllTime.ChangerAffichageHeureEnEditon(L_heure_unite, L_minutes_unite, AllTime.EtapeEdition, L_2points_heure, l_am_pm);
                    if (AllTime.EtapeEdition > 4)
                    {
                        AllTime.DesactiverModeEditon();
                        AllTime.ResetEtapEditon();
                    }
                }
                else
                {
                    if (IndexTemps > 3)
                    {
                        IndexTemps = 1;
                    }

                    AllTime.TimerHeureActuelle.Start();
                    AllTime.ChangerAffichageHeure(L_heure_unite, L_minutes_unite, IndexTemps, L_2points_heure, l_am_pm);
                    IndexTemps++;

                }

            }

        }
    }
}
