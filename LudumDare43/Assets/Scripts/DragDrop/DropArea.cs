using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        DragTransform dtrans = other.GetComponentInParent<DragTransform>();
        if(dtrans != null && !dtrans.dragging){
            other.gameObject.transform.position = dtrans.positionStart;
            other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }

    }
}
