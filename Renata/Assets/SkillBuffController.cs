using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBuffController : MonoBehaviour
{
    public GameObject parentPanel;
    public GameObject player;
    private string skillName;
    private float prevBSkillVal = 0;
    private float prevDSkillVal = 0;
    private UnityEngine.UI.Image[] images;
    void Start()
    {
        skillName = parentPanel.name;
        images = this.gameObject.GetComponentsInChildren<UnityEngine.UI.Image>();
    }

    void Update()
    {
        Player a = player.GetComponent<Player>();
        string[] buffs = a.GetBuffs(skillName);
        string b = buffs[0];
        // float 
        if (a.GetComponent<Player>().GetStatForBuffsByName(a.GetComponent<Player>().GetBuffs(skillName)[0]) != prevBSkillVal || a.GetComponent<Player>().GetStatForBuffsByName(a.GetComponent<Player>().GetBuffs(skillName)[1]) != prevDSkillVal)
        {
            var mmm = a.GetComponent<Player>().GetStatForBuffsByName(a.GetComponent<Player>().GetBuffs(skillName)[1]);
            if (a.GetComponent<Player>().GetStatForBuffsByName(a.GetComponent<Player>().GetBuffs(skillName)[0]) > 0)
            {
                images[1].sprite = Resources.Load<Sprite>(string.Format("Sprites/SkillBuff"));
            }
            else if (a.GetComponent<Player>().GetStatForBuffsByName(a.GetComponent<Player>().GetBuffs(skillName)[1]) > 0)
            {
                images[1].sprite = Resources.Load<Sprite>(string.Format("Sprites/SkillDeBuff"));
            }
            else
            {
                images[1].sprite = Resources.Load<Sprite>(string.Format("Sprites/SkillLevelEmpty"));
            }
            prevBSkillVal = a.GetComponent<Player>().GetStatForBuffsByName(a.GetComponent<Player>().GetBuffs(skillName)[0]);
            prevDSkillVal = a.GetComponent<Player>().GetStatForBuffsByName(a.GetComponent<Player>().GetBuffs(skillName)[1]);
        }
        

    }
}
// dasdsadas
