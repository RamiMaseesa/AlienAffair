using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Rafael;

public class DialogueOption : ButtonBase
{
    public string AnswerText { get; set; }
    public string Next {get; set;}
    public DialogueManager dialogueManager;

    public DialogueOption()
    {
        objectActive = false;

        //Position of the button
        position = new Vector2(500, 200);
        
        //Rectangle of the sprite
        rectangle = new Rectangle(0, 0, 2, 2);
        
        //Size of the Button
        scale = new Vector2(250, 15);
        color = new Color(198, 33, 30);
    }

    public override void DrawText(SpriteBatch pSpriteBatch, SpriteFont pGameFont)
    {
        Vector2 textSize = pGameFont.MeasureString(AnswerText);
        Vector2 textLocation = position;
        pSpriteBatch.DrawString(pGameFont, AnswerText, textLocation - (textSize * 1f / 2), Color.White);
    }

    public override void DrawSprite(SpriteBatch pSpriteBatch)
    {
        origin = new Vector2(rectangle.Width / 2f, rectangle.Height / 2f);
        pSpriteBatch.Draw(pixel, position, rectangle, color, 0, origin, scale, SpriteEffects.None, 0.0f);
    }

    protected override void Normal()
    {
        color = new Color(71, 93, 225);
        base.Normal();
    }
    protected override void Hovering()
    {
        color = new Color(53, 70, 174);
        base.Hovering();
    }
    protected override void Pressed()
    {
        color = new Color(71, 93, 225);
        base.Pressed();
    }

    public override void ButtonBehaviour()
    {
        base.ButtonBehaviour();
        dialogueManager.ChangeDialogueData(Next);
        
    }

    public void SetTexture(Texture2D backgroundSprite)
    {
        pixel = backgroundSprite;
        texture2D = pixel;
    }

    public void SetDialogueManager(DialogueManager pDialogueManager)
    {
        dialogueManager = pDialogueManager;
    }
}
