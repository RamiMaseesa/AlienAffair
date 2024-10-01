using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace AlienAffair.Sprints.Sprint1.FrameWorkScripts
{
    public class GameObject
    {
        protected string path;
        protected float depth;
        protected float rotation;
        protected float deltaTime;
        protected Vector2 scale;
        protected Vector2 position;
        protected Rectangle collider;
        protected Color color;
        protected KeyboardState kState;
        protected Texture2D sprite;


        public GameObject(Vector2 position, string path)
        {
            this.position = position;
            this.path = path;
        }

        public GameObject(Vector2 position, string path, float depth, Color color)
        {
            this.position = position;
            this.path = path;
            this.depth = depth;
            this.color = color;
        }

        protected internal virtual void Initialize(GraphicsDeviceManager graphics)
        {
            depth = 0.0f;
            rotation = 0.0f;
            color = Color.White;
            scale = new Vector2(1, 1);
        }
        protected internal virtual void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            sprite = content.Load<Texture2D>(path);
        }
        protected internal virtual void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            kState = Keyboard.GetState();
            collider = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        protected internal virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, color, rotation,
            new Vector2(sprite.Width / 2, sprite.Height / 2), scale, SpriteEffects.None, depth);
        }
    }
}
