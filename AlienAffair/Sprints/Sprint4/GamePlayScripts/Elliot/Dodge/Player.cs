using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.Dodge
{
    public class Player : GameObject
    {
        Texture2D runningSpriteSheet;

        Animation manAnimation;
        float[] lanePos = new float[3];
        float destinationPos;
        float clickCoolDown = 1f;
        bool canClick = true;

        bool updateAnimation = true;
        bool isPlayingFallAnimation = false;

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
            runningSpriteSheet = texture2D;
            manAnimation = new Animation(0.2f, 2, 3, texture2D);
        }

        public override void Update(GameTime pGameTime)
        {
            PickDestination(pGameTime);
            MovePlayer(pGameTime);
            base.Update(pGameTime);

            if (manAnimation.CheckForEnd() == true && isPlayingFallAnimation == true)
            {
                rectangle = manAnimation.ReachedEnd();
                updateAnimation = false;
                isPlayingFallAnimation = false;
            }
            if (updateAnimation == true)
            {
                rectangle = manAnimation.PlayAnimation(pGameTime);
            }
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
                if (clickCoolDown < 0)
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

        public void PlayFallAnimation(Texture2D pFallSpriteSheet)
        {
            if (isPlayingFallAnimation == false)
            {
                manAnimation = new Animation(0.15f, 2, 2, pFallSpriteSheet);
                texture2D = pFallSpriteSheet;
            }

            isPlayingFallAnimation = true;
        }

        public void ChangeSpeed(float pAnimationSpeed)
        {
            manAnimation = new Animation(pAnimationSpeed, 2, 3, texture2D);
        }
    }
}
