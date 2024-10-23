using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.Dodge
{
    public class Jaguar : GameObject
    {
        Animation jaguarAnimation;
        Rectangle jaguarRec;

        Player playerReference;

        public Jaguar(Vector2 pPosition, string pPath, Color pColor, Player pPlayer) : base(pPosition, pPath)
        {
            color = pColor;
            playerReference = pPlayer;
            scale = 1;
        }

        public void Initialize()
        {
            jaguarAnimation = new Animation(0.2f, 1, 3, texture2D);
        }

        public override void Update(GameTime pGameTime)
        {
            rectangle = jaguarAnimation.PlayAnimation(pGameTime);
            position.Y = playerReference.position.Y;

            base.Update(pGameTime);
        }

        public void GameOver(GameTime pGameTime)
        {
            float difference = playerReference.position.X - position.X;

            position.X += difference * (2 * (float)pGameTime.ElapsedGameTime.TotalSeconds);
        }

        public void ChangeSpeed(float pAnimationSpeed)
        {
            jaguarAnimation = new Animation(pAnimationSpeed, 1, 3, texture2D);
        }
    }
}
