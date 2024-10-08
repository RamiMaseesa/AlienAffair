using AlienAffair.Sprints.Sprint1.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace AlienAffair.Sprints.Sprint2.GamePlayScripts.Elliot
{
    public class PlayerCircle : GameObject
    {
        float speed = 50f;
        bool buttonIsDown = false;
        float radius = 64;
        float timeInCircle = 0;

        enum speedValues
        {
            Snail,
            Slow,
            Medium,
            Fast,
            Turbo
        }
        speedValues currentSpeed = speedValues.Snail;


        public PlayerCircle(Vector2 pPosition, string pPath, Color pColor, Rectangle pRectangle) : base(pPosition, pRectangle)
        {
            position = pPosition;
            path = pPath;
            color = pColor;
            scale = 1.75f;
        }

        public void MoveCircle(GameTime pGameTime, Rectangle pGameScreen)
        {
            ChangeSpeed();

            Vector2 direction = Vector2.Zero;
            if (Keyboard.GetState().IsKeyDown(Keys.W) && position.Y - 64 > pGameScreen.Y)
            {
                direction.Y--;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && position.Y + 64 < pGameScreen.Height)
            {
                direction.Y++;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && position.X - 64 > pGameScreen.X)
            {
                direction.X--;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D) && position.X + 64 < pGameScreen.Width)
            {
                direction.X++;
            }
            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }
            Vector2 translation = direction * speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;
            position += translation;
        }

        public void DetectWanted(AlienObjectWanted pWantedAlien, GameTime pGameTime)
        {
            radius = texture2D.Width + Math.Abs(texture2D.Width * (2 - scale));

            if ((pWantedAlien.position - position).Length() <= radius)
            {
                Console.WriteLine("nu heb ik je");
                timeInCircle += (float)pGameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                timeInCircle = 0;
            }

            if (timeInCircle > 3f)
            {
                pWantedAlien.color = Color.Red;
            }
            Console.WriteLine(timeInCircle);
        }

        public void ChangeSpeed()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && buttonIsDown == false)
            {
                buttonIsDown = true;
                switch (currentSpeed)
                {
                    case speedValues.Snail:
                        currentSpeed = speedValues.Slow;
                        speed = 50;
                        break;
                    case speedValues.Slow:
                        speed = 75;
                        currentSpeed = speedValues.Medium;
                        break;
                    case speedValues.Medium:
                        speed = 100;
                        currentSpeed = speedValues.Fast;
                        break;
                    case speedValues.Fast:
                        speed = 200;
                        currentSpeed = speedValues.Turbo;
                        break;
                    case speedValues.Turbo:
                        speed = 325;
                        currentSpeed = speedValues.Snail;
                        break;
                }
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                buttonIsDown = false;
            }
        }
    }
}
