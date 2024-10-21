using System;
using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Rafael;

public class MinigamesButton : ButtonBase
{
    public MinigamesButton(Vector2 pPosition, Rectangle pRectangle) : base(pPosition, pRectangle)
    {
    }

    public MinigamesButton(Vector2 pPosition, Rectangle pRectangle, string pButtonText) : base(pPosition, pRectangle, pButtonText)
    {
        path = "Sprites/Button";
        scale = new Vector2(4f, 4f);
        rectangle = new Rectangle(0, 0, 64, 32);
    }

    public override void Draw(SpriteBatch pSpriteBatch)
    {
        base.Draw(pSpriteBatch);
    }

    public override void ButtonBehaviour()
    {
        base.ButtonBehaviour();
        game.ChangeScene(GameStates.LevelSelect);
    }


}