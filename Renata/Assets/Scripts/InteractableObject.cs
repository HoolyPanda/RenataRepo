using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // Start is called before the first frame update
    public string optionToAdd;
    public GameObject player;
    void Start()
    {
       if (player == null) 
       {
           player = GameObject.FindGameObjectWithTag("Player");
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddDialogueOption()
    {
        // var a = DManager.GetComponent<Canvas>();
        player.GetComponent<Player>().AddDialogueOption(optionToAdd);
    }
}
