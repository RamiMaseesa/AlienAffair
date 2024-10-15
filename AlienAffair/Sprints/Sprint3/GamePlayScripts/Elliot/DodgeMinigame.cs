using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Elliot
{
    public class DodgeMinigame : SceneBase
    {
        private int[] drawPosJaguar = new int[2];
        Texture2D jaguarSprite;
        Animate jaguarAnimation;
        Rectangle jaguarRec;

        public DodgeMinigame(ContentManager pContent, Game1 pGame1) : base(pGame1)
        {
            LoadContent(pContent);
        }

        public override void LoadContent(ContentManager pContent)
        {
            base.LoadContent(pContent);
            jaguarSprite = pContent.Load<Texture2D>("Content\\Sprites\\JaguarSpriteSheet");
            jaguarAnimation = new Animate(0.1f, 1, 3, jaguarSprite);
        }

        public override void Update(GameTime pGameTime)
        {
            drawPosJaguar = jaguarAnimation.PlayAnimation(pGameTime);
            Console.WriteLine(drawPosJaguar[0] + "    " + drawPosJaguar[1]);
            jaguarRec = new Rectangle(drawPosJaguar[0], drawPosJaguar[1], 128, 64);
            //base.Update(pGameTime);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(jaguarSprite, new Vector2(500, 500), jaguarRec, Color.White, 0, new Vector2(0, 0), 5f, SpriteEffects.None, 0.0f);
            //base.Draw(pSpriteBatch);
        }
    }
}
