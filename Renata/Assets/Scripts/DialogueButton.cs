using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogueManager DManager;
    public string DFolder;
    void Start()
    {
        // gameObject.GetComponent<Button>().onClick.AddListener();
        if (DManager == null)
        {
            DManager = GameObject.FindGameObjectWithTag("DialogueCanvas").GetComponentInChildren<DialogueManager>();
            var b = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartDialogue()
    {
        // var a = DManager.GetComponent<Canvas>();
        DManager.StartDialogue(DFolder);
    }
}
