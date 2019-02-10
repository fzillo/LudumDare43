using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour {
    public List<SpawnPoint> activeSpawnPoints = new List<SpawnPoint> ();

    public bool randomSpawnActive = true;
    public int spawnDelayMin = 1;
    public int spawnDelayMax = 5;

    IDictionary<string, GameObject[]> allSpawnPointsGODict = new Dictionary<string, GameObject[]> ();

    public void Awake () {

        foreach (SpawnPoint objectToSpawn in activeSpawnPoints) {
            Debug.Log ("SpawnPoints to add: " + objectToSpawn.tag);

            GameObject[] goArr = GameObject.FindGameObjectsWithTag (objectToSpawn.tag);
            if (goArr != null && goArr.Length > 0) {
                Debug.Log ("SpawnPoints added to SpawnPointManager: " + objectToSpawn.tag + " count: " + goArr.Length);
                allSpawnPointsGODict.Add (objectToSpawn.tag, goArr);
            }
        }

    }

    public void Start () {
        if (randomSpawnActive) {
            StartCoroutine (SpawnRandomly ());
        }
    }

    IEnumerator SpawnRandomly () {

        while (true) {
            int spawnDelay = Random.Range (spawnDelayMin, spawnDelayMax);
            yield return new WaitForSeconds (spawnDelay);

            int spawnEntity = Random.Range (1, 5);

            switch (spawnEntity) {
                case 1:
                    SpawnWave ("TreeSpawn", 1);
                    break;
                case 2:
                    SpawnWave ("AlpacaSpawn", 1);
                    break;
                case 3:
                    SpawnWave ("SheepSpawn", 1);
                    break;
                case 4:
                    SpawnWave ("ChickenSpawn", 1);
                    break;
                case 5:
                    SpawnWave ("HutSpawn", 1);
                    break;
                default:
                    break;
            }
        }

        yield break;
    }

    public void SpawnWave (string tagSpawnPoint, int count) {
        Debug.Log ("SpawnPoint " + tagSpawnPoint + " count " + count);

        GameObject[] currentSpawnPointGOArray;
        allSpawnPointsGODict.TryGetValue (tagSpawnPoint, out currentSpawnPointGOArray);

        if (currentSpawnPointGOArray != null && currentSpawnPointGOArray.Length > 0) {
            StartCoroutine (activateSpawnPoints (currentSpawnPointGOArray, count));
        }

    }

    public void SpawnWave (SpawnPoint spawnPoint, int count) {
        SpawnWave (spawnPoint.tag, count);
    }

    IEnumerator activateSpawnPoints (GameObject[] currentSpawnPointGOArray, int count) {
        int[] indexSpawnPosition = getRandomNumbers (count, currentSpawnPointGOArray.Length);

        Debug.Log ("indexSpawnPosition Len " + indexSpawnPosition.Length);

        int spawnAttemptCount = 1;

        foreach (var i in indexSpawnPosition) {
            Debug.Log ("indexSpawnPosition " + i);

            GameObject spawnPointGO = currentSpawnPointGOArray[i];
            SpawnPoint spawn = spawnPointGO.GetComponent<SpawnPoint> ();

            if (spawn != null) {
                Debug.Log ("Spawning " + spawn + " Index: " + i + " SpawnedCount: " + spawnAttemptCount + "/" + indexSpawnPosition.Length);
                spawn.SpawnEntity ();
                spawnAttemptCount++;
            }
        }
        yield break;
    }

    private int[] getRandomNumbers (int n, int max_value) {
        int[] numbers = new int[n];

        for (int i = 0; i < n; i++) {
            numbers[i] = Random.Range (0, max_value);
        }

        return numbers;
    }
}