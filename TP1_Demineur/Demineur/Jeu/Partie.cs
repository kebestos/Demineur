using System;
using System.Collections.Generic;
using System.Text;
using IHM;

namespace Jeu
{
    public class Partie : IActions
    {
        
        Plateau plateau;

        public IReactions vue
        {
            get; set;
        }

        public void CommencerPartie(int largeur, int hauteur, int mines)
        {
            plateau = new Plateau(this, largeur, hauteur, mines);
        }

        public void DecouvrirCase(int x, int y)
        {
            Case c = plateau.Trouver(x, y);            

            if (c.minee)
            {
                vue.AfficherCaseMinee(x, y,true);
                vue.PartiePerdue();
            }
            else if (plateau.TesterSiGagne())
            {
                vue.PartieGagnee();
            }
            else 
            {
                vue.AfficherCaseNumerotee(x, y, c.Contenu());
            }
        }

        public void MarquerCase(int x, int y)
        {
            Case c = plateau.Trouver(x, y);
            c.Marquer();
            vue.AfficherCaseMarquee(x, y);
        }

        public void TerminerPartie()
        {
            Console.WriteLine("End Game");
        }
    }
}
