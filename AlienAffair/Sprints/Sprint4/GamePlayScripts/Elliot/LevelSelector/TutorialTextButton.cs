using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.LevelSelector.Tutorial;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.LevelSelector
{
    public class TutorialTextButton : ButtonBase
    {
        Tutorial tutorial;
        DisplayTutorialTextState state;

        public TutorialTextButton(Tutorial pTutorial, DisplayTutorialTextState pState, Vector2 pPosition, Rectangle pRectangle, string pButtonText) : base(pPosition, pRectangle, pButtonText)
        {
            {
                tutorial = pTutorial;
                state = pState;
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
            tutorial.ChangeState(state);
        }
    }
}
