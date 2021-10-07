using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager: MonoBehaviour
{   public string sceneName;
    public GameObject player;

    public void LoadSceneByName()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadSceneByName(string name)
    {
        void save(Player player)
        {
            if (player != null)
            {
                player.Save();
            }
        }
        GameObject[] p = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject item in p)
        {
            save(item.GetComponent<Player>());
        }
        p = GameObject.FindGameObjectsWithTag("NPC");
        foreach (GameObject item in p)
        {
            save(item.GetComponent<Player>());
        }

        SceneManager.LoadScene(name);
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}