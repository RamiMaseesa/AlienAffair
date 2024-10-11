using System;
using System.Text.Json.Serialization;
using AlienAffair.Sprints.Sprint2.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint2.GamePlayScripts.Rafael;

public class DialogueOption : ButtonBase
{

    public string answerText { get; set; }
    public string answerOutcome {get; set;}

    public DialogueOption()
    {
        objectActive = false;

        //Position of the button
        position = new Vector2(500, 200);
        
        //Rectangle of the sprite
        rectangle = new Rectangle((int)position.X, (int)position.Y, 0, 2);
        
        //Size of the Button
        scale = new Vector2(7, 1);
        color = new Color(198, 33, 30);
    }

    public override void DrawText(SpriteBatch pSpriteBatch, SpriteFont pGameFont)
    {
        Vector2 textSize = pGameFont.MeasureString(answerText);
        Vector2 textLocation = position;
        pSpriteBatch.DrawString(pGameFont, answerText, textLocation - (textSize * 1f / 2), Color.White);
    }

    public override void DrawSprite(SpriteBatch pSpriteBatch)
    {
        origin = new Vector2(rectangle.Width / 2f, rectangle.Height / 2f);
        pSpriteBatch.Draw(pixel, position, rectangle, color, 0, origin, scale, SpriteEffects.None, 0.0f);
    }

    protected override void Normal()
    {
        color = new Color(76, 90, 100);
        base.Normal();
    }
    protected override void Hovering()
    {
        color = new Color(64, 76, 85);
        base.Hovering();
    }
    protected override void Pressed()
    {
        color = new Color(76, 90, 100);
        base.Pressed();
    }

    public override void ButtonBehaviour()
    {
        base.ButtonBehaviour();
    }

    public void SetTexture(Texture2D backgroundSprite)
    {
        pixel = backgroundSprite;
        texture2D = pixel;
    }
}
