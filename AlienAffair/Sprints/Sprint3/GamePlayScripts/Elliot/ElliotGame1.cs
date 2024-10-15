using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AlienAffair.Sprints.Sprint3.FrameWorkScripts;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Elliot
{
    public class ElliotGame1 : Game1
    {
        private WantedMiniGame wantedMiniGame;

        private DodgeMinigame dodgeMiniGame;
        public ElliotGame1()
        {
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = false;
            IsMouseVisible = true;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //wantedMiniGame = new WantedMiniGame(Content, game1Refference);

            dodgeMiniGame = new DodgeMinigame(Content, game1Refference);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //wantedMiniGame.Update(gameTime);
            dodgeMiniGame.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Snow);
            _spriteBatch.Begin();
            dodgeMiniGame.Draw(_spriteBatch);
            //wantedMiniGame.Draw(_spriteBatch);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
