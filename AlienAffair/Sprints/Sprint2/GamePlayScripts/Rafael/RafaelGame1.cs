using AlienAffair.Sprints.Sprint2.FrameWorkScripts;
using AlienAffair.Sprints.Sprint2.GamePlayScripts.Elliot;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AlienAffair.Sprints.Sprint2.GamePlayScripts.Rafael
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
            
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _currentScene = new TextWriterScene(game1Refference);
            _currentScene.LoadContent(Content);
            
            foreach(SceneBase scene in scenes)
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

            /*if(kstate.IsKeyDown(Keys.F))
            {
                _currentScene = new WantedMiniGame(Content, game1Refference);
                _graphics.PreferredBackBufferWidth = 1920;
                _graphics.PreferredBackBufferHeight = 1080;
                _graphics.ApplyChanges();
            }*/    

            _currentScene.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.DimGray);
            _spriteBatch.Begin();
            _currentScene.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
