using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public string dialogue;
    public GameObject targetGO;
    public DialogueManager DM;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnMouseUp()
    {
        try
        {
            DM = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>();
             
        }
        catch (System.Exception)
        {
            
        }
        if (DM != null)
        {
            DM.NPCGO = targetGO;
        }
        if (!GameObject.FindGameObjectWithTag("DialogueCanvas").GetComponent<Canvas>().enabled)
        {
            if (dialogue != null)
            {
                if (targetGO != null)
                {
                    targetGO.GetComponent<SpriteRenderer>().enabled = true;
                }    
                GameObject.FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }

        }
    }
}
