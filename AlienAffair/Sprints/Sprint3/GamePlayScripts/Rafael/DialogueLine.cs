using System;
using AlienAffair.Sprints.Sprint2.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Rafael;

public class DialogueLine
{
    public string Line { get; set; }
    public float TextSize { get; set; } = 1f;
    public int[] RgbValues { get; set; }
    public Color textColor;
    public float Linespacing { get; set; } = 0f;

    public string printedText = "";


    public bool _typingLineFinished = false;
    public bool _isvisible = false;
    public float charPrintDelay;
    int _characterIndex;
    float _elapsedTime;
    //int _dialogueIndex;

    public float DelaySpeed { get; set; } = 0.1f;

    public DialogueLine()
    {

    }

    public void AssignColor()
    {
        if (RgbValues != null)
            textColor = new Color(RgbValues[0], RgbValues[1], RgbValues[2], RgbValues[3]);
        else
            textColor = Color.White;
    }

    public void PrintLine(SpriteBatch pSpriteBatch, SpriteFont pGameFont, Vector2 pPosition)
    {
        AssignColor();
        pSpriteBatch.DrawString(pGameFont, printedText, pPosition, textColor, 0f, new Vector2(0, 0), TextSize, SpriteEffects.None, 0f);
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
        if (!_typingLineFinished)
        {
            _isvisible = true;
            if (_characterIndex < Line.Length)
            {
                if (_elapsedTime >= charPrintDelay)
                {
                    printedText += Line[_characterIndex];
                    _characterIndex++;
                    _elapsedTime = 0;
                    
                    //put your logic per letter here
                    PerLetterLogic();
                }
            }
            else
            {
                EndOfTextLogic();
                _typingLineFinished = true;
                //_isvisible = false;

            }
        }
    }

    public Vector2 GetPrintedTextSize(SpriteFont pGameFont)
    {
        Vector2 stringSize = pGameFont.MeasureString(printedText);
        return stringSize;
    }

    public void SkipDialogue()
    {
         _typingLineFinished = true;
         _isvisible = true;
         printedText = Line;
    }

    private void EndOfTextLogic()
    {

    }

    private void PerLetterLogic()
    {
        Console.WriteLine(printedText);
    }

    public void ResetDialogue()
    {
        printedText = "";
        _characterIndex = 0;
        _typingLineFinished = false;
        _isvisible = false;
    }
}
