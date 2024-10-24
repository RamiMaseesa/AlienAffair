using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.LevelSelector;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Rafael;

public class MenuScene : SceneBase
{
    Texture2D background;

    public MenuScene(Game1 pGame) : base(pGame)
    {
        CreateObjects();
    }

    protected override void CreateObjects()
    {
        base.CreateObjects();

        background = game.Content.Load<Texture2D>("Sprites\\Backgrounds\\StarsBackground");

        UiSceneContent.Add(new PlayButton(new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, 300), new Rectangle(3, 35, 58, 26), "Play"));
        UiSceneContent.Add(new MinigamesButton(new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, 450), new Rectangle(3, 35, 58, 26), "Minigames"));
        UiSceneContent.Add(new TutorialButton(new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, 600), new Rectangle(3, 35, 58, 26), "Tutorial"));
        UiSceneContent.Add(new ExitButton(new Vector2(game.GetGraphics().PreferredBackBufferWidth / 2, 750), new Rectangle(3, 35, 58, 26), "Exit"));
    }

    public override void Draw(SpriteBatch pSpriteBatch)
    {
        pSpriteBatch.Draw(background, new Vector2(0, 0), Color.White);

        pSpriteBatch.DrawString(game.gameFont, "MAIN MENU", new Vector2(game.Window.ClientBounds.Width / 2, 200f), Color.Yellow, 0f, game.gameFont.MeasureString("MAIN MENU") / 2, 1f, SpriteEffects.None, 1f);

        base.Draw(pSpriteBatch);
    }
}
