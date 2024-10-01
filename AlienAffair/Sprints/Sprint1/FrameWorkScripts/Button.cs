using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace AlienAffair.Sprints.Sprint1.FrameWorkScripts
{

    public class Button : GameObject
    {
        public enum ButtonStatus
        {
            hovered,
            pressed,
            normal,
        }

        ButtonStatus _buttonState;

        //mousebehaviour
        Point _mousePoint;
        MouseState _mouseState;

        string _buttonText;
        Vector2 _textPosition;

        public Button(Vector2 pPosition, Rectangle pRectangle, string pButtonText) : base(pPosition, pRectangle)
        {
            _buttonText = pButtonText;
        }

        public override void Update(GameTime gameTime)
        {
            _mouseState = Mouse.GetState();
            _mousePoint = new Point(_mouseState.X, _mouseState.Y);
            //Hovering(mousePoint, mouseState);

            switch (_buttonState)
            {
                case ButtonStatus.hovered:
                    Hovering();
                    break;
                case ButtonStatus.pressed:
                    Pressed();
                    break;
                case ButtonStatus.normal:
                    Normal();
                    break;
            }
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
            //pSpriteBatch.DrawString(gameFont, _buttonText , position ,Color.Black, 0f, new Vector2(0f, 0f), 1f, SpriteEffects.None, 0.0f);
        }

        public virtual void Normal()
        {
            color = Color.White;
            rectangle = new Rectangle(0, 0, 64, 32);
            _textPosition = position;
            if (hitbox.Contains(_mousePoint))
            {
                _buttonState = ButtonStatus.hovered;
            }
        }

        public virtual void Hovering()
        {
            color = Color.LightGray;
            if (!hitbox.Contains(_mousePoint))
            {
                _buttonState = ButtonStatus.normal;
            }
            else if (_mouseState.LeftButton == ButtonState.Pressed)
            {
                _buttonState = ButtonStatus.pressed;
            }
        }

        public virtual void Pressed()
        {
            rectangle = new Rectangle(64, 0, 64, 32);
            if (_mouseState.LeftButton == ButtonState.Released)
            {
                if (hitbox.Contains(_mousePoint))
                {

                    ButtonBehaviour();
                    _buttonState = ButtonStatus.normal;
                }
                if (!hitbox.Contains(_mousePoint))
                {
                    _buttonState = ButtonStatus.normal;
                }
            }
        }

        public virtual void ButtonBehaviour()
        {
            Console.WriteLine("Button behaviour");
        }
    }
}
