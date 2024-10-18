using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Elliot.Dodge
{
    public class Jaguar : GameObject
    {
        Animate jaguarAnimation;
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
            jaguarAnimation = new Animate(0.2f, 1, 3, texture2D);
        }

        public override void Update(GameTime pGameTime)
        {
            rectangle = jaguarAnimation.PlayAnimation(pGameTime);
            position.Y = playerReference.position.Y;

            base.Update(pGameTime);
        }
    }
}
