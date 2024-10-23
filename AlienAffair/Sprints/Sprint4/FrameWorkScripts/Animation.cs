using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace AlienAffair.Sprints.Sprint4.FrameWorkScripts
{
    public class Animation
    {
        private Texture2D spriteSheet;

        private int[] drawPos = new int[2];

        private float animateSpeed = 0;
        private float animateTimer = 0;

        private int spriteAmountX = 0;
        private int spriteAmountY = 0;

        private int currentSpriteAmountX = 0;
        private int currentSpriteAmountY = 0;

        private int pixelAmountAdderX = 0;
        private int pixelAmountAdderY = 0;

        private bool reachedEnd = false;

        public Animation(float pAnimateSpeed, int pSpriteAmountX, int pSpriteAmountY, Texture2D pTexture)
        {
            animateSpeed = pAnimateSpeed;

            spriteAmountX = pSpriteAmountX;
            spriteAmountY = pSpriteAmountY;
            spriteSheet = pTexture;

            SpriteSize();
        }

        private void SpriteSize()
        {

            pixelAmountAdderX = spriteSheet.Width / spriteAmountX;
            pixelAmountAdderY = spriteSheet.Height / spriteAmountY;
        }

        public Rectangle PlayAnimation(GameTime pGameTime)
        {
            animateTimer += (float)pGameTime.ElapsedGameTime.TotalSeconds;

            if (animateTimer >= animateSpeed && currentSpriteAmountX != spriteSheet.Width)
            {
                currentSpriteAmountX += pixelAmountAdderX;
                animateTimer = 0;
                reachedEnd = false;
                if (currentSpriteAmountX >= spriteSheet.Width)
                {
                    currentSpriteAmountY += pixelAmountAdderY;
                    currentSpriteAmountX = 0;
                    reachedEnd = false;
                }
                if (currentSpriteAmountY >= spriteSheet.Height)
                {
                    currentSpriteAmountY = 0;
                    animateTimer = 0;
                }
            }
            drawPos[0] = currentSpriteAmountX;
            drawPos[1] = currentSpriteAmountY;
            Console.WriteLine(drawPos[0] + "    " + drawPos[1]);

            //Console.WriteLine(drawPos[0] + "     " + drawPos[1]);
            return new Rectangle(drawPos[0], drawPos[1], pixelAmountAdderX, pixelAmountAdderY);
        }

        public bool CheckForEnd()
        {
            return currentSpriteAmountY + pixelAmountAdderY >= spriteSheet.Height;
        }

        public Rectangle ReachedEnd()
        {
            return new Rectangle(spriteSheet.Width - pixelAmountAdderX, spriteSheet.Height - pixelAmountAdderY, pixelAmountAdderX, pixelAmountAdderY);
        }
    }
}
