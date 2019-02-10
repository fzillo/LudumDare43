using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform[] entitiesToSpawn;

    /*
    [Range(0.1f, 1)]
    public float modifyMultiplicatorMin;
    [Range(1, 2f)]
    public float modifyMultiplicatorMax;
    */
    
    public bool occupied = false;

    public void SpawnEntity()
    {
        if (!occupied)
        {
            int randomIndex = Random.Range(0, entitiesToSpawn.Length);
            //float sizeModifier = Random.Range(modifyMultiplicatorMin, modifyMultiplicatorMax);

            Debug.Log(randomIndex);

            Transform entityToSpawn = entitiesToSpawn[randomIndex];

            //entityToSpawn.localScale = new Vector3(0.3f, 0.3f, 0.3f);

            //Transform spawnPosition = this.gameObject.transform;
            var spawnedEntity = Instantiate(entityToSpawn, transform.position, transform.rotation);
            if (spawnedEntity != null)
            {
                SpawnObject spawnObj = spawnedEntity.GetComponent<SpawnObject>();
                if (spawnObj != null)
                {
                    spawnObj.parentSpawn = this;
                    occupied = true;
                }
            }


        }
    }
}
