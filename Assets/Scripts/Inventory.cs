using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangeCallback;
    public int space;
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);
            if(onItemChangeCallback != null)
                onItemChangeCallback.Invoke();
        }
        return true;
    }
    public bool Find(Item item)
    {
        if (items.Contains(item))
        {
            return true;
        }
        return false;
    }
    public Item Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangeCallback != null)
            onItemChangeCallback.Invoke();
        return item;
    }
}
