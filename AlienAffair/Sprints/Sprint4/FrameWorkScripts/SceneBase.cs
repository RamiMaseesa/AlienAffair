using System;
using System.Collections.Generic;
using AlienAffair.Sprints.Sprint4.GamePlayScripts;
using AlienAffair.Sprints.Sprint4.GamePlayScripts.Rami;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint4.FrameWorkScripts
{

    public class SceneBase
    {
        /// <summary>List that keeps track of all the GameObjects in a scene</summary>
        public List<GameObject> sceneContent = new List<GameObject>();
        public List<UiObject> UiSceneContent = new List<UiObject>();

        /// <summary>Refference to the game1</summary>
        public Game1 game;

        /// <summary>
        /// New Normal Scene
        /// </summary>
        /// <param name="pGame"></param>
        public SceneBase(Game1 pGame)
        {
            game = pGame;
            game.scenes.Add(this);
        }

        /// <summary>
        /// Plays the <see cref="GameObject.Update"/> every GameObject in <see cref="sceneContent"/>.
        /// </summary>
        /// <param name="pGameTime"></param>
        public virtual void Update(GameTime pGameTime)
        {
            for (int i = sceneContent.Count - 1; i >= 0; i--)
            {
                GameObject gameObject = sceneContent[i];
                gameObject.Update(pGameTime);
            }
            for (int i = UiSceneContent.Count - 1; i >= 0; i--)
            {
                UiObject gameObject = UiSceneContent[i];
                gameObject.Update(pGameTime);
            }
        }

        /// <summary>
        /// Loads the sprite info into <see cref="texture2D"/> for every object in <see cref="sceneContent"/>.
        /// </summary>
        /// <param name="pContent"></param>
        public virtual void LoadContent(ContentManager pContent)
        {
            foreach (GameObject gameObject in sceneContent)
            {
                gameObject.LoadSprite(pContent);
            }
            foreach (UiObject gameObject in UiSceneContent)
            {
                gameObject.LoadSprite(pContent);
            }
        }

        /// <summary>
        /// Plays the <see cref="GameObject.Draw"/> method for every GameObject in <see cref="sceneContent"/>
        /// </summary>
        /// <param name="pSpriteBatch"></param>
        public virtual void Draw(SpriteBatch pSpriteBatch)
        {
            foreach (GameObject gameObject in sceneContent)
            {
                gameObject.Draw(pSpriteBatch);
            }
            foreach (UiObject gameObject in UiSceneContent)
            {
                gameObject.Draw(pSpriteBatch, game.gameFont);
            }
        }

        /// <summary>
        /// Use this method to add all your objects to the sceneContent
        /// </summary>
        protected virtual void CreateObjects()
        {
            //empty
        }
    }
}
