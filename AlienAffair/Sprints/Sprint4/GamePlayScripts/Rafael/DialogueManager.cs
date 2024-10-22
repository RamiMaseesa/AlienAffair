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

    public DialogueManager(string jsonFilePath, string chapter)
    {
        // Load the dialogue data from a JSON file
        string json = File.ReadAllText(jsonFilePath);
        //var allChapters = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, Dialogue>>>(json);
        var allChapters = JsonSerializer.Deserialize<Dictionary<string, Dialogue>>(json);

        GetChapter(allChapters, chapter);
    }

    public void GetChapter(Dictionary<string, Dialogue> pAllDialogue, string pChapter)
    {
        _allDialogue = pAllDialogue;
        ChangeDialogueData("start");
        Console.WriteLine(dialogueData.Text);
    }

    public void ChangeDialogueData(string pNext)
    {
        DialogueKey = pNext;
        dialogueData = _allDialogue[DialogueKey];
    }
}
