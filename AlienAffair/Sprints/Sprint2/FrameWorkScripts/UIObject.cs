using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint2.FrameWorkScripts;

public class UiObject
{
    public SpriteFont gameFont;
    public Texture2D pixel;


    public string printedText;
    public Vector2 backgroundPosition;
    public Vector2 backgroundSize;
    public Vector2 backGroundOrigin;

    /// <summary>The Position of the gameObject</summary>
    public Vector2 position;

    /// <summary>The x and y and the width and height for the sprite on the spriteSheet</summary>
    public Rectangle rectangle;

    /// <summary>SpriteSheet or Sprite that the GameObject uses</summary>
    public Texture2D texture2D;

    /// <summary>Scale of the GameObject</summary>
    public Vector2 scale = new Vector2(1, 1);

    /// <summary>Path to the Sprite or Spritesheet the GameObject uses</summary>
    public string path;

    /// <summary>Color of the GameObject</summary>
    public Color color = Color.White;

    /// <summary>Origin of the GameObject</summary>
    public Vector2 origin;

    /// <summary>The Collider/hitBox of the GameObject</summary>
    public Rectangle hitBox;

    /// <summary>Variable that decides if the object is drawn on screen and has a hitbox or not</summary>
    public bool objectActive = true;

    /// <summary>
    /// Constructor for a GameObject with a SpriteSheet 
    /// </summary>
    /// <param name="pPosition"></param>
    /// <param name="pRectangle"></param>
    public UiObject(Vector2 pPosition, Rectangle pRectangle)
    {
        position = pPosition;
        rectangle = pRectangle;
    }

    public UiObject()
    {

    }

    /// <summary>
    /// Constructor for a Sprite with single sprite file
    /// </summary>
    /// <param name="pPosition"></param>
    /// <param name="pPathToImage"></param>
    public UiObject(Vector2 pPosition, Texture2D pSprite, string pButtonText)
    {
        position = pPosition;
        texture2D = pSprite;
    }

    public virtual void Update(GameTime pGameTime)
    {
        //Empty
    }

    /// <summary>
    /// Draws the object with text
    /// </summary>
    /// <param name="pSpriteBatch"></param>
    public virtual void Draw(SpriteBatch pSpriteBatch, SpriteFont pGameFont)
    {
        if (objectActive)
        {
            DrawHitbox(pSpriteBatch);
            DrawSprite(pSpriteBatch);
            DrawText(pSpriteBatch, pGameFont);
        }
    }

    /// <summary>
    /// Draws the object without text
    /// </summary>
    /// <param name="pSpriteBatch"></param>
    public virtual void Draw(SpriteBatch pSpriteBatch)
    {
        if (objectActive)
        {
            DrawHitbox(pSpriteBatch);
            DrawSprite(pSpriteBatch);
        }
    }

    /// <summary>
    /// assigns the <see cref="origin"/> of the GameObject.
    /// draws the GameObject in the scene.
    /// </summary>
    /// <param name="pSpriteBatch"></param>
    public virtual void DrawSprite(SpriteBatch pSpriteBatch)
    {
        origin = new Vector2(rectangle.Width / 2f, rectangle.Height / 2f);
        //Program doesn't work without this if statemenet figure out later
        if (texture2D != null)
            pSpriteBatch.Draw(texture2D, position, rectangle, color, 0, origin, scale, SpriteEffects.None, 0.0f);
    }

    public virtual void DrawText(SpriteBatch pSpriteBatch, SpriteFont pGameFont)
    {
        pSpriteBatch.DrawString(pGameFont, printedText, position, Color.White);
    }

    public virtual void DrawHitbox(SpriteBatch pSpriteBatch)
    {
        int scaledRectangleWidth = rectangle.Width * (int)scale.X;
        int scaledRectangleHeight = rectangle.Height * (int)scale.Y;
        hitBox = new Rectangle((int)position.X - (scaledRectangleWidth / 2), (int)position.Y - (scaledRectangleHeight / 2), scaledRectangleWidth, scaledRectangleHeight);
    }

    public void SetSpriteFont(SpriteFont pGameFont)
    {
        gameFont = pGameFont;
    }

    public void SetPixel(Texture2D pPixel)
    {
        pixel = pPixel;
    }
}
