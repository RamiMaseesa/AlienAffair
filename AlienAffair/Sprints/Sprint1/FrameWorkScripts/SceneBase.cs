using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AlienAffair.Sprints.Sprint1.GamePlayScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint1.FrameWorkScripts
{

public class SceneBase
    {
        public List<GameObject> sceneContent = new List<GameObject>();
        public Game1 _game;

        public SceneBase( Game1 pGame)
        {
            _game = pGame;
            //_game.scenes.Add(this);
        }

        public virtual void Update(GameTime pGameTime)
        {
            for (int i = sceneContent.Count - 1; i >= 0; i--)
            {
                GameObject gameObject = sceneContent[i];
                gameObject.Update(pGameTime);
            }
        }

        protected virtual void CreateObjects()
        {   
            //empty
        }

        public virtual void LoadContent(ContentManager pContent)
        {
            foreach (GameObject gameObject in sceneContent)
            {
                gameObject.LoadSprite(pContent);
            }
        }

        public virtual void Draw(SpriteBatch pSpriteBatch, Texture2D pPixel)
        {
            foreach (GameObject gameObject in sceneContent)
            {
                gameObject.Draw(pSpriteBatch);
            }
        }
    }
}
