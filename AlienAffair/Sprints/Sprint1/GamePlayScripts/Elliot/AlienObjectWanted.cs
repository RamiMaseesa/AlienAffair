using AlienAffair.Sprints.Sprint1.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace AlienAffair.Sprints.Sprint1.GamePlayScripts.Elliot
{
    public class AlienObjectWanted : GameObject
    {
        Vector2 alienPosition;
        Vector2 direction;
        float speed;

        public AlienObjectWanted(Vector2 pPosition, string pPathToImage) : base(pPosition, pPathToImage)
        {
            path = pPathToImage;
            position = pPosition;
            Initialize();
        }

        private void Initialize()
        {
            Random rnd = new Random();
            direction = new Vector2(rnd.Next(-1, 2), rnd.Next(-1, 2));
            speed = rnd.Next(25, 100);
        }

        public override void Update(GameTime pGameTime)
        {
            MoveSprite(pGameTime);
        }

        private void MoveSprite(GameTime pGameTime)
        {
            position = direction * (speed * (float)pGameTime.ElapsedGameTime.TotalSeconds);
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
