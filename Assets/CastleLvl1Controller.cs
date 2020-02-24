using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleLvl1Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();
        var dir = (Assets.Scripts.Enums.Directions)rand.Next(0, 3);
        GameManager.SetNextLevel(rand.Next(4,5), dir);
        GameManager.SetNextLevel(rand.Next(4,5), dir);
    }
}
