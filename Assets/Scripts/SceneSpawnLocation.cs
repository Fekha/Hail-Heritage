using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneSpawnLocation : MonoBehaviour
{
    private PlayerControl player;
    private GameObject[] spawns;
    void Start()
    {
        player = PlayerControl.instance;
        spawns = GameObject.FindGameObjectsWithTag("Respawn");
        switch (player.currentScene)
        {
            case 1:
                switch (player.sceneSpawnLocation)
                {
                    case 0:
                        player.transform.position = spawns.FirstOrDefault(x => x.name == "GoWest").transform.position;
                        break;
                    case 1:
                        player.transform.position = spawns.FirstOrDefault(x => x.name == "GoEast").transform.position;
                        break;
                    case 2:
                        player.transform.position = spawns.FirstOrDefault(x => x.name == "GoIn1").transform.position;
                        break;
                    default:
                        player.transform.position = spawns[0].transform.position;
                        break;
                }
                break;
            case 2:
                switch (player.sceneSpawnLocation)
                {
                    case 0:
                        player.transform.position = spawns.FirstOrDefault(x => x.name == "GoWest").transform.position;
                        break;
                    default:
                        player.transform.position = spawns[0].transform.position;
                        break;
                }
                break;
            case 3:
                switch (player.sceneSpawnLocation)
                {
                    case 0:
                        player.transform.position = spawns.FirstOrDefault(x => x.name == "GoIn1").transform.position;
                        break;
                    default:
                        player.transform.position = spawns[0].transform.position;
                        break;
                }
                break;
           
            default:
                player.transform.position = spawns[0].transform.position; ;
                break;
        }
       
    }
}
