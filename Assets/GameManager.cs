using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of GameManager found!");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
        Instantiate(player, new Vector3((float)-27.42, (float)1.8, 0), Quaternion.identity);
    }
    #endregion

    public static int spawnLocation = 0;
    public GameObject player;
    public GameObject[] spawns;
    
    private void OnLevelWasLoaded(int level)
    {
        spawns = GameObject.FindGameObjectsWithTag("Respawn");
        var toSpawn = spawns[spawnLocation].transform.position;
        toSpawn.z = 0;
        player.transform.position = toSpawn;
    }
}
