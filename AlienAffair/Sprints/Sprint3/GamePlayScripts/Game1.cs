using System.Collections.Generic;
using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using AlienAffair.Sprints.Sprint3.GamePlayScripts.Rafael;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AlienAffair.Sprints.Sprint3.GamePlayScripts.Elliot.Dodge;
using AlienAffair.Sprints.Sprint3.GamePlayScripts.Rami;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts
{
    public class Game1 : Game
    {
        protected GraphicsDeviceManager _graphics;
        protected SpriteBatch _spriteBatch;

        public Game1 game1Refference;
        public List<SceneBase> scenes = new List<SceneBase>();
        SceneBase _currentScene;

        TextWriterScene textWriterScene;
        Elliot.Wanted.WantedMiniGame wantedMiniGame;
        DodgeMinigame dodgeMinigame;
        RamiGame1Poker pokerMinigame;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = false;
            IsMouseVisible = true;
            game1Refference = this;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
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
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            ResetScenes();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //_currentScene = new MenuScene(game1Refference);
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

            _currentScene.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.DarkGoldenrod);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _currentScene.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        protected virtual void ChangeScene()
        {

        }

        private void ResetScenes()
        {
            scenes.Clear();

            textWriterScene = new TextWriterScene(game1Refference);
            wantedMiniGame = new Elliot.Wanted.WantedMiniGame(Content, game1Refference);
            dodgeMinigame = new DodgeMinigame(Content, game1Refference);

            _currentScene = pokerMinigame;
            for (int i = scenes.Count - 1; i >= 0; i--)
            {
                foreach (GameObject gameObject in scenes[i].sceneContent)
                {
                    gameObject.Initialize(game1Refference);
                }
            }
            //ReloadSceneContent();
        }
    }
}
