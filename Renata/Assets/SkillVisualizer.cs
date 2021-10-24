using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillVisualizer : MonoBehaviour
{
    public GameObject parentPanel;
    public GameObject player;
    
    private string skillName;
    private float skillLevel = -1;
    private UnityEngine.UI.Image[] images;
    void Start()
    {
        skillName = parentPanel.name;
        images = this.gameObject.GetComponentsInChildren<UnityEngine.UI.Image>();
        // if (player.GetComponent<Player>().stats != null)
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        // {   
        skillLevel = player.GetComponent<Player>().GetStatByName(skillName);
        for (int i = 1; i-1 <= 3; i++)
        {
            if (i-1 < skillLevel)
            {
                images[i].sprite = Resources.Load<Sprite>(string.Format("Sprites/SkillLevelFull"));
            }
            else
            {
                images[i].sprite = Resources.Load<Sprite>(string.Format("Sprites/SkillLevelEmpty"));
            }
        }
        // }
    }

    void Update()
    {
        Player a = player.GetComponent<Player>();
        var mm = a.GetStatByName(skillName);
        if (skillLevel != a.GetStatByName(skillName))
        {
            skillLevel = a.GetStatByName(skillName);
            for (int i = 1; i-1 <= 3; i++)
            {
                if (i-1 < skillLevel)
                {
                    images[i].sprite = Resources.Load<Sprite>(string.Format("Sprites/SkillLevelFull"));
                }
                else
                {
                    images[i].sprite = Resources.Load<Sprite>(string.Format("Sprites/SkillLevelEmpty"));
                }
            }
        }
        
    }
}
