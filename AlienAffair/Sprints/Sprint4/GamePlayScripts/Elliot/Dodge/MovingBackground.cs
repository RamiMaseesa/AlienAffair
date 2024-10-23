using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.Dodge
{

    public class MovingBackground
    {
        Game1 game1;

        Texture2D backgroundTexture;

        float backgroundSpeed = 50;

        bool first = false;

        Vector2 posBackgroundOne;
        Vector2 posBackgroundTwo;

        public MovingBackground(Game1 pGame1, float pBackgroundSpeed)
        {
            game1 = pGame1;
            backgroundSpeed = pBackgroundSpeed;

            backgroundTexture = pGame1.Content.Load<Texture2D>("Sprites\\Backgrounds\\ForestBackground");
            posBackgroundOne = new Vector2(0, 0);
            posBackgroundTwo = new Vector2(game1.Window.ClientBounds.Width, 0);
        }

        public void MoveBackground(GameTime pGameTime)
        {
            if (posBackgroundOne.X <= 0 - game1.Window.ClientBounds.Width)
            {
                posBackgroundOne = new Vector2(game1.Window.ClientBounds.Width - (float)pGameTime.ElapsedGameTime.TotalSeconds * backgroundSpeed, 0);
            }

            if (posBackgroundTwo.X <= 0 - game1.Window.ClientBounds.Width)
            {
                posBackgroundTwo = new Vector2(game1.Window.ClientBounds.Width - (float)pGameTime.ElapsedGameTime.TotalSeconds * backgroundSpeed, 0);
            }

            posBackgroundOne.X -= (float)pGameTime.ElapsedGameTime.TotalSeconds * backgroundSpeed;
            posBackgroundTwo.X -= (float)pGameTime.ElapsedGameTime.TotalSeconds * backgroundSpeed;
        }

        public void DrawBackground(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(backgroundTexture, posBackgroundOne, Color.White);
            pSpriteBatch.Draw(backgroundTexture, posBackgroundTwo, Color.White);
        }

        public void ChangeSpeed(float pNewSpeed)
        {
            backgroundSpeed = pNewSpeed;
        }
    }
}
