using AlienAffair.Sprints.Sprint3.GamePlayScripts.Rafael;
using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Text.Json;
using AlienAffair.Sprints.Sprint3.GamePlayScripts;
using System.Collections.Generic;
using System;

namespace AlienAffair.Sprints.Sprint3.FrameWorkScripts
{
    public class TextWriterScene : SceneBase
    {
        //Tutorial on https://www.tutlane.com/tutorial/csharp/csharp-properties-get-set
        Dialogue _currentDialogue;
        DialogueManager dialogueManager;


        public Dialogue CurrentDialogue
        {
            get { return _currentDialogue; }
            set
            {
                if (_currentDialogue != value)
                {
                    _currentDialogue = value;
                    _currentDialogue.ResetDialogue();
                    _currentDialogue.SetPixel(game.pixel);
                    _currentDialogue.SetSpriteFont(game.gameFont);
                    _currentDialogue.GetDialogueManager(dialogueManager);
                    for (int i = 0; i < _currentDialogue.Text.Length; i++)
                    {
                         _currentDialogue.Text[i].ResetDialogue();
                    }
                }
            }
        }

        public TextWriterScene(Game1 pGame) : base(pGame)
        {
            dialogueManager = new DialogueManager("Content/Json/Chapter2.json", "Chapter1");
        }

        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);

            CurrentDialogue = dialogueManager.dialogueData;

            //KeyboardState kstate = Keyboard.GetState();

            _currentDialogue.Update(pGameTime);
            _currentDialogue.Update(pGameTime);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
            _currentDialogue.Draw(pSpriteBatch, game.gameFont);
        }

        public override void LoadContent(ContentManager pContent)
        {
            base.LoadContent(pContent);
            CurrentDialogue = dialogueManager.dialogueData;

            var jsonFile = File.ReadAllText("Content/Json/Chapter1.json");
        }
    }
}
