using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {
    public SpawnPoint parentSpawn;
    private GameObject _recepieBook;

    private void Awake () {
        _recepieBook = GameObject.FindGameObjectsWithTag ("recepieBook") [0];
        _recepieBook.GetComponent<RezeptBuch> ().AddTag (gameObject);
    }

    public void RemoveTag () {
        _recepieBook.GetComponent<RezeptBuch> ().RemoveTag (gameObject);
    }

    void OnDestroy () {
        if (_recepieBook != null) {
            RemoveTag ();
        }

        parentSpawn.occupied = false;
    }
}