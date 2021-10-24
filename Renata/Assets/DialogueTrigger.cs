using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public string dialogue;
    public GameObject targetGO;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnMouseUp()
    {
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
