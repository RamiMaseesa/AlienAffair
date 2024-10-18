using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Elliot.LevelSelector
{
    public class LevelButton : ButtonBase
    {
        SceneBase returnScene;
        Game1 game1;

        public LevelButton(SceneBase pReturnScene, Game1 pGame1, Vector2 pPos, Rectangle pRectangle, string pText) : base(pPos, pRectangle, pText)
        {
            returnScene = pReturnScene;
            game1 = pGame1;
        }

        public override void Draw(SpriteBatch pSpriteBatch, SpriteFont pGameFont)
        {
            base.Draw(pSpriteBatch, pGameFont);
        }

        public override void ButtonBehaviour()
        {
            base.ButtonBehaviour();
            //game1.ChangeScene(returnScene);
        }
    }
}
