using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public string dialogue;
    public GameObject targetGO;
    public DialogueManager DM;
    public string LoadScene; 
    public ScenesManager SM;

    private void Start()
    {
        try
        {
            //DM = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>(); 
            DM = FindObjectOfType<DialogueManager>();
            SM = FindObjectOfType<ScenesManager>();
        }
        catch (System.Exception)
        {
        }

        if (DM != null && targetGO !=null)
        {
            DM.NPCGO = targetGO;
        }
        if (!GameObject.FindGameObjectWithTag("DialogueCanvas")) 
        {
            if (dialogue != null)
            {
                if (targetGO != null)
                {
                    //targetGO.GetComponent<Image>().enabled = true;
                }
                //DM.StartDialogue(dialogue);
            }
        }
    }
    public void OnMouseUp()
    {
        if (DM.currentDialogueDir == "")
        {
            DM.StartDialogue(dialogue);
            if (targetGO != null)
            {
                targetGO.GetComponent<Image>().enabled = true;
            }
        }
        if (LoadScene != "")
        {
            SM.LoadSceneByName(LoadScene);
        }
    }
}
