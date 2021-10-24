using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject parentPanel;
    public GameObject player;
    public UnityEngine.UI.Button button;
    void Start()
    {
        if (player == null)        
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // TODO might be slow
        if(player.GetComponent<Player>().GetStatByName("skillPoints") == 0)
        {
            button.GetComponent<UnityEngine.UI.Image>().enabled = false;
        }
        else
        {
            button.GetComponent<UnityEngine.UI.Image>().enabled = true;

        }
    }
    public void LearnSkill()
    {
        var a = parentPanel.name;
        player.GetComponent<Player>().LevelUpSkillByName(a);
        var b = 0;
    }
}
