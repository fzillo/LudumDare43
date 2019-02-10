using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drop : MonoBehaviour
{

    public Text gott1Text;
    public GameObject ui;

    private int count;
    void Start()
    {
        count = 0;
        gott1Text.text = "";

        SetCountText();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        DragTransform dtrans = other.GetComponentInParent<DragTransform>();
        if (dtrans != null && !dtrans.dragging)
        {
            // other.GetComponent<ResourceAttributes>().GetSpawnController().GetComponent<SpawnResource>().SubtractResources(1);

            ui.GetComponent<BuildRezeptAnzeige>().receiveGift(other.gameObject.tag);

            count += other.gameObject.GetComponent<ResourceAttributes>().ScoreValue;
            other.gameObject.GetComponent<SpawnObject>().RemoveTag();
            Destroy(other.gameObject);
            AudioManager.instance.Play("Plop");
            SetCountText();
        }
    }

    void SetCountText()
    {
        gott1Text.text = "Score: " + count.ToString();

    }
}
