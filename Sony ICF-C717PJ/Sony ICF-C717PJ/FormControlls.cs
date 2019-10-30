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
        private Dictionary<string, Label> _allLabels;

        //Propriétés

        public Dictionary<string, Control> AllControlls { get => _allControlls; set => _allControlls = value; }
        public Dictionary<string, Label> AllLabels { get => _allLabels; set => _allLabels = value; }

        //Constructeur

        public FormControlls(simulator simulator)
        {
            AllControlls = new Dictionary<string, Control>();
            AllLabels = new Dictionary<string, Label>();
        }

        //Methodes

        public Control GetControl(string name)
        {

            Control control = AllControlls[name];

            return control;

        }


    }
}
