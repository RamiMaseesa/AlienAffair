using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint3.FrameWorkScripts
{
    public class Animate
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

        public Animate(float pAnimateSpeed, int pSpriteAmountX, int pSpriteAmountY, Texture2D pTexture)
        {
            animateSpeed = pAnimateSpeed;

            spriteAmountX = pSpriteAmountX;
            spriteAmountY = pSpriteAmountY;
            spriteSheet = pTexture;

            LoadContent();
        }

        private void LoadContent()
        {

            pixelAmountAdderX = spriteSheet.Width / spriteAmountX;
            pixelAmountAdderY = spriteSheet.Height / spriteAmountY;
        }

        public int[] PlayAnimation(GameTime pGameTime)
        {
            animateTimer += (float)pGameTime.ElapsedGameTime.TotalSeconds;

            if (animateTimer >= animateSpeed && currentSpriteAmountX != spriteSheet.Width)
            {
                currentSpriteAmountX += pixelAmountAdderX;
                animateTimer = 0;
                if (currentSpriteAmountX >= spriteSheet.Width)
                {
                    currentSpriteAmountY += pixelAmountAdderY;
                    currentSpriteAmountX = 0;
                }
                if (currentSpriteAmountY >= spriteSheet.Height)
                {
                    currentSpriteAmountY = 0;
                    animateTimer = 0;
                }
            }

            drawPos[0] = currentSpriteAmountX;
            drawPos[1] = currentSpriteAmountY;

            //Console.WriteLine(drawPos[0] + "     " + drawPos[1]);
            return drawPos;
        }
    }
}
