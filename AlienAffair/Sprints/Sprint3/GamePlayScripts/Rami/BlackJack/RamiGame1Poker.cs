using AlienAffair.Sprints.Sprint3.FrameWorkScripts;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Rami.BlackJack
{
    public class RamiGame1Poker : SceneBase
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Table table;
        private Carpet carpet;
        private PokerManager pokerManager;
        private ButtonStand buttonStand;
        private ButtonHit buttonHit;

        public RamiGame1Poker(Game1 game1) : base(game1)
        {
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = false;
            game1.Content.RootDirectory = "Content";
            game1.IsMouseVisible = true;

            //table = new Table(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Sprites\\tafel");
            //carpet = new Carpet(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Sprites\\tapijt");
        }

        protected override void CreateObjects()
        {
            // TODO: Add your initialization logic here
            pokerManager.OnGameStart();
            sceneContent.Add(new Table(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Sprites\\tafel"));
            sceneContent.Add(new Carpet(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Sprites\\tapijt"));
            UiSceneContent.Add(new ButtonStand(new Vector2(150, 200), _game.Content.Load<Texture2D>("Sprites\\Button"), "STAND", pokerManager));
            UiSceneContent.Add(new ButtonHit(new Vector2(_graphics.PreferredBackBufferWidth - 150, 200), _game.Content.Load<Texture2D>("Sprites\\Button"), "HIT", pokerManager));
        }

        // public override void LoadContent(ContentManager pContent)
        // {
        //     //table = new Table(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Sprites\\tafel");
        //     //carpet = new Carpet(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Sprites\\tapijt");
        //     //buttonStand = new ButtonStand(new Vector2(150, 200), _game.Content.Load<Texture2D>("Sprites\\Button"), "STAND", pokerManager);
        //     //buttonHit = new ButtonHit(new Vector2(_graphics.PreferredBackBufferWidth - 150, 200), _game.Content.Load<Texture2D>("Sprites\\Button"), "HIT", pokerManager);
        //     // TODO: use this.Content to load your game content here
        // }

        public override void Draw(SpriteBatch pSpritebatch)
        {
            _game.GraphicsDevice.Clear(Color.CornflowerBlue);

            pSpritebatch.Begin(samplerState: SamplerState.PointClamp);
            pokerManager.Draw(_spriteBatch);
            pSpritebatch.End();

            base.Draw(pSpritebatch);
        }
    }
}
