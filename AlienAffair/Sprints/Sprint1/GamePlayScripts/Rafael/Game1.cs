using AlienAffair.Sprints.Sprint1.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Text.Json;

namespace AlienAffair.Sprints.Sprint1.GamePlayScripts.Rafael
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Dialogue _currentDialogue;
        Dialogue[] _allDialogue;
        int index = 0;
        SpriteFont _gameFont;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 500; //_graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferWidth = 500; //_graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = false;
            //Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            
            var jsonFile = File.ReadAllText("Sprints/Sprint1/GamePlayScripts/Rafael/Dialogue.json");
            _allDialogue = JsonSerializer.Deserialize<Dialogue[]>(jsonFile);
            
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gameFont = Content.Load<SpriteFont>("Content/Fonts/File");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _currentDialogue = _allDialogue[index];

            base.Update(gameTime);
            KeyboardState kstate = Keyboard.GetState();
            if(kstate.IsKeyDown(Keys.Enter) && index < 1)
            {
                index++;
            }
            
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
                _currentDialogue.DrawText(_spriteBatch, _gameFont);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
