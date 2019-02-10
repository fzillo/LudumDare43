using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RezeptBuch : MonoBehaviour {

    private List<GameObject> _tags = new List<GameObject> ();

    public void AddTag (GameObject tag) {
        _tags.Add (tag);
    }

    public void RemoveTag (GameObject tag) {
        _tags.Remove (tag);
    }

    public Rezept createRandomRezept () {
        BuildRezeptAnzeige rezeptAnzeige = FindObjectOfType<BuildRezeptAnzeige> ();
        List<GameObject> zutaten_prefabs = rezeptAnzeige.zutaten_prefabs;
        List<GameObject> belohnung_prefabs = rezeptAnzeige.belohnung_prefabs;

        List<int> randomNumbers = new List<int> ();
        while (randomNumbers.Count < 3) {
            int ran = Random.Range (0, zutaten_prefabs.Count);
            if (!randomNumbers.Contains (ran)) {
                randomNumbers.Add (ran);
            }
        }

        List<GameObject> zutaten = new List<GameObject> ();
        zutaten.Add (zutaten_prefabs[randomNumbers[0]]);
        zutaten.Add (zutaten_prefabs[randomNumbers[1]]);
        zutaten.Add (zutaten_prefabs[randomNumbers[2]]);

        Rezept rezept = new Rezept (belohnung_prefabs[Random.Range (0, belohnung_prefabs.Count)], zutaten);

        if (canRezeptBeFullfilled (rezept)) {
            return rezept;
        }

        return createRandomRezept ();

    }

    private bool canRezeptBeFullfilled (Rezept rezept) {

        foreach (GameObject zutat in rezept.zutaten) {
            GameObject[] objects = GameObject.FindGameObjectsWithTag (zutat.tag);
            if (objects.Length == 0) {
                return false;
            }

            //ausschliesen, dass er die UI elemente meint
            int countSpawnObjects = 0;
            foreach (GameObject go in objects) {
                if (go.GetComponent<SpawnObject> () != null) {
                    countSpawnObjects++;
                }
            }

            if (countSpawnObjects == 0) {
                return false;
            }

        }
        return true;
    }

}