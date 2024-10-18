using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Rami.BlackJack
{
    public class CardBase : GameObject
    {
        private string[] paths;
        public CardBase(Vector2 pPosition, string[] pPathToImage) : base(pPosition, pPathToImage[0])
        {
            position = pPosition;
            paths = pPathToImage;
            rectangle = new Rectangle(0, 0, 80, 120);
        }

        public override void LoadSprite(ContentManager pContent)
        {
            
        }

        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);
        }
    }
}
