using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public string dialogue;
    public GameObject targetGO;
    public Canvas statsCanvas;
    public GameObject statsPanel;
    public bool isStatsPanelEnabled = false;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnMouseUp()
    {
        try
        {
            statsCanvas = GameObject.FindGameObjectWithTag("Stats").GetComponent<Canvas>();

             
        }
        catch (System.Exception)
        {
            
        }
        if (statsCanvas != null && !isStatsPanelEnabled)
        {
            statsCanvas.enabled = true;
            isStatsPanelEnabled = true;
            // DM.NPCGO = targetGO;
        }
        
    }
    public void DisableStatsCanvas()
    {
        statsCanvas.enabled = false;
        isStatsPanelEnabled = false;
        
    }
}
