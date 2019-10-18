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
    class FormControlls 
    {

        //Champs

        private Dictionary<string, Control> _allControlls;
        private Form _form;

        public Dictionary<string, Control> AllControlls { get => _allControlls; set => _allControlls = value; }
        public Form Form { get => _form; set => _form = value; }

        public FormControlls(simulator simulator)
        {
            AllControlls = new Dictionary<string, Control>();
            Form = simulator;

            AllControlls.Add("alarm_a_toggle_btn", simulator.Controls["alarm_a_toggle_btn"]);
            AllControlls.Add("time_set_plus_A_btn", simulator.Controls["time_set_plus_A_btn"]);
            AllControlls.Add("time_set_minus_A_btn", simulator.Controls["time_set_minus_A_btn"]);
            
        }




    }
}
