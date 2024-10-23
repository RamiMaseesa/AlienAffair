using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using AlienAffair.Sprints.Sprint4.GamePlayScripts;

namespace AlienAffair.Sprints.Sprint4.FrameWorkScripts
{
    public class GameObject
    {
        /// <summary>The Position of the gameObject</summary>
            public Vector2 position;

        /// <summary>The x and y and the width and height for the sprite on the spriteSheet</summary>
            public Rectangle rectangle;

        /// <summary>SpriteSheet or Sprite that the GameObject uses</summary>
            public Texture2D texture2D;

        /// <summary>Scale of the GameObject</summary>
            public float scale = 3;

        /// <summary>Path to the Sprite or Spritesheet the GameObject uses</summary>
            public string path;

        /// <summary>The Color of the Hitbox for debugging</summary>
            public Color hitBoxColor;

        /// <summary>Color of the GameObject</summary>
            public Color color = Color.White;

        ///<summary>Rotation of the GameObject</summary>
            public float rotation = 0;

        /// <summary>Origin of the GameObject</summary>
            public Vector2 origin;

        /// <summary>The Collider/hitBox of the GameObject</summary>
            public Rectangle hitBox;

        /// <summary>Variable that decides if the object is drawn on screen and has a hitbox or not</summary>
            public bool objectActive = true;
            
            
            public Game1 game;

        #region Constructors
        /// <summary>
        /// Constructor for a GameObject with a SpriteSheet 
        /// </summary>
        /// <param name="pPosition"></param>
        /// <param name="pRectangle"></param>
        public GameObject(Vector2 pPosition, Rectangle pRectangle)
                {
                    position = pPosition;
                    rectangle = pRectangle;
                }

            /// <summary>
            /// Constructor for a Sprite with single sprite file
            /// </summary>
            /// <param name="pPosition"></param>
            /// <param name="pPathToImage"></param>
                public GameObject(Vector2 pPosition, string pPathToImage)
                {
                    position = pPosition;
                    path = pPathToImage;
                }
        #endregion
        
        public virtual void Update(GameTime pGameTime)
        {
            //Nothing
        }

        /// <summary>
        /// Checks if the object is active.
        ///     plays the <see cref="DrawHitbox"/> method.
        ///     plays the <see cref="DrawSprite"/> method.
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
            pSpriteBatch.Draw(texture2D, position, rectangle, color, rotation, origin, scale, SpriteEffects.None, 0.0f);
        }

        /// <summary>
        /// Loads the sprite info into <see cref="texture2D"/>.
        /// </summary>
        /// <param name="pContent"></param>
        public virtual void LoadSprite(ContentManager pContent)
        {
            texture2D = pContent.Load<Texture2D>(path);
        }

        /// <summary>
        /// rectangle Width gets scaled with the GameObjects scale.
        /// rectangle Height gets scaled with the GameObjects scale.
        /// <see cref="hitBox"/> gets made with the scaled rectangle info and put in the correct position.
        /// </summary>
        /// <param name="pSpriteBatch"></param>
        public virtual void DrawHitbox(SpriteBatch pSpriteBatch)
        {
            //Commented bit is Debugging only
            //pSpriteBatch.Draw(pPixel, position, null, hitBoxColor, 0, new Vector2(1f, 1f), new Vector2(rectangle.Width * (scale / 2), rectangle.Height * (scale / 2)), SpriteEffects.None, 0.0f);
            int scaledRectangleWidth = rectangle.Width * (int)scale;
            int scaledRectangleHeight = rectangle.Height * (int)scale;
            hitBox = new Rectangle((int)position.X - (scaledRectangleWidth / 2), (int)position.Y - (scaledRectangleHeight / 2), scaledRectangleWidth, scaledRectangleHeight);
        }

        public void Initialize(Game1 game1refference) 
        {
            game = game1refference;
        }
    }
}
