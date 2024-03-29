﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sony_ICF_C717PJ
{
    class AffichageController
    {
        //Champs

        private simulator _simulator;

        //Propriétés
        public simulator Simulator
        {
            get { return _simulator; }
            set { _simulator = value; }
        }

        //Constructeur
        public AffichageController(simulator simulator)
        {
            this.Simulator = simulator;
        }

        //Methodes

        public void ChangeVisibility(Control element, bool newState)
        {
            if (newState)
            {
                element.Show();
            }
            else
            {
                element.Hide();
            }
        }

    }
}
