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

            Alarme A = new Alarme("A", DateTime.Now, "", 0,0,0,false,false,false,false,0);
            Alarme B = new Alarme("B", DateTime.Now, "", 0, 0, 0, false, false, false, false, 0);

            ListAlarmes.Add(A);
            ListAlarmes.Add(B);

        }

        

    }
}
