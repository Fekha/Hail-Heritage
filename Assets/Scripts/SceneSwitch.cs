using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Assets.Scripts.Enums;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class SceneSwitch : MonoBehaviour
{
    // If next scene is 0 that means there is no scene to go to, 
    //the exit is where to spawn 0 = gowest 1 = goeast 2=goin
    public int NextEastScene = 0;
    public int NextWestScene = 0;
    public int NextNorthScene = 0;
    public int NextSouthScene = 0;
    public int EnterScene = 0;
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
                if (NextEastScene != 0 && GameManager.NextEastScenes.Any())
                {
                    DirectionButtons.instance.GoEastButton.SetActive(true);
                }
                if (NextWestScene != 0 && GameManager.NextWestScenes.Any())
                {
                    DirectionButtons.instance.GoWestButton.SetActive(true);
                }
                if (NextNorthScene != 0 && GameManager.NextNorthScenes.Any())
                {
                    DirectionButtons.instance.GoNorthButton.SetActive(true);
                }
                if (NextSouthScene != 0 && GameManager.NextSouthScenes.Any())
                {
                    DirectionButtons.instance.GoSouthButton.SetActive(true);
                }
                if (EnterScene != 0 && GameManager.NextInScenes.Any())
                {
                    DirectionButtons.instance.GoInButton.SetActive(true);
                }
            } 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isShowing = false;
        GameObject.Find("GameText").GetComponent<TextMeshProUGUI>().text = string.Empty;
        DirectionButtons.instance.GoEastButton.SetActive(false);
        DirectionButtons.instance.GoWestButton.SetActive(false);
        DirectionButtons.instance.GoNorthButton.SetActive(false);
        DirectionButtons.instance.GoSouthButton.SetActive(false);
        DirectionButtons.instance.GoInButton.SetActive(false);
        
    }
    public void OnLevelWasLoaded(int level)
    {
        GameObject.Find("GameText").GetComponent<TextMeshProUGUI>().text = string.Empty;
        DirectionButtons.instance.GoEastButton.SetActive(false);
        DirectionButtons.instance.GoWestButton.SetActive(false);
        DirectionButtons.instance.GoNorthButton.SetActive(false);
        DirectionButtons.instance.GoSouthButton.SetActive(false);
        DirectionButtons.instance.GoInButton.SetActive(false);
        isSwitching = false;
    }
}
