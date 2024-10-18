using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using AlienAffair.Sprints.Sprint3.GamePlayScripts.Elliot;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Rafael
{
    public class RafaelGame1 : Game1
    {

        public List<SceneBase> scenes = new List<SceneBase>();
        SceneBase _currentScene;

        public RafaelGame1()
        {
            //_graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1000; //_graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 700; //_graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = false;
            //IsMouseVisible = true;
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
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _currentScene = new MenuScene(game1Refference);
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
    }
}
