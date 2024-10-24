using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.Dodge
{
    public class Obstacle : GameObject
    {
        private float speed = 50;

        public Obstacle(Vector2 pPosition, string pPath, Color pColor, float pSpeed) : base(pPosition, pPath)
        {
            color = pColor;
            scale = 0.75f;
            speed = pSpeed;
            rotation = MathHelper.ToRadians(90f);

            rectangle = SpritePicker(); 
        }

        public override void Update(GameTime pGameTime)
        {
            position.X -= (float)pGameTime.ElapsedGameTime.TotalSeconds * speed;
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);

            //DrawHitbox(pSpriteBatch);

            origin = new Vector2(rectangle.Width / 2f, rectangle.Height / 2f);
           // pSpriteBatch.Draw(texture2D, position, rectangle, color, 0, origin, scale, SpriteEffects.None, 0.0f);
            //Console.WriteLine(hitBox.X + "    " + hitBox.Y);

        }

        private Rectangle SpritePicker()
        {
            int[] sprites = { 0, 128, 256 };

            Random rnd = new Random();
            int drawPos = rnd.Next(sprites.Length);

            return new Rectangle(0, sprites[drawPos], 256, 128);
        }

        public void UpdateObjectSpeed(float pAddSpeed)
        {
            speed = pAddSpeed;
        }

        public void ChangeSpeed(float pNewSpeed)
        {
            speed = pNewSpeed;
        }
    }
}
