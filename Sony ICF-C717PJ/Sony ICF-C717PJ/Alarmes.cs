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

            Alarme A = new Alarme("A", DateTime.Now ,null,false,false,false);
            Alarme B = new Alarme("B", DateTime.Now, null, false, false, false);

            ListAlarmes.Add(A);
            ListAlarmes.Add(B);

        }

        

    }
}
