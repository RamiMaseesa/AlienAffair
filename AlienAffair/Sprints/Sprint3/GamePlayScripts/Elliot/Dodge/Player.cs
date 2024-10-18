using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Elliot.Dodge
{
    public class Player : GameObject
    {
        Animate manAnimation;
        float[] lanePos = new float[3];
        float destinationPos;
        float clickCoolDown = 1f;
        bool canClick = true;

        enum lanes
        {
            Top,
            Middle,
            Bottom,
        }

        lanes currentLane = lanes.Middle;

        public Player(Vector2 pPosition, string pPath, Color pColor, float[] pLanePos) : base(pPosition, pPath)
        {
            color = pColor;
            lanePos = pLanePos;
            scale = 1;
        }

        public void Initialize()
        {
            manAnimation = new Animate(0.2f, 2, 3, texture2D);
        }

        public override void Update(GameTime pGameTime)
        {
            rectangle = manAnimation.PlayAnimation(pGameTime);
            PickDestination(pGameTime);
            MovePlayer(pGameTime);
            base.Update(pGameTime);
        }

        private void PickDestination(GameTime pGameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) && canClick == true)
            {
                if (currentLane == lanes.Middle)
                {
                    currentLane = lanes.Top;
                }
                else if (currentLane == lanes.Bottom)
                {
                    currentLane = lanes.Middle;
                }
                canClick = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) && canClick == true)
            {
                if (currentLane == lanes.Middle)
                {
                    currentLane = lanes.Bottom;
                }
                else if (currentLane == lanes.Top)
                {
                    currentLane = lanes.Middle;
                }
                canClick = false;
            }

            if (canClick == false)
            {
                clickCoolDown -= (float)pGameTime.ElapsedGameTime.TotalSeconds;
                if(clickCoolDown < 0)
                {
                    canClick = true;
                    clickCoolDown = 1f;
                }
            }

        }

        private void MovePlayer(GameTime pGameTime)
        {
            switch (currentLane)
            {
                case lanes.Top:
                    float differenceTop = lanePos[0] - position.Y;

                    position.Y += differenceTop * (2 * (float)pGameTime.ElapsedGameTime.TotalSeconds);

                    break;
                case lanes.Middle:
                    float differenceMid = lanePos[1] - position.Y;

                    position.Y += differenceMid * (2 * (float)pGameTime.ElapsedGameTime.TotalSeconds);
                    break;
                case lanes.Bottom:

                    float differenceBot = lanePos[2] - position.Y;

                    position.Y += differenceBot * (2 * (float)pGameTime.ElapsedGameTime.TotalSeconds);
                    break;
            }
        }
    }
}
