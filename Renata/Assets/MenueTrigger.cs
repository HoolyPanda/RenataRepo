using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenueTrigger : MonoBehaviour
{
    public string dialogue;
    public GameObject targetGO;
    public GameObject statsCanvas;
    //public GameObject statsPanel;
    public bool isStatsPanelEnabled = false;
    void Start()
    {
        if (statsCanvas == null)
        {
            Debug.LogError("No stats object");
        }
    }
    public void OnMouseUp()
    {
/*        try
        {
            statsCanvas = GameObject.FindGameObjectWithTag("Stats").GetComponent<Canvas>();

             
        }
        catch (System.Exception)
        {
            
        }*/

        if (statsCanvas != null && !isStatsPanelEnabled)
        {
            statsCanvas.SetActive(true);
            isStatsPanelEnabled = true;
            // DM.NPCGO = targetGO;
        }
        
    }
    public void DisableStatsCanvas()
    {
        statsCanvas.SetActive(false);
        isStatsPanelEnabled = false;
        
    }
}
