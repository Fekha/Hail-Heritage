using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public Item itemGive;
    public Item itemSell;
    private bool isSelling = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.Find("GameText").GetComponent<TextMeshProUGUI>().text = "Press L to Sell";
            if (Input.GetKeyUp("l"))
            {
                if (Inventory.instance.Find(itemGive))
                {
                    isSelling = true;
                    Inventory.instance.Remove(itemGive);
                    Inventory.instance.Add(itemSell);
                    isSelling = false;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Find("GameText").GetComponent<TextMeshProUGUI>().text = "";
    }
}
