using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.LevelSelector
{
    public class Tutorial : SceneBase
    {
        TutorialTextButton backButton;
        Texture2D background;

        public enum DisplayTutorialTextState
        {
            Buttons,
            VisualNovel,
            Wanted,
            Dodge,
            BlackJack
        }

        DisplayTutorialTextState currentState = DisplayTutorialTextState.Buttons;

        public Tutorial(Game1 pGame1) : base(pGame1)
        {
            CreateObjects();
        }

        protected override void CreateObjects()
        {
            background = game.Content.Load<Texture2D>("Sprites\\Backgrounds\\StarsBackground");

            backButton = new TutorialTextButton(this, DisplayTutorialTextState.Buttons, new Vector2(164, game.GetGraphics().PreferredBackBufferHeight - 164), new Rectangle(0, 0, 64, 32), "Back to buttons");
            backButton.LoadSprite(game.Content);
            TutorialTextButton text = new TutorialTextButton(this, DisplayTutorialTextState.VisualNovel, new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, 300), new Rectangle(0, 0, 64, 32), "Visual novel");
            TutorialTextButton wanted = new TutorialTextButton(this, DisplayTutorialTextState.Wanted, new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, 450), new Rectangle(0, 0, 64, 32), "Wanted");
            TutorialTextButton dodge = new TutorialTextButton(this, DisplayTutorialTextState.Dodge, new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, 600), new Rectangle(0, 0, 64, 32), "Dodge");
            TutorialTextButton blackJack = new TutorialTextButton(this, DisplayTutorialTextState.BlackJack, new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, 750), new Rectangle(0, 0, 64, 32), "Black Jack");

            UiSceneContent.Add(text);
            UiSceneContent.Add(wanted);
            UiSceneContent.Add(dodge);
            UiSceneContent.Add(blackJack);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(background, new Vector2(0, 0), Color.White);

            pSpriteBatch.DrawString(game.gameFont, "TUTORIAL", new Vector2(game.Window.ClientBounds.Width / 2, 200f), Color.Yellow, 0f, game.gameFont.MeasureString("TUTORIAL") / 2, 1f, SpriteEffects.None, 1f);
            DrawState(pSpriteBatch);
        }

        public override void Update(GameTime pGameTime)
        {
            UpdateState(pGameTime);
        }

        private void DrawState(SpriteBatch pSpriteBatch)
        {
            switch (currentState)
            {
                case DisplayTutorialTextState.Buttons:
                    base.Draw(pSpriteBatch);
                    break;
                case DisplayTutorialTextState.VisualNovel:
                    backButton.Draw(pSpriteBatch);
                    backButton.DrawText(pSpriteBatch, game.gameFont);

                    pSpriteBatch.DrawString(game.gameFont, "Wait for the text to finish, or speed it up with the right arrow key", new Vector2(game.Window.ClientBounds.Width / 2, 500f), Color.Yellow, 0f, game.gameFont.MeasureString("Wait for the text to finish, or speed it up with the right arrow key") / 2, 1f, SpriteEffects.None, 1f);
                    pSpriteBatch.DrawString(game.gameFont, "You are sometimes presented with different options you can pick one by clicking on it", new Vector2(game.Window.ClientBounds.Width / 2, 600f), Color.Yellow, 0f, game.gameFont.MeasureString("You are sometimes presented with different options you can pick one by clicking on it") / 2, 1f, SpriteEffects.None, 1f);
                    break;
                case DisplayTutorialTextState.Wanted:
                    backButton.Draw(pSpriteBatch);
                    backButton.DrawText(pSpriteBatch, game.gameFont);

                    pSpriteBatch.DrawString(game.gameFont, "Move the circle around with W,A,S,D, hover over the wanted sprite for 3 seconds to select it", new Vector2(game.Window.ClientBounds.Width / 2, 500f), Color.Yellow, 0f, game.gameFont.MeasureString("Move the circle around with W,A,S,D, hover over the wanted sprite for 3 seconds to select it") / 2, 1f, SpriteEffects.None, 1f);
                    pSpriteBatch.DrawString(game.gameFont, "Change speed with space bar", new Vector2(game.Window.ClientBounds.Width / 2, 600f), Color.Yellow, 0f, game.gameFont.MeasureString("Change speed with space bar") / 2, 1f, SpriteEffects.None, 1f);
                    break;
                case DisplayTutorialTextState.Dodge:
                    backButton.Draw(pSpriteBatch);
                    backButton.DrawText(pSpriteBatch, game.gameFont);

                    pSpriteBatch.DrawString(game.gameFont, "Move up or down the 'lanes' with the W or S key, try to avoid the objects", new Vector2(game.Window.ClientBounds.Width / 2, 500f), Color.Yellow, 0f, game.gameFont.MeasureString("Move up or down the 'lanes' with the W or S key, try to avoid the objects") / 2, 1f, SpriteEffects.None, 1f);
                    break;
                case DisplayTutorialTextState.BlackJack:
                    backButton.Draw(pSpriteBatch);
                    backButton.DrawText(pSpriteBatch, game.gameFont);

                    pSpriteBatch.DrawString(game.gameFont, "Try to get as close to 21 as you can, but watch out if your total is higher than 21 you lose", new Vector2(game.Window.ClientBounds.Width / 2, 500f), Color.Yellow, 0f, game.gameFont.MeasureString("Try to get as close to 21 as you can, but watch out if your total is higher than 21 you lose") / 2, 1f, SpriteEffects.None, 1f);
                    pSpriteBatch.DrawString(game.gameFont, "If your total is higher than the dealer and under 22 you win", new Vector2(game.Window.ClientBounds.Width / 2, 600f), Color.Yellow, 0f, game.gameFont.MeasureString("If your total is higher than the dealer and under 22 you win") / 2, 1f, SpriteEffects.None, 1f);
                    pSpriteBatch.DrawString(game.gameFont, "You can get an extra card by clicking on hit, if your happy with your cards click on stand", new Vector2(game.Window.ClientBounds.Width / 2, 700f), Color.Yellow, 0f, game.gameFont.MeasureString("You can get an extra card by clicking on hit, if your happy with your cards click on stand") / 2, 1f, SpriteEffects.None, 1f);
                    break;
            }
        }

        private void UpdateState(GameTime pGameTime)
        {
            switch (currentState)
            {
                case DisplayTutorialTextState.Buttons:
                    base.Update(pGameTime);
                    break;
                case DisplayTutorialTextState.VisualNovel:
                    backButton.Update(pGameTime);
                    break;
                case DisplayTutorialTextState.Wanted:
                    backButton.Update(pGameTime);
                    break;
                case DisplayTutorialTextState.Dodge:
                    backButton.Update(pGameTime);
                    break;
                case DisplayTutorialTextState.BlackJack:
                    backButton.Update(pGameTime);
                    break;
            }
        }

        public void ChangeState(DisplayTutorialTextState pState)
        {
            currentState = pState;
        }
    }
}
