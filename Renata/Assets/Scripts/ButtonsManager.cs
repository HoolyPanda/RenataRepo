using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using 
// using 
public class ButtonsManager : MonoBehaviour
{

    // public ScriptableObject dButton;
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
        // GameObject b = new GameObject();
        // button.transform.parent = panel;
        // b.AddComponent<RectTransform>();
        // b.AddComponent<UnityEngine.UI.Button>();
        // b.AddComponent<UnityEngine.UI.Text>();
        b.name = buttonName;
        // b.GetComponent<RectTransform>().localScale = new Ve(1,1,1);
        b.transform.SetParent(this.transform, false);
        b.GetComponentInChildren<TMPro.TMP_Text>().text = buttonText;
        SetAction(b.GetComponent<UnityEngine.UI.Button>(), action, actionPayload);
        return b;
    }
    public void DeleteButtons()
    {
        GameObject[] buttons = this.GetComponentsInChildren<GameObject>();
        var b = 0;
    }
}
