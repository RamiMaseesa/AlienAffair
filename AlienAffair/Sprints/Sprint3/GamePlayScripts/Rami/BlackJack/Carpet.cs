using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Rami.BlackJack
{
    public class Carpet : GameObject
    {
        public Carpet(Vector2 pPosition, string pPathToImage) : base(pPosition, pPathToImage)
        {
            position = pPosition;
            path = pPathToImage;
            rectangle = new Rectangle(0, 0, 1920, 1080);
            scale = 1f;
        }
    }
}
