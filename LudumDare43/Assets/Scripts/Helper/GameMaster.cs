using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnPointManager manager = FindObjectOfType<SpawnPointManager>();
        manager.SpawnWave("AlpacaSpawn", 5);
        manager.SpawnWave("SheepSpawn", 5);
        manager.SpawnWave("TreeSpawn", 5);
        manager.SpawnWave("HutSpawn", 5);
        manager.SpawnWave("ChickenSpawn", 5);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
