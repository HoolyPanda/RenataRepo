using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueBoxManager : MonoBehaviour
{
    public GameObject textBoxPanel;
    public GameObject buttonsPanel;
    public GameObject exitButton;
    public GameObject renataPanel;
    public GameObject npcPanel;
    public Text text;
    public TextAsset textSource;
    public TextAsset seckondTextSource;
    public string[] textLines;
    public int currentLine;
    public int lastLine;
    bool dialogueEnabled = true;
    bool isTyping = false;
    bool cancelTyping = false;
    public float typeSpeed = 0.15f;
    public bool turnOnDialogueOption = false;
    public DialogueManager DM;
    Button politeButton;
    Button rudeButton;
    Button silentButton;

    IEnumerator TextScroll (string textLine)
    {
        int letter = 0;
        text.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && letter < textLine.Length -1)
        {   

            text.text += textLine[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        text.text = textLine;
        isTyping = false;
        cancelTyping = true;
    }
    void Start()
    {
        buttonsPanel.SetActive(false);
        TurnOffDialogue();
    }

    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.Space)) && dialogueEnabled)
        {
            if (!isTyping)
            {

                if (currentLine > lastLine)
                {
                    
                    currentLine -= 1;
                    if (turnOnDialogueOption)
                    {
                        UnityEngine.UI.Button[] blist = buttonsPanel.GetComponentsInChildren<UnityEngine.UI.Button>();
                        foreach (UnityEngine.UI.Button item in blist)
                        {
                            item.interactable = true;   
                            // item.
                            var s = false;
                        }
                        buttonsPanel.SetActive(true);
                    }
                    DM.PhraseEnded();
                }
                else
                {
                    try
                    {
                        StartCoroutine(TextScroll(textLines[currentLine]));
                    }
                    catch (System.Exception)
                    {
                        cancelTyping = true;
                        DM.PhraseEnded();
                        throw;
                        var mm = 0;
                    }
                }
                currentLine += 1;
            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
                DM.PhraseEnded();
            }
        }
    }
    public void TurnOnDialogue()
    {
        dialogueEnabled = true;
        isTyping = false;
        cancelTyping = false;
        currentLine = 0;
        if ( textSource != null)
        {
            textLines = (textSource.text.Split('\n'));
            
        }   
        if (lastLine == 0)     
        {
            lastLine = textLines.Length - 1;
        }
        textBoxPanel.SetActive(true);
        buttonsPanel.SetActive(false);
        exitButton.SetActive(true);
    }
    public void TurnOffDialogue()
    {
        dialogueEnabled = false;
        textBoxPanel.SetActive(false);
        exitButton.SetActive(false);
        // buttonsPanel.SetActive(false);
        renataPanel.SetActive(false);
        npcPanel.SetActive(false);
        text.text = "...";
        isTyping = false;
        cancelTyping = false;
    }
    // public void LoadDialogieAsset(TextAsset newText, string speaker, bool isLastPhrase)
    // {
    //     Phrase phrase= new Phrase(newText, speaker);
    //     phrases.Add(phrase);
    // }
    public void LoadDialogieAsset(DialogueManager.Phrase phrase, bool isLastPhrase)
    {
        TurnOffButtons();
        isTyping = false;
        cancelTyping = false;
        lastLine = 0;
        TextAsset newText = phrase.phraseText;
        string speaker = phrase.speakerName;
        turnOnDialogueOption = isLastPhrase;
        if (newText != null)
        {
            textSource = newText;
            if ( textSource != null)
            {
                textLines = (textSource.text.Split('\n'));
                
            }   
            if (lastLine == 0)     
            {
                lastLine = textLines.Length - 1;
            }
            TurnOnDialogue();
        }
        if (speaker != "Рената")
        {
            npcPanel.GetComponentInChildren<Text>().text = speaker;
            npcPanel.SetActive(true);
            renataPanel.SetActive(false);
            text.text = "...";
        }
        else
        {
            renataPanel.SetActive(true);
            npcPanel.SetActive(false);
            text.text = "...";
        }
    }
    public void TurnOnButtons()
    {
        this.buttonsPanel.SetActive(true);
    }
    public void TurnOffButtons()
    {
        // this.buttonsPanel.SetActive(false);
    }
    public void DeleteButtons()
    {
        var buttons = buttonsPanel.GetComponentsInChildren<UnityEngine.UI.Button>();
        foreach ( var b in  buttons)
        {
            
            Destroy(b.gameObject);
            var mm = 0; 
        }
    }
    public int getOptionsLen()
    {
        var buttons = buttonsPanel.GetComponentsInChildren<UnityEngine.UI.Button>();
        return buttons.Length;

    }
}