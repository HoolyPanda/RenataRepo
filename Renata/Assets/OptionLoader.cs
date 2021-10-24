using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] options;
    public bool isOptionsAdded = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOptionsAdded)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().stats != null)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().stats.tmpOptions = options;
                isOptionsAdded = true;
            }
        }
        
    }
}
