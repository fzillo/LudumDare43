using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{

    public bool dragging = false;
    private float distance;
    public Vector2 positionStart;



    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        positionStart = this.gameObject.transform.position;



        if (gameObject.tag.Equals("AlpacaBrown")
            || gameObject.tag.Equals("AlpacaWhite")
            || gameObject.tag.Equals("AlpacaGrey")
        )
        {
            AudioManager.instance.Play("Alpaca");
        }
        else if (gameObject.tag.Equals("TreeGreen")
          || gameObject.tag.Equals("TreeBlue")
          || gameObject.tag.Equals("TreePink")
      )
        {
            AudioManager.instance.Play("Tree");
        }
        else if (gameObject.tag.Equals("SheepWhite")
          || gameObject.tag.Equals("SheepGrey")
          || gameObject.tag.Equals("SheepYellow")
      )
        {
            AudioManager.instance.Play("Sheep");
        }
        else if (gameObject.tag.Equals("HutPink")
          || gameObject.tag.Equals("HutYellow")
          || gameObject.tag.Equals("HutBrown")
      )
        {
            AudioManager.instance.Play("Hut");
        }
        else if (gameObject.tag.Equals("ChickenWhite")
         || gameObject.tag.Equals("ChickenBrown")
         || gameObject.tag.Equals("ChickenBlue")
     )
        {
            AudioManager.instance.Play("Chicken");
        }


    }

    void OnMouseUp()
    {
        dragging = false;
    }


    void FixedUpdate()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x, rayPoint.y, transform.position.z);
        }
    }

    private void OnDestroy()
    {
        Debug.Log(gameObject.tag + " sacrificed!");
    }
}