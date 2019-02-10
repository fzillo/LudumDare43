using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnna : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("You Clicked Annas Sound!");
        AudioManager.instance.Play("Click");
    }
}
