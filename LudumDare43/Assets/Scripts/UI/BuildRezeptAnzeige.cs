using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildRezeptAnzeige : MonoBehaviour {

    public GameObject pfeil;
    public GameObject panel;
    public GameObject container_Gott1;

    public List<GameObject> zutaten_prefabs;
    public List<GameObject> belohnung_prefabs;

    public GameObject rezeptBuch;

    private List<GameObject> panels_left;
    private string currentReward;

    void Start () {
        //initialer Spawn
        SpawnPointManager manager = FindObjectOfType<SpawnPointManager> ();
        manager.SpawnWave ("AlpacaSpawn", 5);
        manager.SpawnWave ("SheepSpawn", 5);
        manager.SpawnWave ("TreeSpawn", 5);
        manager.SpawnWave ("HutSpawn", 5);
        manager.SpawnWave ("ChickenSpawn", 5);

        panels_left = new List<GameObject> ();

        createNewRezept ();
    }

    public void createNewRezept () {
        var panel1Inst = Instantiate (panel) as GameObject;
        panels_left.Add (panel1Inst);
        panel1Inst.transform.SetParent (container_Gott1.transform, false);
        // GameObject rezeptGO = rezeptBuch.GetComponent<RezeptBuch> ().getRandomRezept ();

        createIcons (panel1Inst, rezeptBuch.GetComponent<RezeptBuch> ().createRandomRezept ());

    }

    private void createIcons (GameObject panel, Rezept rezept) {

        //Zutaten
        GameObject zutatImage = null;

        foreach (GameObject zutat in rezept.zutaten) {
            foreach (GameObject prefab in zutaten_prefabs) {
                if (zutat.tag.Equals (prefab.tag)) {
                    zutatImage = Instantiate (prefab) as GameObject;
                    break;
                }
            }
            if (zutatImage != null) {
                zutatImage.transform.SetParent (panel.transform, false);
            }
        }

        ///pfeil
        var pfeilImage = Instantiate (pfeil) as GameObject;
        pfeilImage.transform.SetParent (panel.transform, false);

        //belohnung
        GameObject belohnungImage = null;

        foreach (GameObject prefab in belohnung_prefabs) {
            if (rezept.belohnung.tag.Equals (prefab.tag)) {
                belohnungImage = Instantiate (prefab) as GameObject;
                currentReward = prefab.tag;
                break;
            }
        }
        if (zutatImage != null) {
            belohnungImage.transform.SetParent (panel.transform, false);
        }
    }

    public void receiveGift (string type) {
        foreach (Transform child in panels_left[0].transform) {
            if (child.tag == type) {

                SVGImage image = child.GetComponent<SVGImage> ();
                if (image != null) {
                    var tempColor = image.color;
                    if (tempColor.a != 0.2f) {
                        tempColor.a = 0.2f;
                        image.color = tempColor;
                        break;
                    } else {
                        continue;
                    }
                }

                Image image2 = child.GetComponent<Image> ();
                if (image2 != null) {
                    var tempColor = image2.color;
                    if (tempColor.a != 0.2f) {
                        tempColor.a = 0.2f;
                        image2.color = tempColor;
                        break;
                    } else {
                        continue;
                    }
                }

            }
        }

        checkIfRezeptIsDone ();

    }

    private void checkIfRezeptIsDone () {

        foreach (Transform child in panels_left[0].transform) {
            //wenn der Pfeil erreicht ist, sind die Zutaten alle erledigt
            if (child.tag == "Pfeil") {
                finishRezept ();
                return;
            }

            Image image = child.GetComponent<Image> ();
            if (image != null) {
                var tempColor = image.color;
                if (tempColor.a != 0.2f) {
                    return;

                }
            }

            SVGImage image2 = child.GetComponent<SVGImage> ();
            if (image2 != null) {
                var tempColor = image2.color;
                if (tempColor.a != 0.2f) {
                    return;

                }
            }

        }

    }

    private void finishRezept () {
        removeRezeptePanel ();
        sendReward ();
        createNewRezept ();
    }

    private void sendReward () {
        SpawnPointManager manager = FindObjectOfType<SpawnPointManager> ();
        if (currentReward.Equals ("Sonne")) {
            Debug.Log ("SPAWN BELOHNUNG SONNE");
            GameObject animation = GameObject.FindWithTag ("effectSun");
            animation.GetComponent<WeatherEffects> ().activateWeather ();
            manager.SpawnWave ("TreeSpawn", 1);
            manager.SpawnWave ("AlpacaSpawn", 2);
            manager.SpawnWave ("SheepSpawn", 1);
        } else if (currentReward.Equals ("Rain")) {
            Debug.Log ("SPAWN BELOHNUNG Rain");
            GameObject animation = GameObject.FindWithTag ("effectRain");
            animation.GetComponent<WeatherEffects> ().activateWeather ();
            manager.SpawnWave ("TreeSpawn", 3);
        } else if (currentReward.Equals ("Fog")) {
            Debug.Log ("SPAWN BELOHNUNG Fog");
            GameObject animation = GameObject.FindWithTag ("effectMist");
            animation.GetComponent<WeatherEffects> ().activateWeather ();
            manager.SpawnWave ("SheepSpawn", 2);
            manager.SpawnWave ("ChickenSpawn", 1);
        } else if (currentReward.Equals ("Fruchtbarkeit")) {
            Debug.Log ("SPAWN BELOHNUNG Fruchtbarkeit");
            GameObject animation = GameObject.FindWithTag ("effectLove");
            animation.GetComponent<WeatherEffects> ().activateWeather ();
            manager.SpawnWave ("HutSpawn", 1);
            manager.SpawnWave ("ChickenSpawn", 2);
        } else if (currentReward.Equals ("Fruit")) {
            Debug.Log ("SPAWN BELOHNUNG FRUIT");
            GameObject animation = GameObject.FindWithTag ("effectFruit");
            animation.GetComponent<WeatherEffects> ().activateWeather ();
            manager.SpawnWave ("HutSpawn", 1);
            manager.SpawnWave ("ChickenSpawn", 2);
        }

    }

    private void removeRezeptePanel () {
        Destroy (container_Gott1.transform.GetChild (0).gameObject);
        panels_left.Clear ();
    }

}