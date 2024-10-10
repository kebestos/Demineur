using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu
{
    class Case
    {
        public bool minee;
        public bool marquee;
        public bool decouverte;

        List<Case> voisines = new List<Case>();

        public void Connecter(Case c)
        {
            voisines.Add(c);
        }       

        public void Marquer()
        {
            if (!marquee)
            {
                marquee = true;                
            }
        }
        public void Decouvrir()
        {
            if(!decouverte && !marquee)
            {
                decouverte = true;
            }
        }

        public int Contenu()
        {
            int i = 0;
            foreach(Case c in voisines)
            {
                if (c.minee)
                {
                    i++;
                }
            }
            return i;
        }
    }
}
