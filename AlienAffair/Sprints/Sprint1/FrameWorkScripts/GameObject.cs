using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace AlienAffair.Sprints.Sprint1.FrameWorkScripts
{
    public class GameObject
    {
        public Vector2 position;
        public Rectangle rectangle;
        public Texture2D texture2D;
        public float scale = 3;
        public Color hitBoxColor;
        public Color color = Color.White;
        public Vector2 origin;
        public Rectangle hitbox;
        public bool objectActive = true;

        public GameObject(Vector2 pPosition, Rectangle pRectangle)
        {
            position = pPosition;
            rectangle = pRectangle;
        }

        //public void Initialize(Game1 pGame)
        //{
        //    _game1 = pGame;
        //}

        public virtual void Update(GameTime pGameTime)
        {
            //Nothing
        }

        public virtual void Draw(SpriteBatch pSpriteBatch)
        {
            DrawHitbox(pSpriteBatch);
            DrawSprite(pSpriteBatch);
        }

        public virtual void DrawSprite(SpriteBatch pSpriteBatch)
        {
            origin = new Vector2(rectangle.Width / 2f, rectangle.Height / 2f);
            pSpriteBatch.Draw(texture2D, position, rectangle, color, 0, origin, scale, SpriteEffects.None, 0.0f);
        }

        public virtual void LoadSprite(ContentManager pContent)
        {
            texture2D = pContent.Load<Texture2D>("Button");
        }

        public virtual void DrawHitbox(SpriteBatch pSpriteBatch)
        {
            //pSpriteBatch.Draw(pPixel, position, null, hitBoxColor, 0, new Vector2(1f, 1f), new Vector2(rectangle.Width * (scale / 2), rectangle.Height * (scale / 2)), SpriteEffects.None, 0.0f);
            int scaledRectangleWidth = rectangle.Width * (int)scale;
            int scaledRectangleHeight = rectangle.Height * (int)scale;
            hitbox = new Rectangle((int)position.X - (scaledRectangleWidth / 2), (int)position.Y - (scaledRectangleHeight / 2), scaledRectangleWidth, scaledRectangleHeight);
        }

        public virtual void Collision()
        {
            System.Console.WriteLine("empty");
        }
    }
}
