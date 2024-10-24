using System;
using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Rami.BlackJack
{
    public class RamiGame1Poker : SceneBase
    {
        //private Table table;
        //private Carpet carpet;
        private PokerManager pokerManager;
        //private ButtonStand buttonStand;
        //private ButtonHit buttonHit;

        public RamiGame1Poker(Game1 game1) : base(game1)
        {
            pokerManager = new PokerManager(game.GetGraphics(), game.Content, game);
            CreateObjects();
        }

        protected override void CreateObjects()
        {
            // TODO: Add your initialization logic here
            base.CreateObjects();
            pokerManager.OnGameStart();
            sceneContent.Add(new Carpet(new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, game.GetGraphics().PreferredBackBufferHeight / 2), "Sprites\\tapijt"));
            sceneContent.Add(new Table(new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, game.GetGraphics().PreferredBackBufferHeight / 2), "Sprites\\tafel"));
            UiSceneContent.Add(new ButtonStand(new Vector2(150, 200), game.Content.Load<Texture2D>("Sprites\\Button"), "STAND", pokerManager));
            UiSceneContent.Add(new ButtonHit(new Vector2(game.GetGraphics().PreferredBackBufferWidth - 150, 200), game.Content.Load<Texture2D>("Sprites\\Button"), "HIT", pokerManager));
        }

        public override void Draw(SpriteBatch pSpritebatch)
        {
            base.Draw(pSpritebatch);
            game.GraphicsDevice.Clear(Color.CornflowerBlue);
            pokerManager.Draw(pSpritebatch);
        }
    }
}
