using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using 
// using 
public class ButtonsManager : MonoBehaviour
{

    public ScriptableObject dButton;
    public GameObject prefab;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public delegate void newAction(string payload);

    public void SetAction(UnityEngine.UI.Button button, newAction action, string payload)
    {
        button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate {action(payload);});

    }
    
    public GameObject CreateButton(string buttonName, string buttonText, newAction action, string actionPayload)
    {
        foreach (UnityEngine.UI.Button item in gameObject.GetComponentsInChildren<UnityEngine.UI.Button>())
        {
            if (item.name == buttonName)
            {
                return null;
            }   
        }
        var c = buttonName;
        GameObject b = Instantiate(prefab) as GameObject;
        b.name = buttonName;
        b.transform.SetParent(this.transform);
        b.GetComponentInChildren<UnityEngine.UI.Text>().text = buttonText;
        SetAction(b.GetComponent<UnityEngine.UI.Button>(), action, actionPayload);
        return b;
    }

}
