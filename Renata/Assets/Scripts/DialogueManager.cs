using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Windows;
using System.IO;
public class DialogueManager : MonoBehaviour
{
    public GameObject player;
    public GameObject boxManager;
    public GameObject dialogueCanvas;
    public TextAsset initNPCPhrase;
    public string NPCName;
    public GameObject NPCGO;
    public TextAsset initRenataPhrase;
    public string currentDialogueDir;
    public GameObject buttonsList;
    public GameObject[] buttons;
    bool isCurrentPraseFromRenata;
    bool phraseEnded = false;
    public GameObject CM;
    bool isConfigLoaded = false;
    public Config.config config;
    public bool phraseLoaded = false;
    // public bool nonContidionalDOptionsLoaded = false;
    public List<string> nonConditionalDOptions;
    public bool isPostDialogueChangesDone = false;
    public bool buttonsLoaded = false;
    public List<Phrase> phrases = new List<Phrase>();
    public bool isDialogueEnded = false;
    public class Phrase
    {
        public TextAsset phraseText;
        public string speakerName;
        public Phrase(TextAsset pT, string sN) 
        {
            phraseText = pT;
            speakerName = sN;
        }
    }
    void Start()
    {
       if (player == null) 
       {
           player = GameObject.FindGameObjectWithTag("Player");
       }
        
    }
    void Update() 
    {
        // TODO rewrite... sometime
        if (player.GetComponent<Player>().stats != null)
        {
            foreach (string item in nonConditionalDOptions)
            {
                player.GetComponent<Player>().AddDialogueOption(item);
                nonConditionalDOptions.Remove(item);
            }
        }
        if (phrases.Count > 0)
        {

            if (!phraseLoaded)
            {
                // if (Input.GetKeyDown(KeyCode.Space))
                // {
                    isCurrentPraseFromRenata = false;
                    boxManager.GetComponent<DialogueBoxManager>().renataPanel.SetActive(false);
                    boxManager.GetComponent<DialogueBoxManager>().npcPanel.SetActive(true);
                    if (isConfigLoaded)
                    {
                        boxManager.GetComponent<DialogueBoxManager>().LoadDialogieAsset(phrases[0], config.isLastPhrase);
                    }
                    else
                    {
                        boxManager.GetComponent<DialogueBoxManager>().LoadDialogieAsset(phrases[0], true);
                    }
                    phrases.Remove(phrases[0]);
                    phraseEnded = false;
                    phraseLoaded = true;
                // }
            }
            // else if (phrases.Count > 0 && !phraseEnded)
            // {
            //     phraseEnded = false;
            // }
            else if (phraseEnded)
            {
                if (isConfigLoaded)
                {
                    if (!isPostDialogueChangesDone)
                    {
                        // if (config.)
                        // TODO dead code need to be refactored may cause bugs
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
                        foreach (string condLine in config.inventoryAddTmp)
                        {
                            string data = condLine.Split( new [] {"add "}, System.StringSplitOptions.None)[1];

                            player.GetComponent<Player>().AddTmpDialogueOption(data);

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
                    // else if (boxManager.GetComponent<DialogueBoxManager>().getOptionsLen() == 0)
                    // {
                    //     if (Input.GetKeyDown(KeyCode.Space))
                    //     {
                    //         boxManager.GetComponent<DialogueBoxManager>().TurnOffDialogue();
                    //     }

                    // }

                }
            }
        }
        else if (phraseEnded && !phraseLoaded && !buttonsLoaded)
        {
            boxManager.GetComponent<DialogueBoxManager>().TurnOnButtons();
            buttonsLoaded = true;
            var b =0 ;
        }
        if (isDialogueEnded && phrases.Count == 0 && !phraseLoaded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // boxManager.GetComponent<DialogueBoxManager>().TurnOffDialogue();
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
                        foreach (string condLine in config.inventoryAddTmp)
                        {
                            string data = condLine.Split( new [] {"add "}, System.StringSplitOptions.None)[1];

                            player.GetComponent<Player>().AddTmpDialogueOption(data);

                        }
                EndDialogue();
            }

        }
        // if 
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
        dialogueCanvas.SetActive(true);
        phraseLoaded = false;
        phraseEnded = true;
        if (boxManager.GetComponent<DialogueBoxManager>().getOptionsLen() == 0)
        {
            isDialogueEnded = true;
        }
    }
    bool OptionAvalibleForPlayer(string optionName, string[] options, string currentDir)
    {
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
        Debug.Log("StartDialogue");
        config = null;
        player.GetComponent<Image>().enabled = true;
        // if (GameObject.FindGameObjectWithTag("NPC").GetComponent<SpriteRenderer>().sprite != null)
        // {
        //     GameObject.FindGameObjectWithTag("NPC").GetComponent<SpriteRenderer>().enabled = true;   
        // }
        phrases = new List<Phrase>();
        isConfigLoaded = false;
        phraseLoaded = false;
        buttonsLoaded = false;
        isDialogueEnded = false;
        boxManager.GetComponent<DialogueBoxManager>().DeleteButtons();
        string[] dialogueOptions = new string[player.GetComponent<Player>().stats.dialogueOptions.Length + player.GetComponent<Player>().stats.tmpOptions.Length];
        player.GetComponent<Player>().stats.dialogueOptions.CopyTo(dialogueOptions, 0);
        var  h =player.GetComponent<Player>().stats.tmpOptions;
        player.GetComponent<Player>().stats.tmpOptions.CopyTo(dialogueOptions,player.GetComponent<Player>().stats.dialogueOptions.Length);
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
                if (config.SpriteAssetToLoad != "")
                {
                    NPCGO.GetComponent<Player>().LoadSprite(config.SpriteAssetToLoad);
                }
                if (config.targetSpriteToLoad.Length != 0)
                {
                    foreach (string line in config.targetSpriteToLoad)
                    {
                        string[] c = line.Split(' ');
                        string targetGOName = c[0];
                        string targetGOSprite = c[1];
                        Debug.Log(targetGOName);
                        Debug.Log(targetGOSprite);
                        var target = GameObject.Find(targetGOName);
                        target.GetComponent<Player>().LoadSpriteByName(targetGOSprite);
                        var b = 0;
                    }
                    NPCGO.GetComponent<Player>().LoadSprite(config.SpriteAssetToLoad);
                }
                isConfigLoaded = true;
            }
        }
        foreach (var item in dialogueOptions)
        {
            bool passSpawn = false;
            if (!OptionAvalibleForPlayer(item, OptionsDir, dialoguesDir))
            {
                passSpawn = true;
            }
            if (isConfigLoaded)
            {
                // var mmmm = config.exclusiveConditions.Length;
                if (config.exclusiveConditions.Length > 0)
                {
                    foreach (string condLine in config.exclusiveConditions)
                    {
                        string exclusiveCondition = condLine.Split( new [] {"only "}, System.StringSplitOptions.None)[1];
                        string optionName = exclusiveCondition.Split( new [] {" if "}, System.StringSplitOptions.None)[0];
                        string targetParamName = exclusiveCondition.Split( new [] {" if "}, System.StringSplitOptions.None)[1];
                        
                        if ((player.GetComponent<Player>().GetStatByName(targetParamName) == 4.0f) && item != optionName)
                        {   
                            passSpawn = true;
                        }
                    }
                }
                else
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
                                if (!(player.GetComponent<Player>().GetStatByName(targetParamName) > (float)targetValue))
                                {   
                                    passSpawn = true;
                                }
                            }
                            else if (comparationRule == "<")
                            {
                                if (!(player.GetComponent<Player>().GetStatByName(targetParamName) < (float)targetValue))
                                {   
                                    passSpawn = true;
                                }
                            }
                            else if (comparationRule == ">=")
                            {
                                if (!(player.GetComponent<Player>().GetStatByName(targetParamName) >= (float)targetValue))
                                {   
                                    passSpawn = true;
                                }
                            }
                            else if (comparationRule == "<=")
                            {
                                if (!(player.GetComponent<Player>().GetStatByName(targetParamName) <= (float)targetValue))
                                {   
                                    passSpawn = true;
                                }
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
            // }
        }
        foreach (var item in tmpfiles)
        {
           if (item.EndsWith(".txt") && !item.EndsWith("ната.txt"))
           {

               string itemName = item.Substring(dialoguesDir.Length+1);
               initNPCPhrase = Resources.Load<TextAsset>("Dialogues/"+dialogueFolderPath+'/'+itemName.Replace(".txt", ""));
               NPCName = itemName.Replace(".txt", "").Remove(0,1);
               Phrase p = new Phrase(initNPCPhrase, NPCName);
               phrases.Add(p);
               phraseEnded = false;
           }
           if (item.EndsWith("ната.txt"))
           {
               string itemName = item.Substring(dialoguesDir.Length+1);
               initRenataPhrase = Resources.Load<TextAsset>("Dialogues/"+dialogueFolderPath+'/'+itemName.Replace(".txt", ""));
               Phrase p = new Phrase(initRenataPhrase, "Рената");
               phrases.Add(p);
               phraseEnded = false;
           }
        }
        if (initRenataPhrase != null)
        {
            isCurrentPraseFromRenata = true;
            dialogueCanvas.SetActive(true);
            // boxManager.GetComponent<DialogueBoxManager>().LoadDialogieAsset(initRenataPhrase, "Рената", false);
        }
        else if (initNPCPhrase != null && initRenataPhrase == null)
        {
            dialogueCanvas.SetActive(true);
            isCurrentPraseFromRenata = false;
            // boxManager.GetComponent<DialogueBoxManager>().LoadDialogieAsset(initNPCPhrase, NPCName, true);
        }
        currentDialogueDir = dialogueFolderPath;
    }
    public void EndDialogue()
    {
        boxManager.GetComponent<DialogueBoxManager>().TurnOffDialogue();
        player.GetComponent<Image>().enabled =false;
        GameObject.FindGameObjectWithTag("DialogueCanvas").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("NPC").GetComponent<Image>().enabled = false;
        this.currentDialogueDir = "";
    }
}
// fdsafasfas