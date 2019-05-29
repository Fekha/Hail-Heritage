using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int NextEastScene = 0;
    public int NextWestScene = 0;
    public int NextNorthScene = 0;
    public int NextSouthScene = 0;
    public int EnterScene = 0;
    public int EastExit = 0;
    public int WestExit = 0;
    public int NorthExit = 0;
    public int SouthExit = 0;
    public int Exit = 0;
    private bool isSwitching = false;
    private bool isShowing = false;
    PlayerControl Player;
    public string LeavePhrase = "Enter";
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player = collision.gameObject.GetComponent<PlayerControl>();
            if (!isShowing)
            {
                isShowing = true;
                if (NextEastScene != 0)
                {
                    GameObject.Find("GameText").GetComponent<TextMeshProUGUI>().text += "Press E to go East \n";
                }
                if (NextWestScene != 0)
                {
                    GameObject.Find("GameText").GetComponent<TextMeshProUGUI>().text += "Press W to go West \n";
                }
                if (NextNorthScene != 0)
                {
                    GameObject.Find("GameText").GetComponent<TextMeshProUGUI>().text += "Press N to go North \n";
                }
                if (NextSouthScene != 0)
                {
                    GameObject.Find("GameText").GetComponent<TextMeshProUGUI>().text += "Press S to go South \n";
                }
                if (EnterScene != 0)
                {
                    GameObject.Find("GameText").GetComponent<TextMeshProUGUI>().text += "Press E to " + LeavePhrase;
                }
            }
            if (Input.GetKeyDown("e") && NextEastScene != 0 && !isSwitching)
            {
                isSwitching = true;
                PlayerControl.instance.currentScene = NextEastScene;
                PlayerControl.instance.sceneSpawnLocation = EastExit;
                SceneManager.LoadScene(NextEastScene);
            }
            if (Input.GetKeyDown("w") && NextWestScene != 0 && !isSwitching)
            {
                isSwitching = true;
                PlayerControl.instance.currentScene = NextWestScene;
                PlayerControl.instance.sceneSpawnLocation = WestExit;
                SceneManager.LoadScene(NextWestScene);
            }
            if (Input.GetKeyDown("n") && NextNorthScene != 0 && !isSwitching)
            {
                isSwitching = true;
                PlayerControl.instance.currentScene = NextNorthScene;
                PlayerControl.instance.sceneSpawnLocation = NorthExit;
                SceneManager.LoadScene(NextNorthScene);
            }
            if (Input.GetKeyDown("s") && NextSouthScene != 0 && !isSwitching)
            {
                isSwitching = true;
                PlayerControl.instance.currentScene = NextSouthScene;
                PlayerControl.instance.sceneSpawnLocation = SouthExit;
                SceneManager.LoadScene(NextSouthScene);
            }
            if (Input.GetKeyDown("e") && EnterScene != 0 && NextEastScene == 0 && !isSwitching)
            {
                isSwitching = true;
                PlayerControl.instance.currentScene = EnterScene;
                PlayerControl.instance.sceneSpawnLocation = Exit;
                SceneManager.LoadScene(EnterScene);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Find("GameText").GetComponent<TextMeshProUGUI>().text = "";
        isShowing = false;
    }
    public void OnLevelWasLoaded(int level)
    {
        GameObject.Find("GameText").GetComponent<TextMeshProUGUI>().text = "";
        isSwitching = false;
    }
}
