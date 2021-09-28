using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTextImporer : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset textSource;
    public string[] textLines;


    void Start()
    {
        if ( textSource != null)
        {
            textLines = (textSource.text.Split('\n'));
            
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
