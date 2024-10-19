using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Elliot.LevelSelector
{
    public class LevelButton : ButtonBase
    {
        SceneBase returnScene;

        public LevelButton(SceneBase pToScene,Vector2 pPosition, Rectangle pRectangle) : base(pPosition, pRectangle)
        {
            path = "Content/Sprites/Button";
            scale = new Vector2(4f, 4f);
            //printedText = pPrintedText;
            rectangle = new Rectangle(0, 0, 64, 32);
            returnScene = pToScene;
        }

        public override void Draw(SpriteBatch pSpriteBatch, SpriteFont pGameFont)
        {
            base.Draw(pSpriteBatch, pGameFont);
        }

        public override void ButtonBehaviour()
        {
            base.ButtonBehaviour();
            game.ChangeScene(returnScene);

        }
    }
}
