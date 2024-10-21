using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Rami.BlackJack
{
    internal class ButtonHit : ButtonBase
    {
        private string text;
        private PokerManager poker;
        public ButtonHit(Vector2 pPosition, Texture2D pSprite, string pButtonText, PokerManager poker) : base(pPosition, pSprite, pButtonText)
        {
            rectangle = new Rectangle(0, 0, 64, 32);
            scale = new Vector2(3, 3);
            printedText = pButtonText;
            this.poker = poker;
        }

        protected override void Normal()
        {
            base.Normal();
            rectangle = new Rectangle(3, 3, 58, 26);
            color = Color.White;
        }
        protected override void Pressed()
        {
            base.Pressed();
            rectangle = new Rectangle(67, 10, 58, 26);
        }
        protected override void Hovering()
        {
            base.Hovering();
            color = Color.White;
        }

        public override void ButtonBehaviour()
        {
            poker.OnHit();
        }

        public override void Draw(SpriteBatch pSpriteBatch, SpriteFont pGameFont)
        {
            base.Draw(pSpriteBatch, pGameFont);
        }
    }
}
