using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Elliot.LevelSelector
{
    public class LevelSelect : SceneBase
    {
        public LevelSelect(Game1 pGame1) : base(pGame1)
        {
            CreateObjects();
        }

        protected override void CreateObjects()
        {
            LevelButton wanted = new LevelButton(GameStates.wantedMiniGame, new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, 500), new Rectangle(0, 0, 64, 32), "Wanted");
            LevelButton dodge = new LevelButton(GameStates.dodgeMinigame, new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, 600), new Rectangle(0, 0, 64, 32), "Dodge");
            LevelButton blackJack = new LevelButton(GameStates.ramiGame1Poker, new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, 700), new Rectangle(0, 0, 64, 32), "Black Jack");

            UiSceneContent.Add(wanted);
            UiSceneContent.Add(dodge);
            UiSceneContent.Add(blackJack);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
        }
    }
}
