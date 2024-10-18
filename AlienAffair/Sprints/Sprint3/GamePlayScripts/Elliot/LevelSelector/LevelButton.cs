using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Elliot.LevelSelector
{
    public class LevelButton : ButtonBase
    {
        SceneBase returnScene;
        Game1 game1;

        public LevelButton(SceneBase pReturnScene, Game1 pGame1)
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
