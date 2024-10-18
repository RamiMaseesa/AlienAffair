using System;
using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Rafael;

public class MenuScene : SceneBase
{
        public MenuScene(Game1 pGame) : base(pGame)
        {
            CreateObjects();
        }

        protected override void CreateObjects()
        {
            base.CreateObjects();

            UiSceneContent.Add(new PlayButton(new Vector2(500, 300), new Rectangle(3, 35, 58, 26)));
            UiSceneContent.Add(new PlayButton(new Vector2(500, 450), new Rectangle(3, 35, 58, 26)));
            UiSceneContent.Add(new ExitButton(new Vector2(500, 600), new Rectangle(3, 35, 58, 26)));
        }
}
