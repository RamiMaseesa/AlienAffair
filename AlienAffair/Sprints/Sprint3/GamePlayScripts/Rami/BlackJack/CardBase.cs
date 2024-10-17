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
        private Texture2D[] sprites;
        private string[] paths;
        private SpriteFont cardFont;
        public int value;
        public CardBase(Vector2 pPosition, string[] pPathToImage) : base(pPosition, pPathToImage[0])
        {
            position = pPosition;
            rectangle = new Rectangle(0, 0, 80, 120);
            paths = pPathToImage;
        }

        public override void LoadSprite(ContentManager pContent)
        {
            sprites = new Texture2D[paths.Length];

            for (int i = 0; i < paths.Length; i++)
            {
                sprites[i] = pContent.Load<Texture2D>(paths[i]);
            }

            Random rnd = new Random();

            texture2D = sprites[rnd.Next(0, paths.Length)];
            value = rnd.Next(1,11);
            Console.WriteLine(value);

            cardFont = pContent.Load<SpriteFont>("Fonts/File");
        }

        public override void DrawSprite(SpriteBatch pSpriteBatch)
        {
            base.DrawSprite(pSpriteBatch);

            Vector2 scale = new Vector2(2f, 2f);

            pSpriteBatch.DrawString(cardFont, value.ToString(), position + new Vector2(-80, -150), Color.Black,
                                    0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            pSpriteBatch.DrawString(cardFont, value.ToString(), position + new Vector2(70, 100), Color.Black,
                                    0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }
}
