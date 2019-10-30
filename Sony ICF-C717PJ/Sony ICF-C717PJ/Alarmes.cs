using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sony_ICF_C717PJ
{
    class Alarmes
    {

        //Constantes

        private DateTime DEFAUT_HEURE_ALARME = DateTime.Now.AddHours(2).AddMinutes(20);
        
        //Champs

        private Dictionary<string,Alarme> _ListAlarmes;
        AffichageController _controler;
        AllTime Time = new AllTime();

        //Propriétés

        internal Dictionary<string, Alarme> ListeAlarmes { get => _ListAlarmes; set => _ListAlarmes = value; }
        internal AffichageController Controler { get => _controler; set => _controler = value; }
    
        //Constructeur
        public Alarmes(simulator simulator)
        {
            ListeAlarmes = new Dictionary<string, Alarme>();
            Controler = new AffichageController(simulator);

            Alarme A = new Alarme("A", DEFAUT_HEURE_ALARME, "", 0 , 0, 0,0,false,false, false,false,-1);
            Alarme B = new Alarme("B", DateTime.Now, "",0, 0,0,0, false, false, false, false, -1);

            ListeAlarmes.Add(A.Name,A);
            ListeAlarmes.Add(B.Name,B);

        }

        //MAJ les alarmes selon l'alarme passée en parametre

        public void MettreAJourAlarme(Alarme alarme, FormControlls controls)
        {
            CacherTousLesControls(controls);
            CacherTousLesLabels(controls);

            if (alarme.EnModeEditon || alarme.AlarmeActive)
            {
                AfficherInfoAlarme(alarme, controls);
                MettreAjourLesSonsChoisi(alarme, controls);
            }

        }

        //Afficher les infos stockées de l'alarme choisie

        public void AfficherInfoAlarme(Alarme alarme,FormControlls controls)
        {
            controls.AllLabels["L_Alarme_heure_unite"].Show();
            controls.AllLabels["L_Alarme_minutes_unite"].Show();
            controls.AllLabels["L_Alarme_heure_unite"].Text = alarme.Heure.Hour.ToString();
            controls.AllLabels["L_Alarme_minutes_unite"].Text = alarme.Heure.Minute.ToString();
            Controler.ChangeVisibility(controls.GetControl("weekday_hider"), !alarme.WeekActive);
            Controler.ChangeVisibility(controls.GetControl("weekend_hider"), !alarme.WeekEndActive);

           if (alarme.Name == "A")
            {
                Controler.ChangeVisibility(controls.GetControl("Alarme_A_petite_icone"), false);
                Controler.ChangeVisibility(controls.GetControl("Alarme_A_icone"), false);
            }
            if (alarme.Name == "B")
            {
                Controler.ChangeVisibility(controls.GetControl("Alarme_B_petite_icone"), false);
                Controler.ChangeVisibility(controls.GetControl("Alarme_B_icone"), false);
            }

        }

        //Met à jour l'écran les son choisi quand l'alarme est en mode édition
        public void MettreAjourLesSonsChoisi(Alarme alarme, FormControlls controls)
        {
            switch (alarme.TypeDeSon)
            {
                case TypeDeSon.Buzzer:
                    Controler.ChangeVisibility(controls.GetControl("buzzer_hider"), false);
                    break;
                case TypeDeSon.Nature:
                    MettreAJourLesSonsNature(alarme, controls);
                    break;
                case TypeDeSon.Radio:
                    MettreAJourLesSonsRadio(alarme, controls);
                    break;
                default:
                    break;
            }

        }

        //MAJ des sons narture

        private void MettreAJourLesSonsNature(Alarme alarme, FormControlls controls)
        {
            Controler.ChangeVisibility(controls.GetControl("nature_sound_hider"), false);
            switch (alarme.TypeSonNature)
            {
                case TypeSonNature.Birds:
                    Controler.ChangeVisibility(controls.GetControl("oiseaux_hider"), false);
                    break;
                case TypeSonNature.Waves:
                    Controler.ChangeVisibility(controls.GetControl("vagues_hider"), false);
                    break;
                case TypeSonNature.Rain:
                    Controler.ChangeVisibility(controls.GetControl("pluie_hider"), false);
                    break;
                case TypeSonNature.Wind:
                    Controler.ChangeVisibility(controls.GetControl("vent_hider"), false);
                    break;
                case TypeSonNature.Aquarium:
                    Controler.ChangeVisibility(controls.GetControl("poisson_hider"), false);
                    break;
                default:
                    break;
            }
        }

        //MAJ les sons radio 

        private void MettreAJourLesSonsRadio(Alarme alarme, FormControlls controls)
        {
            Controler.ChangeVisibility(controls.GetControl("radio_hider"), false);

            switch (alarme.TypeSonRadio)
            {
                case TypeSonRadio.FM:
                    Controler.ChangeVisibility(controls.GetControl("fm_hider"), false);
                    break;
                case TypeSonRadio.AM:
                    Controler.ChangeVisibility(controls.GetControl("am_hider"), false);
                    break;
                default:
                    break;
            }
        }

        //Changer l'état d'une alarme(activer, desactiver ou passer une étape d'édition)

        public void ChangerEtatAlarme(Alarme alarme)
        {
            if (alarme.EnModeEditon)
            {
                alarme.PasserEtape();
            }
            else
            {
                alarme.ActiverAlarme();
            }
        }

        //Cacher tous les controls de l'écran

        public void CacherTousLesControls(FormControlls controls)
        {
            foreach (var item in controls.AllControlls)
            {
                item.Value.Show();
            }
            
        }

        //Cacher tous les labels de l'écran

        public void CacherTousLesLabels(FormControlls Controls)
        {
            foreach (var item in Controls.AllLabels)
            {
                item.Value.Hide();
            }
        }

        //Activer ou desactiver une alarme

        public void ActiverModeEdition(Alarme alarme)
        {
            alarme.EnModeEditon = true;
        }

        public void DesActiverModeEdition(Alarme alarme)
        {
            alarme.EnModeEditon = false;
        }

       

    }
}
