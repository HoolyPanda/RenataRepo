using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Config : MonoBehaviour
{
    
    public class config
    {
        public bool isLastPhrase = false;
        public string[] conditionstrings = new string[] {};
        public string[] preStatChanges = new string[] {};
        public string[] postStatChanges = new string[] {};
        public string[] exclusiveConditions = new string[] {};
        public string[] inventoryAdd = new string[] {};
        public string[] inventoryAddTmp = new string[] {};
        public string[] targetSpriteToLoad = new string[] {};
        public string[] changeTargetDialogue = new string[] {};
        // public string[] changeTargetDialogue = new string[] {};
        public string SpriteAssetToLoad = "";
    }
    [SerializeField]
    public config CFG;
    void Start()
    {
        // CFG = new config();
        // CFG.conditionstrings = new string[]{"Ответить грубо if revolt > 2", "Ответить вежливо if words > 1"};
        // CFG.preStatChanges = new string[]{"change apathyAgressionMood +1"};
        // CFG.postStatChanges = new string[]{"change silenceWordsMood -1"};
        // CFG.inventoryAdd = new string[]{"add test"};
 
    }
    void Update()
    {
        
    }
    public config LoadConfig(string loadPath)
    {
        string dialoguesDir = Application.dataPath+"/Resources/"+loadPath;
        CFG  = JsonUtility.FromJson<config>(File.ReadAllText(dialoguesDir));
        return CFG;
    }
    public bool SaveConfig(string savePath)
    {
        string dialoguesDir = Application.dataPath+"/Resources/"+savePath;
        string[] a = JsonUtility.ToJson(CFG, true).Split('\n');
        File.WriteAllText(dialoguesDir, JsonUtility.ToJson(CFG, true));
        return true;
    }
}
