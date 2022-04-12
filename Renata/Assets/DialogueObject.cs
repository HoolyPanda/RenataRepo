using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Reflection;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueObject : MonoBehaviour
{
    // Start is called before the first frame update

    public class s
    {
        public string dialogue = "";
        public string LocationToLoad = "";
    }
    public s stats;

    public bool statsValChanged { get; private set; }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Start()
    {
        var a = this.gameObject;
        stats = new s();
        try
        {
            Load();
            
        }
        catch (System.Exception)
        {
            Save();
            Load();
            // throw;
        }
        // Save();

        if (GameObject.FindGameObjectWithTag("DialogueCanvas"))
        {
            
        }
    }

    public s Load()
    {
        string dialoguesDir = Application.dataPath+"/Saves/"+this.name;
        s CFG  = JsonUtility.FromJson<s>(File.ReadAllText(dialoguesDir));
        this.stats = CFG;
        statsValChanged = true;
        var o = typeof(s).GetFields();
        foreach (var param in o)
        {
            if (param.GetValue(this.stats) != "")
            {

                var j = param.GetValue(this.stats);
                var a = this.gameObject.GetComponentInChildren<DialogueTrigger>();
                typeof(DialogueTrigger).GetField(param.Name).SetValue(a,j);
                var m = param.Name;
            }
            else
            {

            }
        }
        return CFG;
    }

    public bool Save()
    {
        // this.stats.tmpOptions = new string[]{};
        string dialoguesDir = Application.dataPath+"/Saves/"+this.name;
        string[] a = JsonUtility.ToJson(this.stats, true).Split('\n');
        File.WriteAllText(dialoguesDir, JsonUtility.ToJson(this.stats, true));
        return true;
    }
}
