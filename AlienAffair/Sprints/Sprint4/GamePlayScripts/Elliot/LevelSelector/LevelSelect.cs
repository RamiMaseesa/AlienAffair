using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.LevelSelector
{
    public class LevelSelect : SceneBase
    {
        Texture2D background;
        
        public LevelSelect(Game1 pGame1) : base(pGame1)
        {
            CreateObjects();
        }

        protected override void CreateObjects()
        {
            background = game.Content.Load<Texture2D>("Sprites\\Backgrounds\\StarsBackground");

            LevelButton wanted = new LevelButton(GameStates.wantedMiniGame, new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, 300), new Rectangle(0, 0, 64, 32), "Wanted");
            LevelButton dodge = new LevelButton(GameStates.dodgeMinigame, new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, 450), new Rectangle(0, 0, 64, 32), "Dodge");
            LevelButton blackJack = new LevelButton(GameStates.ramiGame1Poker, new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, 600), new Rectangle(0, 0, 64, 32), "Black Jack");

            UiSceneContent.Add(wanted);
            UiSceneContent.Add(dodge);
            UiSceneContent.Add(blackJack);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            pSpriteBatch.DrawString(game.gameFont, "MINIGAMES", new Vector2(game.Window.ClientBounds.Width / 2, 200f), Color.Yellow, 0f, game.gameFont.MeasureString("MINIGAMES") / 2, 1f, SpriteEffects.None, 1f);

            base.Draw(pSpriteBatch);
        }
    }
}
