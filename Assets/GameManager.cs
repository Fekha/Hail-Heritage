using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    public static DirectionButtons directions;
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
    public static Directions cameFrom = Directions.West;
    public GameObject player;
    public GameObject[] spawns;
    public static List<Directions> NextDirections = new List<Directions>();
    public static List<Directions> BackDirections = new List<Directions>();
    public static List<int> NextEastScenes = new List<int>();
    public static List<int> NextWestScenes = new List<int>();
    public static List<int> NextNorthScenes = new List<int>();
    public static List<int> NextSouthScenes = new List<int>();
    public static List<int> NextInScenes = new List<int>();
    public static List<int> NextOutScenes = new List<int>();

    private void OnLevelWasLoaded(int level)
    {
        //spawns = GameObject.FindGameObjectsWithTag("Respawn");
        //switch (spawnLocation)
        //{
        //    case 0:
        //        player.transform.position = spawns.OrderByDescending(x => x.transform.position.x).FirstOrDefault().transform.position;
        //        break;
        //    case 1:
        //        player.transform.position = spawns.OrderByDescending(x => x.transform.position.x).LastOrDefault().transform.position;
        //        break;
        //    case 2:
        //        player.transform.position = spawns.FirstOrDefault(x => x.name == "GoIn1").transform.position;
        //        break;
        //    default:
        //        player.transform.position = spawns.OrderByDescending(x => x.transform.position.x).FirstOrDefault().transform.position;
        //        break;
        //}
        //var toSpawn = spawns[spawnLocation].transform.position;
        //toSpawn.z = 0;
        //player.transform.position = toSpawn;
    }

    public static void SetNextLevel(int level, Directions dir)
    {
        switch (dir)
        {
            case Directions.North:
                NextNorthScenes.Add(level);
                break;
            case Directions.East:
                NextEastScenes.Add(level);
                break;
            case Directions.South:
                NextSouthScenes.Add(level);
                break;
            case Directions.West:
                NextWestScenes.Add(level);
                break;
            case Directions.In:
                NextInScenes.Add(level);
                break;
            case Directions.Out:
                NextOutScenes.Add(level);
                break;
            default:
                break;
        }
    }
    public static int GetNextLevel(Directions to)
    {
        int toReturn = 0;
        switch (to)
        {
            case Directions.North:
                toReturn = NextNorthScenes[0];
                NextSouthScenes.Add(NextNorthScenes[0]);
                NextNorthScenes.Remove(NextNorthScenes[0]);
                break;
            case Directions.East:
                toReturn = NextEastScenes[0];
                NextWestScenes.Add(NextEastScenes[0]);
                NextEastScenes.Remove(NextEastScenes[0]);
                break;
            case Directions.South:
                toReturn = NextSouthScenes[0];
                NextNorthScenes.Add(NextSouthScenes[0]);
                NextSouthScenes.Remove(NextSouthScenes[0]);
                break;
            case Directions.West:
                toReturn = NextWestScenes[0];
                NextEastScenes.Add(NextWestScenes[0]);
                NextWestScenes.Remove(NextWestScenes[0]);
                break;
            case Directions.In:
                toReturn = NextInScenes[0];
                NextOutScenes.Add(NextInScenes[0]);
                NextInScenes.Remove(NextInScenes[0]);
                break;
            case Directions.Out:
                toReturn = NextOutScenes[0];
                NextInScenes.Add(NextOutScenes[0]);
                NextOutScenes.Remove(NextOutScenes[0]);
                break;
            default:
                break;
        }
        return toReturn;
    }
}
