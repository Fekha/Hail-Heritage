using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirectionButtons : MonoBehaviour
{
    public GameObject GoEastButton;
    public GameObject GoWestButton;
    public GameObject GoNorthButton;
    public GameObject GoSouthButton;
    public GameObject GoInButton;

    #region Singleton
    public static DirectionButtons instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one direction panels found!");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    #endregion
}
