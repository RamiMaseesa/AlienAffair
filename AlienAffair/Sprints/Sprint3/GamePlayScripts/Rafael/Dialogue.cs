using System;
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

    public Emotion currentEmotion { get; set; }
    public string[] text { get; set; }

    int _characterIndex = 0;
    int _stringIndex = 0;
    float _elapsedTime;
    bool _typingFinished = false;
    float charPrintDelay;
    SoundEffect soundEffect;

    public DialogueOption[] dialogueOptions { get; set; }

    //temporary
    KeyboardState kstate;

    public Dialogue()
    {
        position = new Vector2(100, 475);
        backgroundPosition = new Vector2(0, 450);
        backgroundSize = new Vector2(700, 100);
        backGroundOrigin = new Vector2(0, 0);
    }

    public override void Update(GameTime pGameTime)
    {
        //temporary
        kstate = Keyboard.GetState();
        TypeWriterEffect(pGameTime);
        FastForwardText();
        SkipDialogue();
        if (dialogueOptions != null)
        {
            for (int i = dialogueOptions.Length - 1; i >= 0; i--)
            {
                dialogueOptions[i].Update(pGameTime);
            }
        }

    }

    public override void Draw(SpriteBatch pSpriteBatch, SpriteFont pGameFont)
    {
        pSpriteBatch.Draw(pixel, new Vector2(backgroundPosition.X, backgroundPosition.Y - 4), null, Color.White, 0f, backGroundOrigin, new Vector2(backgroundSize.X, backgroundSize.Y + 4), SpriteEffects.None, 0f);
        pSpriteBatch.Draw(pixel, backgroundPosition, null, new Color(76, 90, 107), 0f, backGroundOrigin, backgroundSize, SpriteEffects.None, 0f);
        base.Draw(pSpriteBatch, pGameFont);
        DisplayOptions(pSpriteBatch);
    }

    /// <summary>
    /// typewriter effect so the dialogue prints per letter.
    ///     Uitleg:
    ///     Checks if the letters printed on screen is not less than the letters in the sentence in the array.
    ///         Checks if the 0.5 seconds have passed to add the next letter.
    ///             Character gets added to the string that gets printed on screen. <see cref="printedText"/>
    ///             CharacterIndex gets increased (next character in the string).
    ///             time gets reset.
    ///     Else, the Dialogue goes to the next sentence.
    ///         Checks if the stringIndex isn't out of bounds (Trying to write a dialogue that doesn't exist). <see cref="stringIndex"/>
    ///             Goes to the next Sentence.
    ///             Starts at the first character for that sentence.
    ///         Else, Stopts printing dialogue (Dialogue is over!)
    ///         
    /// :D
    /// </summary>
    /// <param name="pGameTime"></param>
    public void TypeWriterEffect(GameTime pGameTime)
    {
        _elapsedTime += (float)pGameTime.ElapsedGameTime.TotalSeconds;
        if (!_typingFinished)
        {
            if (_characterIndex < text[_stringIndex].Length)
            {
                if (_elapsedTime >= charPrintDelay)
                {
                    printedText += text[_stringIndex][_characterIndex];
                    _characterIndex++;
                    _elapsedTime = 0;
                    
                    //put your logic per letter here
                    PerLetterLogic();
                }
            }
            else
            {
                if (_stringIndex + 1 < text.Length)
                {
                    _stringIndex++;
                    _characterIndex = 0;
                }
                else
                {
                    EndOfTextLogic();
                    _typingFinished = true;
                }
            }
        }
    }

    /// <summary>
    /// Speeds up the pace at how quick the letters appear
    /// </summary>
    public void FastForwardText()
    {
        if (kstate.IsKeyDown(Keys.Right))
            charPrintDelay = 0.02f;
        else
            charPrintDelay = 0.08f;
    }

    /// <summary>
    /// Prints allt eh dialogue at once
    /// </summary>
    public void SkipDialogue()
    {
        if (kstate.IsKeyDown(Keys.Enter) && !_typingFinished)
        {
            printedText = string.Join("", text);
            _stringIndex = text.Length - 1;
            _characterIndex = text[_stringIndex].Length;
            _typingFinished = true;
            Console.WriteLine("Dialogue has been skipped");
            EndOfTextLogic();
        }
    }

    /// <summary>
    /// Makes the dialogue reset all the way
    /// </summary>
    public void ResetDialogue()
    {
        printedText = "";
        _characterIndex = 0;
        _stringIndex = 0;
        _typingFinished = false;
        System.Console.WriteLine($"Dialogue {this} has been reset");
        if (dialogueOptions != null)
        {
            for (int i = 0; i < dialogueOptions.Length; i++)
            {
                dialogueOptions[i].objectActive = false;
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
        if (dialogueOptions != null)
        {
            for (int i = 0; i < dialogueOptions.Length; i++)
            {
                dialogueOptions[i].objectActive = true;
            }
        }
    }

    public void DisplayOptions(SpriteBatch pSpriteBatch)
    {
        if (dialogueOptions != null)
        {
            for (int i = 0; i < dialogueOptions.Length; i++)
            {
                dialogueOptions[i].position.Y = 200 + (100 * i);
                dialogueOptions[i].SetTexture(pixel);
                dialogueOptions[i].Draw(pSpriteBatch, gameFont);
            }
        }
    }

    public void SetSoundEffect(SoundEffect pSoundEffect)
    {
        soundEffect = pSoundEffect;
    }
}
