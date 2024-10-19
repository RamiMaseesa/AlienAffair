using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Rafael;

public class Dialogue : UiObject
{
    public enum Emotion
    {
        neutral,
        happy,
        sad,
        angry,
        confused,
        Annoyed
    }

    public Emotion CurrentEmotion { get; set; }
    public DialogueLine[] Text { get; set; }
    bool _typingFinished = false;
    SoundEffect soundEffect;

    //public List<DialogueOption> dialogueOptions { get; set; }
    public DialogueOption[] DialogueOptions { get; set; }

    public DialogueManager dialogueManager;

    //temporary
    KeyboardState kstate;
    float _yOffset = 0f;

    public Dialogue()
    {
        position = new Vector2(100, 460);
        backgroundPosition = new Vector2(0, 450);
        backgroundSize = new Vector2(700, 110);
        backGroundOrigin = new Vector2(0, 0);
    }

    public override void Update(GameTime pGameTime)
    {
        //temporary
        kstate = Keyboard.GetState();
        Text[0]._isvisible = true;
        if (!_typingFinished)
        {
            for (int i = Text.Length - 1; i >= 0; i--)
            {
                if (Text[i]._isvisible)
                {
                    Text[i].TypeWriterEffect(pGameTime);
                    if (Text[i]._typingLineFinished)
                    {
                        if (i + 1 < Text.Length)
                            Text[i + 1]._isvisible = true;
                    }
                }
                FastForwardText(i);
                SkipDialogue();
            }

            if (Text[Text.Length - 1]._typingLineFinished)
            {
                _typingFinished = true;
                EndOfTextLogic();
            }
        }
        if (DialogueOptions != null)
        {
            for (int i = DialogueOptions.Length - 1; i >= 0; i--)
            {
                DialogueOptions[i].Update(pGameTime);
            }
        }
    }

    public override void Draw(SpriteBatch pSpriteBatch, SpriteFont pGameFont)
    {
        //pSpriteBatch.Draw(pixel, new Vector2(backgroundPosition.X, backgroundPosition.Y - 4), null, Color.White, 0f, backGroundOrigin, new Vector2(backgroundSize.X, backgroundSize.Y + 4), SpriteEffects.None, 0f);
        pSpriteBatch.Draw(pixel, backgroundPosition, null, new Color(0, 0, 0, 198), 0f, backGroundOrigin, backgroundSize, SpriteEffects.None, 0f);
        _yOffset = 0;
        for (int i = 0; i < Text.Length; i++)
        {
            if (Text[i]._isvisible)
            {
                Text[i].PrintLine(pSpriteBatch, pGameFont, new Vector2(position.X, position.Y + _yOffset));
                _yOffset += Text[i].GetPrintedTextSize(pGameFont).Y * Text[i].TextSize;
            }
        }
        DisplayOptions(pSpriteBatch);
    }

    /// <summary>
    /// Speeds up the pace at how quick the letters appear
    /// </summary>
    public void FastForwardText(int indexer)
    {
        if (kstate.IsKeyDown(Keys.Right))
            Text[indexer].charPrintDelay = 0.02f;
        else
            Text[indexer].charPrintDelay = Text[indexer].DelaySpeed;
    }
    /// <summary>
    /// Prints all th dialogue at once
    /// </summary>
    public void SkipDialogue()
    {

        if (kstate.IsKeyDown(Keys.Enter) && !_typingFinished)
        {
            for (int i = 0; i < Text.Length; i++)
            {
                Text[i].SkipDialogue();
                Console.WriteLine(i);
            }
            _typingFinished = true;
        }



    }

    /// <summary>
    /// Makes the dialogue reset all the way
    /// </summary>
    public void ResetDialogue()
    {
        printedText = "";
        //_characterIndex = 0;
        //_dialogueIndex = 0;
        _typingFinished = false;
        System.Console.WriteLine($"Dialogue {this} has been reset");
        if (DialogueOptions != null)
        {
            for (int i = 0; i < DialogueOptions.Length; i++)
            {
                DialogueOptions[i].objectActive = false;
            }
        }

    }

    /// <summary>
    /// This method plays per letter displayed on screen
    /// </summary>
    public void PerLetterLogic()
    {
        System.Console.WriteLine("Per letter Logic");
    }

    public void EndOfTextLogic()
    {
        Console.WriteLine("All text has been typed");
        if (DialogueOptions != null)
        {
            for (int i = 0; i < DialogueOptions.Length; i++)
            {
                DialogueOptions[i].objectActive = true;
            }
        }
    }

    public void DisplayOptions(SpriteBatch pSpriteBatch)
    {
        if (DialogueOptions != null)
        {
            for (int i = 0; i < DialogueOptions.Length; i++)
            {
                DialogueOptions[i].position.Y = 200 + (100 * i);
                DialogueOptions[i].SetTexture(pixel);
                DialogueOptions[i].SetDialogueManager(dialogueManager);
                DialogueOptions[i].Draw(pSpriteBatch, gameFont);
            }
        }
    }

    public void SetSoundEffect(SoundEffect pSoundEffect)
    {
        soundEffect = pSoundEffect;
    }

    public void GetDialogueManager(DialogueManager pdialoguemanager)
    {
        dialogueManager = pdialoguemanager;
    }
}
