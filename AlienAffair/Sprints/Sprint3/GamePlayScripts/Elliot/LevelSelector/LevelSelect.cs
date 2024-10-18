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
            LevelButton wanted = new LevelButton(pScenes[0], _game);
            LevelButton dodge = new LevelButton(pScenes[1], _game);
            LevelButton blackJack = new LevelButton(pScenes[2], _game);
        }

    }
}
