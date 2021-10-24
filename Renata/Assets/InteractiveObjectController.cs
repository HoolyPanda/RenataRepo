using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectController : MonoBehaviour
{
    public GameObject player;
    public string targetMood;
    public float moodChangeVal;
    // Start is called before the first frame update
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
    public void HandleInteraction()
    {
        
    }
}
