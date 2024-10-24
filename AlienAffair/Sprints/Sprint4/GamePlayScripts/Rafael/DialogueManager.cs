using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Rafael;

public class DialogueManager
{
    public Dictionary<string, Dialogue> _allDialogue;
    public Dialogue dialogueData;
    public string DialogueKey;

    string _json;
    public string Json
    {
        get
        {
            return _json;
        }
        set
        {
            _json = value;
            _allDialogue = JsonSerializer.Deserialize<Dictionary<string, Dialogue>>(Json);
            ChangeDialogueData("start");
            ChangeDialogueData("start");
        }
    }

    public DialogueManager(string pJsonFilePath)
    {
        // Load the dialogue data from a JSON file
        ChangeJsonPath(pJsonFilePath);
        _allDialogue = JsonSerializer.Deserialize<Dictionary<string, Dialogue>>(Json);
        ChangeDialogueData("start");
        Console.WriteLine(dialogueData.Text);

    }

    public void ChangeDialogueData(string pNext)
    {
        DialogueKey = pNext;
        dialogueData = _allDialogue[DialogueKey];
    }

    public void ChangeJsonPath(string pJsonFilePath)
    {
        Json = File.ReadAllText(pJsonFilePath);
    }
}
