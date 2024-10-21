using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Rami.BlackJack
{
    public class Table : GameObject
    {
        public Table(Vector2 pPosition, string pPathToImage) : base(pPosition, pPathToImage)
        {
            position = pPosition;
            path = pPathToImage;
            rectangle = new Rectangle(0, 0, 96, 64);
            scale = 15f;
        }
    }
}
