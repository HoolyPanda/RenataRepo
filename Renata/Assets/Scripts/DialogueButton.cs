using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DManager;
    public string DFolder;
    void Start()
    {
        // gameObject.GetComponent<Button>().onClick.AddListener();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartDialogue()
    {
        // var a = DManager.GetComponent<Canvas>();
        DManager.GetComponent<DialogueManager>().StartDialogue(DFolder);
    }
}
