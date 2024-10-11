using System;
using AlienAffair.Sprints.Sprint2.GamePlayScripts.Rafael;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AlienAffair.Sprints.Sprint2.FrameWorkScripts
{
    public class ButtonBase : UiObject
    {
        //Enum for every state a button can find itself in, if you want to have extra states add them here!
        public enum ButtonStatus
        {
            hovered,
            pressed,
            normal,
        }
        /// <summary>The currentState of the button, most of the Buttons scripts logic is based on this variable</summary>
        ButtonStatus _buttonState;

        #region mousebehaviour
        /// <summary>the position of the mouse on the screen</summary>
        Point _mousePoint;
        /// <summary> The mousestate checks what you do with the mouse, like clicking </summary>
        MouseState _mouseState;
        #endregion

        /// <summary> Text that will appear on the button </summary>
        string _buttonText;

        /// <summary>Position of the Text on the button (This doesn't have any other logic attached to it except that it's connected to the button position)</summary>
        Vector2 _textPosition;

        #region Constructors
        /// <summary>
        /// Button with text
        /// </summary>
        /// <param name="pPosition"></param>
        /// <param name="pRectangle"></param>
        /// <param name="pButtonText"></param>
        public ButtonBase(Vector2 pPosition, Rectangle pRectangle, string pButtonText) : base(pPosition, pRectangle)
        {
            _buttonText = pButtonText;
            path = "Button";
        }

        public ButtonBase(Vector2 pPosition, Texture2D pSprite, string pButtonText) : base(pPosition, pSprite, pButtonText)
        {
            _buttonText = pButtonText;
            path = "Button";
        }

        /// <summary>
        /// Button without text
        /// </summary>
        /// <param name="pPosition"></param>
        /// <param name="pRectangle"></param>
        public ButtonBase(Vector2 pPosition, Rectangle pRectangle) : base(pPosition, pRectangle)
        {
            path = "Button";
        }
        #endregion

        /// <summary> Original method: <see cref="GameObject.Update"/>
        /// <see cref="_mouseState"/> gets assigned the value of the Mouse.GetState
        /// <see cref="_mousePoint"/> gets assigned the current mousePosition
        /// This connects the mousePosition to the variable
        /// This switch statement plays the method corresponding to the state it's currently <see cref="_buttonState"/>
        ///     Case 1: When the mouse is hovering over the Collider of the button <see cref="Hovering"/>
        ///     Case 2: When the mouse clicks on the Collider of the button <see cref="Pressed"/>
        ///     Case 3: When the mouse is not interacted with also it's default state <see cref="Normal"/>
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            _mouseState = Mouse.GetState();
            _mousePoint = new Point(_mouseState.X, _mouseState.Y);
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

        /// <summary> Normal
        /// When the button is not interacted with this method plays,
        ///     The variable <see cref="GameObject.color"/> is set to white. 
        ///     The <see cref="GameObject.rectangle"/> for the sprite is set to the first Half of the SpriteSheet "Unpressed".
        ///     The <see cref="_textPosition"/> of the text is set.
        ///     Checks if the <see cref="GameObject.hitBox"> of the button contains the <see cref="_mousePoint"/> (Hovering)
        ///         Changes the variable <see cref="_buttonState"/> to the hovered state
        /// </summary>
        protected virtual void Normal()
        {
            color = Color.White;
            rectangle = new Rectangle(0, 0, 64, 32);
            _textPosition = position;
            if (hitBox.Contains(_mousePoint))
            {
                _buttonState = ButtonStatus.hovered;
            }
        }

        /// <summary> Hovering 
        /// When the button is hovered over this method plays,
        ///     The variable <see cref="GameObject.color"/> is set to LightGray. 
        ///     Checks if the <see cref="GameObject.hitBox"/> doesn't contains the <see cref="_mousePoint"/>. (Hovering). 
        ///         Changes the variable <see cref="_buttonState"/> to the Normal state. 
        ///     Checks if the LeftMouseButton is pressed
        ///         Changes the variable <see cref="_buttonState"/> to the Pressed State. 
        /// </summary>
        protected virtual void Hovering()
        {
            color = Color.LightGray;
            if (!hitBox.Contains(_mousePoint))
            {
                _buttonState = ButtonStatus.normal;
            }
            else if (_mouseState.LeftButton == ButtonState.Pressed)
            {
                _buttonState = ButtonStatus.pressed;
            }
        }

        /// <summary> Pressed
        /// When the button is clicked on with the LeftMouseButton
        ///     The <see cref="GameObject.rectangle"/> for the sprite is set to the Second Half of the SpriteSheet "Pressed".   
        ///     Checks if the LeftMouseButton is released.
        ///         Checks If the <see cref="_mousePoint"/> is inside the collider.
        ///             Plays the <see cref="ButtonBehaviour"/> method.
        ///             Changes the <see cref="_buttonState"/> to the normal state.
        ///         Checks if the <see cref="_mousePoint"/> isn't inside the collider.
        ///             Changes the <see cref="_buttonState"/> to the normal state.
        ///             
        /// Rafael note: they both go to the normal state again the only difference is that if you keep the mouse.
        ///              inside the collider it plays the <see cref="ButtonBehaviour"/> method
        /// </summary>
        protected virtual void Pressed()
        {
            rectangle = new Rectangle(64, 0, 64, 32);
            if (_mouseState.LeftButton == ButtonState.Released)
            {
                if (hitBox.Contains(_mousePoint))
                {
                    ButtonBehaviour();
                    _buttonState = ButtonStatus.normal;
                }
                if (!hitBox.Contains(_mousePoint))
                {
                    _buttonState = ButtonStatus.normal;
                }
            }
        }

        /// <summary> ButtonBehaviour
        /// override this method when you've made a new button to change what happens when pressed
        /// </summary>
        public virtual void ButtonBehaviour()
        {
            Console.WriteLine("Button behaviour");
        }
    }
}
