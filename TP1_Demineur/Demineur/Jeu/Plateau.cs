using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu
{
    class Plateau
    {
        public Partie partie;
        public int mines, decouvertes, restantes;
        Case[,] cases;
        public int largeur, hauteur;
        
        

        public Plateau(Partie partie, int largeur, int hauteur, int mines)
        {
            this.partie = partie;
            this.mines = mines;
            this.largeur = largeur;
            this.hauteur = hauteur;
            restantes = mines;

            cases = new Case[largeur, hauteur];
         
            

            for(int x=0; x < largeur; x++)
            {
                for(int y=0; y < hauteur; y++)
                {
                    cases[x, y] = new Case();

                    int N = hauteur - 1;
                    if (x > 0 && y > 0) Connecter(cases[x, y], cases[x - 1, y - 1]);
                    if (x > 0) Connecter(cases[x, y], cases[x - 1, y]);
                    if (y > 0) Connecter(cases[x, y], cases[x, y - 1]);
                    if (x > 0 && y < N) Connecter(cases[x, y], cases[x - 1, y + 1]);
                }
            }
            bool[,] placement = new bool[largeur, hauteur];
            for (int a = 0; a < mines;)
            {
                Random rnd = new Random();                
                int i = rnd.Next(0, largeur);
                int j = rnd.Next(0, hauteur);
                if (!placement[i, j])
                {
                    placement[i, j] = true;
                    cases[i, j].minee = true;
                    a++;
                }
            }
            partie.vue.ActualiserComptage(restantes);
        }

        void Connecter(Case a, Case b)
        {
            a.Connecter(b);
            b.Connecter(a);
        }

        public Case Trouver(int x,int y)
        {
            return cases[x, y];
        }

        public void IncrementerDecouvertes()
        {
            decouvertes++;
        }

        public void ModifierMarquees(bool marquee)
        {
            if (marquee)
                restantes--;
            else
                restantes++;
            partie.vue.ActualiserComptage(restantes);
        }

        public bool TesterSiGagne()
        {
            if (decouvertes + mines == largeur * hauteur)
                return true;
            else
                return false;
        }

        /*public bool ToutesDecouvertes()
        {
            int nbDecouvertes=0;
            for (int i = 0; i < largeur; i++)
            {
                for (int j = 0; j < hauteur; j++)
                {
                    if(cases[i,j].minee==true && cases[i, j].marquee == true)
                    {
                        nbDecouvertes += 1;
                    }
                }
            }
            if (nbDecouvertes == mines)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
    }
}
