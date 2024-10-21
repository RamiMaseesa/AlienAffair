using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.LevelSelector
{
    public class LevelButton : ButtonBase
    {
        GameStates _returnScene;

        public LevelButton(GameStates pToScene,Vector2 pPosition, Rectangle pRectangle, string pButtonText) : base(pPosition, pRectangle, pButtonText)
        {
            path = "Sprites/Button";
            scale = new Vector2(4f, 4f);
            rectangle = new Rectangle(0, 0, 64, 32);
            _returnScene = pToScene;
        }

        public override void Draw(SpriteBatch pSpriteBatch, SpriteFont pGameFont)
        {
            base.Draw(pSpriteBatch, pGameFont);
        }

        public override void ButtonBehaviour()
        {
            base.ButtonBehaviour();
            game.ChangeScene(_returnScene);

        }
    }
}
