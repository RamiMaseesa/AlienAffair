using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.LevelSelector
{
    public class TutorialButton : ButtonBase
    {
        public TutorialButton(Vector2 pPosition, Rectangle pRectangle, string pButtonText) : base(pPosition, pRectangle, pButtonText)
        {
            {
                path = "Sprites/Button";
                scale = new Vector2(4f, 4f);
                rectangle = new Rectangle(0, 0, 64, 32);
            }
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
        }

        public override void ButtonBehaviour()
        {
            base.ButtonBehaviour();
            game.ChangeScene(GameStates.Tutorial);
        }
    }
}
