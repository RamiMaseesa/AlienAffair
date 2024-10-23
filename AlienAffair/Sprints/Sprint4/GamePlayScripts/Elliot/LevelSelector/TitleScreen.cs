using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.LevelSelector
{
    public class TitleScreen : SceneBase
    {
        SpriteFont font;
        Texture2D background;
        float flickerTime = 1;
        string title = "Alien Affair";
        string playText = ">Press enter to start<";

        public TitleScreen(Game1 pGame1) : base(pGame1)
        {
            background = game.Content.Load<Texture2D>("Sprites\\Backgrounds\\TitleScreenDark");
            font = game.Content.Load<SpriteFont>("Fonts\\WantedGameFont");
        }

        public override void Update(GameTime pGameTime)
        {
            ToMenu();
            FlickerLight(pGameTime);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            pSpriteBatch.DrawString(font, title, new Vector2(game.Window.ClientBounds.Width / 2, game.Window.ClientBounds.Height / 6f), Color.LightGoldenrodYellow, 0f, font.MeasureString(title) / 2, 1.5f, SpriteEffects.None, 1f);
            pSpriteBatch.DrawString(game.gameFont, playText, new Vector2(game.Window.ClientBounds.Width / 2, game.Window.ClientBounds.Height / 1.5f), Color.LightGoldenrodYellow, 0f, game.gameFont.MeasureString(playText) / 2, 1f, SpriteEffects.None, 1f);
        }

        private void FlickerLight(GameTime pGameTime)
        {
            flickerTime -= (float)pGameTime.ElapsedGameTime.TotalSeconds;

            Random rnd = new Random();

            if (flickerTime <= 0)
            {

                int lightOrDark = rnd.Next(1, 10);
                if (lightOrDark > 3)
                {
                    background = game.Content.Load<Texture2D>("Sprites\\Backgrounds\\TitleScreenDark");
                }
                else
                {
                    background = game.Content.Load<Texture2D>("Sprites\\Backgrounds\\TitleScreenLight");
                }
                float decimalNumber = rnd.Next(1, 100) / 100;
                flickerTime = rnd.Next(0, 2) + decimalNumber;
            }
        }

        private void ToMenu()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                game.ChangeScene(GameStates.MenuScene);
            }
        }
    }
}
