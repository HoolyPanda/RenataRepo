using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject parentPanel;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LearnSkill()
    {
        var a = parentPanel.name;
        player.GetComponent<Player>().LevelUpSkillByName(a);
        var b = 0;
    }
}
