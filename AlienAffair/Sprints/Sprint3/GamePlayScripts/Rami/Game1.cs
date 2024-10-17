using AlienAffair.Sprints.Sprint3.GamePlayScripts.Rami.BlackJack;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Rami
{
    public class RamiGame1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Table table;
        private Carpet carpet;
        private CardBase card;

        public RamiGame1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            table = new Table(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Sprites\\tafel");
            carpet = new Carpet(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Sprites\\tapijt");
            card = new CardBase(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), new string[] { "Sprites\\PokerClover", "Sprites\\PokerClubs", "Sprites\\PokerDiamand", "Sprites\\PokerHart" });
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            table.LoadSprite(Content);
            carpet.LoadSprite(Content);
            card.LoadSprite(Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            carpet.DrawSprite(_spriteBatch);
            table.DrawSprite(_spriteBatch);
            card.DrawSprite(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
