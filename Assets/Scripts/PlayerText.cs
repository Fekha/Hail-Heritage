using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerText : MonoBehaviour
{
    public string text = "";
    private bool isShowing = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isShowing)
            {
                isShowing = true;
                GameObject.Find("GameText").GetComponent<TextMeshProUGUI>().text += text;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Find("GameText").GetComponent<TextMeshProUGUI>().text = "";
        isShowing = false;
    }
}
