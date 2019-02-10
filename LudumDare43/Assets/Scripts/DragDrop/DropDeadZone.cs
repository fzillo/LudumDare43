using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDeadZone : MonoBehaviour {
    void OnTriggerEnter2D (Collider2D other) {
        DragTransform dtrans = other.GetComponentInParent<DragTransform> ();
        if (dtrans != null && !dtrans.dragging) {
            other.gameObject.GetComponent<SpawnObject> ().RemoveTag ();
            Destroy (other.gameObject);
        }
    }
}