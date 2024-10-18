using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework;
using System;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Elliot.Wanted
{
    public class ObjectWanted : GameObject
    {
        Vector2 direction;
        float speed;

        public ObjectWanted(Vector2 pPosition, string pPath, Color pColor, Rectangle pRectangle) : base(pPosition, pRectangle)
        {
            position = pPosition;
            path = pPath;
            color = pColor;
            scale = 1;
            Initialize();
        }

        private void Initialize()
        {
            Random rnd = new Random();
            direction = new Vector2(rnd.Next(-1, 2) + (float)rnd.Next(0, 100) / 100, rnd.Next(-1, 2) + (float)rnd.Next(0, 100) / 100);
            direction.Normalize();
            speed = rnd.Next(50, 100);
            Console.WriteLine(direction);
        }

        public override void Update(GameTime pGameTime)
        {
            MoveSprite(pGameTime);
        }

        private void MoveSprite(GameTime pGameTime)
        {
            position += direction * (speed * (float)pGameTime.ElapsedGameTime.TotalSeconds);
        }

        public void FlipDirectionX()
        {
            direction = new Vector2(direction.X * -1, direction.Y);
        }

        public void FlipDirectionY()
        {
            direction = new Vector2(direction.X, direction.Y * -1);
        }
    }
}
