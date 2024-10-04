using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
    public Emotion _currentEmotion {get; set;}
    public string[] _text {get; set;}

    public Dialogue()
    {

    }

    public void DrawText(SpriteBatch pSpriteBatch, SpriteFont pGameFont)
    {
        pSpriteBatch.DrawString(pGameFont, _text[0] + ", " + _text[1], new Vector2(10, 250), Color.White);
    }
}
