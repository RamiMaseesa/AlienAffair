using AlienAffair.Sprints.Sprint1.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Text.Json;

namespace AlienAffair.Sprints.Sprint2.GamePlayScripts.Rafael
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //Dialogue _currentDialogue;
        Dialogue[] _allDialogue;
        int index = 0;

        SpriteFont _gameFont;
        Texture2D _pixel;
        SoundEffect soundEffect;
        bool keyPressed = false;
        bool keyPressed2 = false;

        //Tutorial on https://www.tutlane.com/tutorial/csharp/csharp-properties-get-set
        Dialogue _currentDialogue;
        public Dialogue CurrentDialogue
        {
            get { return _currentDialogue; }
            set
            {
                if (_currentDialogue != value)
                {
                    _currentDialogue = value;
                    _currentDialogue.ResetDialogue();
                    _currentDialogue.SetPixel(_pixel);
                    _currentDialogue.SetSpriteFont(_gameFont);
                    _currentDialogue.SetSoundEffect(soundEffect);
                }
            }
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1000; //_graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 700; //_graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = false;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();

            //load this in the dialogue class itself (Maybe)?
            var jsonFile = File.ReadAllText("Content/Json/Dialogue.json");
            _allDialogue = JsonSerializer.Deserialize<Dialogue[]>(jsonFile);

            for (int i = 0; i < _allDialogue.Length; i++)
            {
                _allDialogue[i].SetPixel(_pixel);
                _allDialogue[i].SetSpriteFont(_gameFont);
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gameFont = Content.Load<SpriteFont>("Content\\Fonts\\File");
            _pixel = Content.Load<Texture2D>("Content\\Sprites\\Pixel");
            soundEffect = Content.Load<SoundEffect>("Content\\Sound\\Er (copy)");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            CurrentDialogue = _allDialogue[index];

            base.Update(gameTime);
            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.E))
                keyPressed = true;
            else if (kstate.IsKeyUp(Keys.E) && keyPressed && index < _allDialogue.Length - 1)
            {
                index++;
                keyPressed = false;
            }
             if (kstate.IsKeyDown(Keys.Q))
                keyPressed2 = true;
            else if (kstate.IsKeyUp(Keys.Q) && keyPressed2 && index != 0)
            {
                index--;
                keyPressed2 = false;
            }
            _currentDialogue.Update(gameTime);


        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _currentDialogue.Draw(_spriteBatch, _gameFont);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
