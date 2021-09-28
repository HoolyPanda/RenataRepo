using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOptionButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public delegate void newAction();

    public void SetAction(newAction action)
    {
        UnityEngine.Event a = new UnityEngine.Event();
        gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate {action();});

    }
}
