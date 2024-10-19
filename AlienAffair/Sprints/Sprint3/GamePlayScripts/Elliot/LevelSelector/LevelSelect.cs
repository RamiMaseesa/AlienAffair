using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Elliot.LevelSelector
{
    public class LevelSelect : SceneBase
    {
        public LevelSelect(Game1 pGame1, List<SceneBase> pScenes) : base(pGame1)
        {
            CreateButtons(pScenes);
        }

        protected void CreateButtons(List<SceneBase> pScenes)
        {
            //LevelButton wanted = new LevelButton(pScenes[0], new Vector2(500, 500), new Rectangle(0, 0, 64, 32), "Wanted");
            //LevelButton dodge = new LevelButton(pScenes[1], new Vector2(500, 600), new Rectangle(0, 0, 64, 32), "Dodge");
            //LevelButton blackJack = new LevelButton(pScenes[2], new Vector2(500, 700), new Rectangle(0, 0, 64, 32), "Black Jack");

            //UiSceneContent.Add(wanted);
            //UiSceneContent.Add(wanted);
            //UiSceneContent.Add(wanted);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
        }
    }
}
