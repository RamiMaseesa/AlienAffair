using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AlienAffair.Sprints.Sprint1.GamePlayScripts.Rafael;

public class Dialogue
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
    //public string[] text { get; set; }
    public string[] text { get; set; }

    string _printedText = "";
    int _characterIndex = 0;
    int _stringIndex = 0;
    float _elapsedTime;
    bool _typingFinished = false;
    float charPrintDelay;

    //temporary
    KeyboardState kstate;

    public Dialogue()
    {

    }

    public void Update(GameTime pGameTime)
    {
        //temporary
        kstate = Keyboard.GetState();
        TypeWriterEffect(pGameTime);
        FastForwardText();
        SkipDialogue();
    }

    public void DrawText(SpriteBatch pSpriteBatch, SpriteFont pGameFont)
    {
        pSpriteBatch.DrawString(pGameFont, _printedText, new Vector2(10, 250), Color.White);
    }


    /// <summary>
    /// typewriter effect so the dialogue prints per letter.
    ///     Uitleg:
    ///     Checks if the letters printed on screen is not less than the letters in the sentence in the array.
    ///         Checks if the 0.5 seconds have passed to add the next letter.
    ///             Character gets added to the string that gets printed on screen. <see cref="_printedText"/>
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
                    _printedText += text[_stringIndex][_characterIndex];
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
                    Console.WriteLine("All text has been typed");
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
            _printedText = string.Join("", text);
            _stringIndex = text.Length - 1;
            _characterIndex = text[_stringIndex].Length;
            _typingFinished = true;
            Console.WriteLine("Dialogue has been skipped");
        }
    }

    /// <summary>
    /// Makes the dialogue reset all the way
    /// </summary>
    public void ResetDialogue()
    {
        _printedText = "";
        _characterIndex = 0;
        _stringIndex = 0;
        _typingFinished = false;
        System.Console.WriteLine($"Dialogue {this} has been reset");
    }

    /// <summary>
    /// This method plays per letter displayed on screen
    /// </summary>
    public void PerLetterLogic()
    {
        System.Console.WriteLine("Per letter Logic");
    }
}
