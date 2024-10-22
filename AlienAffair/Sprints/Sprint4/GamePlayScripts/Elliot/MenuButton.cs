using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.LevelSelector
{
    public class MenuButton : ButtonBase
    {
        SpriteFont font;
        Game1 game1;

        public MenuButton(Game1 pGame1, Vector2 pPosition, Rectangle pRectangle, SpriteFont pFont, string pButtonText) : base(pPosition, pRectangle, pButtonText)
        {
            path = "Sprites/Button";
            scale = new Vector2(4f, 4f);
            rectangle = new Rectangle(0, 0, 64, 32);
            font = pFont;
            game1 = pGame1;
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            if (game1.GetCurrentScene() != GameStates.TitleScreen && game1.GetCurrentScene() != GameStates.MenuScene)
            {
                base.Draw(pSpriteBatch, font);
            }
        }

        public override void ButtonBehaviour()
        {
            base.ButtonBehaviour();
            game1.LoadGame1();
        }
    }
}