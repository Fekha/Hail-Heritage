using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetDirection : MonoBehaviour
{
    public Directions dir;

    public void OnDirectionClick()
    {
        var nextScene = GameManager.GetNextLevel(dir);
        PlayerControl.instance.currentScene = nextScene;
        //1 = right, 0 = left
        GameManager.spawnLocation = GameManager.cameFrom == dir ? 1 : 0;
        PlayerControl.instance.sceneSpawnLocation = GameManager.spawnLocation;
        GameManager.cameFrom = dir;
        SceneManager.LoadScene(nextScene);
    } 
}
