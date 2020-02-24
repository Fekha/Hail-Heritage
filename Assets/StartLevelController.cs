using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.SetNextLevel(2, Assets.Scripts.Enums.Directions.East);
    }
}
