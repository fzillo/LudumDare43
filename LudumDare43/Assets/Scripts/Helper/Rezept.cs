using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rezept {

    public GameObject belohnung;
    public List<GameObject> zutaten;

    public Rezept (GameObject belohnung, List<GameObject> zutaten) {
        this.belohnung = belohnung;
        this.zutaten = zutaten;
    }

}