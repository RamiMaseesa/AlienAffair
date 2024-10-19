using System;
using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Rafael;

public class ExitButton : ButtonBase
{
    public ExitButton(Vector2 pPosition, Rectangle pRectangle, string pButtonText) : base(pPosition, pRectangle, pButtonText)
    {
        path = "Sprites/Button";
        scale = new Vector2(4f, 4f);
        rectangle = new Rectangle(0, 0, 64, 32);
    }

    public override void ButtonBehaviour()
    {
        base.ButtonBehaviour();
        game.Exit();
    }
}
