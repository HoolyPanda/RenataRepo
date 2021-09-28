using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Windows;
using System.IO;
public class DialogueManager : MonoBehaviour
{
    public GameObject player;
    public GameObject boxManager;
    public Canvas dialogueCanvas;
    public TextAsset initNPCPhrase;
    public string NPCName;
    public TextAsset initRenataPhrase;
    public string currentDialogueDir;
    public GameObject buttonsList;
    public GameObject[] buttons;
    bool isCurrentPraseFromRenata;
    bool phraseEnded = false;
    public GameObject CM;
    bool isConfigLoaded = false;
    public Config.config config;
    public bool isPostDialogueChangesDone = false;
    void Start()
    {
        
    }
    void Update()
    {
        if (isCurrentPraseFromRenata && phraseEnded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isCurrentPraseFromRenata = false;
                boxManager.GetComponent<DialogueBoxManager>().renataPanel.SetActive(false);
                boxManager.GetComponent<DialogueBoxManager>().npcPanel.SetActive(true);
                if (isConfigLoaded)
                {
                    boxManager.GetComponent<DialogueBoxManager>().LoadDialogieAsset(initNPCPhrase, NPCName, !config.isLastPhrase);
                }
                else
                {
                    boxManager.GetComponent<DialogueBoxManager>().LoadDialogieAsset(initNPCPhrase, NPCName, true);
                }
                phraseEnded = false;
            }
        }
        else if (phraseEnded)
        {
            if (isConfigLoaded)
            {
                if (!isPostDialogueChangesDone)
                {
                    foreach (string condLine in config.postStatChanges)
                    {
                        string data = condLine.Split( new [] {"change "}, System.StringSplitOptions.None)[1];
                        string[] d = data.Split(' ');
                        string targetParamName = d[0];
                        string sModificationVal = d[1];
                        int modificationVal = 0;
                        System.Int32.TryParse(sModificationVal, out modificationVal);
                        if (targetParamName == "apathyAgressionMood")
                        {
                            player.GetComponent<Player>().ChangeapathyAgressionMoodBy((float)modificationVal);
                        }
                        else if (targetParamName == "silenceWordsMood")
                        {
                            player.GetComponent<Player>().ChangesilenceWordsMoodBy((float)modificationVal);
                        }
                        else if (targetParamName == "submissionRevoltMood")
                        {
                            player.GetComponent<Player>().ChangesubmissionRevoltMoodBy((float)modificationVal);
                        }
                        else if (targetParamName == "trustParanoiaMood")
                        {
                            player.GetComponent<Player>().ChangetrustParanoiaMoodBy((float)modificationVal);
                        }
                    }
                    foreach (string condLine in config.inventoryAdd)
                    {
                        string data = condLine.Split( new [] {"add "}, System.StringSplitOptions.None)[1];

                        player.GetComponent<Player>().AddDialogueOption(data);

                    }
                }
                isPostDialogueChangesDone = true;
            }
            if (isConfigLoaded)
            {
                if (config.isLastPhrase)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        boxManager.GetComponent<DialogueBoxManager>().TurnOffDialogue();
                    }
                }
            }
        }
    }
    void test()
    {
        Debug.Log("TEst");
    }

    public void HandleButtonPressed(string targetFolder)
    {
        this.boxManager.GetComponentInChildren<DialogueBoxManager>().TurnOffDialogue();
        this.boxManager.GetComponentInChildren<DialogueBoxManager>().text.text = "...";
        this.boxManager.GetComponentInChildren<DialogueBoxManager>().currentLine = 0;
        this.boxManager.GetComponentInChildren<DialogueBoxManager>().TurnOffButtons();
        StartDialogue(currentDialogueDir+"/"+targetFolder); 
    }


    public void PhraseEnded()
    {
        dialogueCanvas.enabled = true;
        phraseEnded = true;
    }
    bool OptionAvalibleForPlayer(string optionName, string[] options, string currentDir)
    {
        // TODO баг с появлением кнопок из инвентаря, если нет папок
        foreach (var item in options)
        {
            var i = item.Substring(currentDir.Length+1);
            if (i == optionName)
            {
                return true;
            }   
        }
        return false;
    }
    public void StartDialogue(string dialogueFolderPath)
    {
        config = null;
        isConfigLoaded = false;
        var dialogueOptions = player.GetComponent<Player>().dialogueOptions;
        string dialoguesDir = Application.dataPath+"/Resources/Dialogues/"+dialogueFolderPath;
        var OptionsDir = Directory.GetDirectories(dialoguesDir, "*", SearchOption.TopDirectoryOnly);
        var tmpfiles = Directory.GetFiles(dialoguesDir);
        isConfigLoaded = false;
        isPostDialogueChangesDone = false;
        foreach (var item in tmpfiles)
        {
            if (item.EndsWith("config.json"))
            {
                string itemName = item.Substring(dialoguesDir.Length+1);
                config = CM.GetComponent<Config>().LoadConfig("Dialogues/"+dialogueFolderPath+'/'+itemName);
                foreach (string condLine in config.preStatChanges)
                {
                    string data = condLine.Split( new [] {"change "}, System.StringSplitOptions.None)[1];
                    string[] d = data.Split(' ');
                    string targetParamName = d[0];
                    string sModificationVal = d[1];
                    int modificationVal = 0;
                    System.Int32.TryParse(sModificationVal, out modificationVal);
                    if (targetParamName == "apathyAgressionMood")
                    {
                        player.GetComponent<Player>().ChangeapathyAgressionMoodBy((float)modificationVal);
                    }
                    else if (targetParamName == "silenceWordsMood")
                    {
                        player.GetComponent<Player>().ChangesilenceWordsMoodBy((float)modificationVal);
                    }
                    else if (targetParamName == "submissionRevoltMood")
                    {
                        player.GetComponent<Player>().ChangesubmissionRevoltMoodBy((float)modificationVal);
                    }
                    else if (targetParamName == "trustParanoiaMood")
                    {
                        player.GetComponent<Player>().ChangetrustParanoiaMoodBy((float)modificationVal);
                    }                    
                }
                isConfigLoaded = true;
            }
        }
        foreach (var item in dialogueOptions)
        {
            bool passSpawn = false;
            if (OptionAvalibleForPlayer(item, OptionsDir, dialoguesDir))
            {
                if (isConfigLoaded)
                {
                    foreach (string condLine in config.conditionstrings)
                    {
                        string optionName = condLine.Split( new [] {" if "}, System.StringSplitOptions.None)[0];
                        string c = condLine.Split( new [] {" if "}, System.StringSplitOptions.None)[1];
                        string[] d = c.Split(' ');
                        string targetParamName = d[0];
                        string comparationRule = d[1];
                        int targetValue = (int)char.GetNumericValue(d[2].ToCharArray()[0]);
                        var a = player.GetComponent<Player>();
                        if (item == optionName)
                        {
                            if (comparationRule == ">")
                            {
                                if (!((float)typeof(Player).GetField(targetParamName).GetValue(player.GetComponent<Player>()) > (float)targetValue))
                                {   
                                    passSpawn = true;
                                }
                            }
                            else if (comparationRule == "<")
                            {
                                if (!((float)typeof(Player).GetField(targetParamName).GetValue(player.GetComponent<Player>()) < (float)targetValue))
                                {   
                                    passSpawn = true;
                                }
                            }
                            else if (comparationRule == ">=")
                            {
                                if (!((float)typeof(Player).GetField(targetParamName).GetValue(player.GetComponent<Player>()) >= (float)targetValue))
                                {   
                                    passSpawn = true;
                                }
                            }
                            else if (comparationRule == "<=")
                            {
                                if (!((float)typeof(Player).GetField(targetParamName).GetValue(player.GetComponent<Player>()) <= (float)targetValue))
                                {   
                                    passSpawn = true;
                                }
                            }
                        }
                    }
                }
                if (!passSpawn)
                {
                    buttonsList.GetComponentInChildren<ButtonsManager>().CreateButton(item, item, HandleButtonPressed, item);
                }
                passSpawn = false;
            }
        }
        foreach (var item in tmpfiles)
        {
           if (item.EndsWith(".txt") && !item.EndsWith("Рената.txt"))
           {
               string itemName = item.Substring(dialoguesDir.Length+1);
               initNPCPhrase = Resources.Load<TextAsset>("Dialogues/"+dialogueFolderPath+'/'+itemName.Replace(".txt", ""));
               NPCName = itemName.Replace(".txt", "");
               phraseEnded = false;
           }
           if (item.EndsWith("Рената.txt"))
           {
               string itemName = item.Substring(dialoguesDir.Length+1);
               initRenataPhrase = Resources.Load<TextAsset>("Dialogues/"+dialogueFolderPath+'/'+itemName.Replace(".txt", ""));
               phraseEnded = false;
           }
        }
        if (initRenataPhrase != null)
        {
            isCurrentPraseFromRenata = true;
            dialogueCanvas.enabled = true;
            boxManager.GetComponent<DialogueBoxManager>().LoadDialogieAsset(initRenataPhrase, "Рената", false);
        }
        else if (initNPCPhrase != null && initRenataPhrase == null)
        {
            dialogueCanvas.enabled = true;
            isCurrentPraseFromRenata = false;
            boxManager.GetComponent<DialogueBoxManager>().LoadDialogieAsset(initNPCPhrase, NPCName, true);
        }
        currentDialogueDir = dialogueFolderPath;
    }
}
