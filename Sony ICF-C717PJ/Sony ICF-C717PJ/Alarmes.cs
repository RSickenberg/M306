using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sony_ICF_C717PJ
{
    class Alarmes
    {

        //Champs

        private List<Alarme> _ListAlarmes;

        //Propriétés
        public List<Alarme> ListAlarmes { get => _ListAlarmes; set => _ListAlarmes = value; }


        public Alarmes()
        {
            ListAlarmes = new List<Alarme>();

            Alarme A = new Alarme();
            Alarme B = new Alarme();

            ListAlarmes.Add(A);
            ListAlarmes.Add(B);

        }

    }
}
