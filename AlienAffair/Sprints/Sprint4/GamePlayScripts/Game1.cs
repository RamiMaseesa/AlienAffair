using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot;
using AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.Dodge;
using AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.LevelSelector;
using AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.Wanted;
using AlienAffair.Sprints.Sprint4.GamePlayScripts.Rafael;
using AlienAffair.Sprints.Sprint4.GamePlayScripts.Rami.BlackJack;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts
{
    public class Game1 : Game
    {
        protected GraphicsDeviceManager _graphics;
        protected SpriteBatch _spriteBatch;

        public SpriteFont gameFont;
        public Texture2D pixel;

        public Game1 game1Refference;
        public List<SceneBase> scenes = new List<SceneBase>();

        public BackgroundManager backgroundManager;

        SceneBase _previousScene;
        SceneBase _currentScene;
        public SceneBase CurrentScene
        {
            get { return _currentScene; }
            set
            {
                if (_currentScene != value)
                {
                    _previousScene = _currentScene;
                    System.Console.WriteLine("PreviousScene: " + _previousScene);
                    _currentScene = value;
                }
            }
        }


        public GameStates currentState = GameStates.TitleScreen;

        TitleScreen titleScreen;
        TextWriterScene textWriterScene;
        MenuScene menuScene;
        LevelSelect levelSelect;
        WantedMiniGame wantedMiniGame;
        DodgeMinigame dodgeMinigame;
        RamiGame1Poker ramiGame1Poker;
        Tutorial tutorial;
        MenuButton menuButton;
        EndScene endScene;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            game1Refference = this;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            gameFont = Content.Load<SpriteFont>("Fonts\\File");
            pixel = Content.Load<Texture2D>("Sprites\\Pixel");
            backgroundManager = new BackgroundManager(game1Refference);

            ResetScenes();


            for (int i = scenes.Count - 1; i >= 0; i--)
            {
                foreach (GameObject gameObject in scenes[i].sceneContent)
                {
                    gameObject.Initialize(game1Refference);
                }
                foreach (UiObject uiGameObject in scenes[i].UiSceneContent)
                {
                    uiGameObject.Initialize(game1Refference);
                }
            }
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _currentScene.LoadContent(Content);

            foreach (SceneBase scene in scenes)
            {
                scene.LoadContent(Content);
            }
        }



        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState kstate = Keyboard.GetState();

            menuButton.Update(gameTime);

            _currentScene.Update(gameTime);

            switch(textWriterScene.GetDialogueManager().DialogueKey)
            {
                case "Poker":
                    _currentScene = ramiGame1Poker;
                    break;
                case "DodgeMinigame":
                    _currentScene = dodgeMinigame;
                    break;
                case "WantedMinigame":
                    _currentScene = wantedMiniGame;
                    break;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.DarkGoldenrod);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            backgroundManager.Draw(_spriteBatch);
            _currentScene.Draw(_spriteBatch);
            //_currentScene.Draw(_spriteBatch);
            menuButton.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public virtual void ChangeScene(GameStates pState)
        {
            _currentScene = scenes[(int)pState];
            currentState = pState;
            _currentScene.OnSceneEnter();
        }

        private void ResetScenes()
        {
            scenes.Clear();

            // MenuScene,
            // LevelSelect,
            // textWriterScene,
            // wantedMiniGame,
            // dodgeMinigame,
            // ramiGame1Poker

            menuButton = new MenuButton(game1Refference, new Vector2(_graphics.PreferredBackBufferWidth - 164, _graphics.PreferredBackBufferHeight - 164), new Rectangle(0, 0, 64, 32), gameFont, "Menu");
            menuButton.LoadSprite(Content);


            titleScreen = new TitleScreen(game1Refference);
            menuScene = new MenuScene(game1Refference);
            endScene = new EndScene(game1Refference, 16);
            tutorial = new Tutorial(game1Refference);
            levelSelect = new LevelSelect(game1Refference);
            textWriterScene = new TextWriterScene(game1Refference);
            wantedMiniGame = new WantedMiniGame(Content, game1Refference);
            dodgeMinigame = new DodgeMinigame(Content, game1Refference);
            ramiGame1Poker = new RamiGame1Poker(game1Refference);

            currentState = GameStates.TitleScreen;
            _currentScene = titleScreen;
            _currentScene.OnSceneEnter();

            for (int i = scenes.Count - 1; i >= 0; i--)
            {
                foreach (GameObject gameObject in scenes[i].sceneContent)
                {
                    gameObject.Initialize(game1Refference);
                }
            }
        }

        public GraphicsDeviceManager GetGraphics()
        {
            return _graphics;
        }

        public void LoadGame1()
        {
            LoadContent();
            currentState = GameStates.MenuScene;
            _currentScene = menuScene;
        }

        public GameStates GetCurrentScene()
        {
            return currentState;
        }

        public SceneBase GetPreviousScene()
        {
            return _previousScene;
        }

        public void EndMinigame()
        {
            if (GetPreviousScene() is TextWriterScene)
            {
                ChangeScene(GameStates.textWriterScene);
            }
            else
            {
                LoadGame1();
            }
        }
    }
}
