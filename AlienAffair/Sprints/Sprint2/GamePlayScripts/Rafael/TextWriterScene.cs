using AlienAffair.Sprints.Sprint2.GamePlayScripts.Rafael;
using AlienAffair.Sprints.Sprint2.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Text.Json;
using AlienAffair.Sprints.Sprint2.GamePlayScripts;

namespace AlienAffair.Sprints.Sprint2.FrameWorkScripts
{
    public class TextWriterScene : SceneBase
    {
        //Dialogue _currentDialogue;
        Dialogue[] _allDialogue;
        int index = 0;

        SpriteFont _gameFont;
        Texture2D _pixel;
        //SoundEffect soundEffect;
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
                    //_currentDialogue.SetSoundEffect(soundEffect);
                }
            }
        }

        public TextWriterScene(Game1 pGame) : base(pGame)
        {
            //_game._graphics.PreferredBackBufferWidth = 1000; //_graphics.PreferredBackBufferWidth = 1920;
            //_game._graphics.PreferredBackBufferHeight = 700; //_graphics.PreferredBackBufferHeight = 1080;
            //_game._graphics.IsFullScreen = false;
            //_game.IsMouseVisible = true;
        }

        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);
            CurrentDialogue = _allDialogue[index];

            base.Update(pGameTime);
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
            _currentDialogue.Update(pGameTime);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
            _currentDialogue.Draw(pSpriteBatch, _gameFont);
        }

        public override void LoadContent(ContentManager pContent)
        {
            base.LoadContent(pContent);
            _gameFont = pContent.Load<SpriteFont>("Content\\Fonts\\File");
            _pixel = pContent.Load<Texture2D>("Content\\Sprites\\Pixel");

            var jsonFile = File.ReadAllText("Content/Json/Chapter1.json");
            _allDialogue = JsonSerializer.Deserialize<Dialogue[]>(jsonFile);

            for (int i = 0; i < _allDialogue.Length; i++)
            {
                _allDialogue[i].SetPixel(_pixel);
                _allDialogue[i].SetSpriteFont(_gameFont);
            }
        }
    }
}
