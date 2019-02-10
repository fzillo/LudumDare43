using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.U2D.TriangleNet;

public class SpawnResource : MonoBehaviour
{
    public GameObject Resource;
    private int _resourceCount;

    private void Awake()
    {
        _resourceCount = Resource.GetComponent<ResourceAttributes>().StartingCount;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        int supplyAddition = Resource.GetComponent<ResourceAttributes>().ResupplyAmountAddition;
        int maxCount = Resource.GetComponent<ResourceAttributes>().MaxCount;
        
        while (true)
        {
            while (_resourceCount < maxCount)
            {
                for (int i = 0; i < supplyAddition; i++)
                {
                    Bounds spawnArea = gameObject.GetComponent<MeshRenderer>().bounds;
                    float x = Random.Range(spawnArea.min.x, spawnArea.max.x);
                    float y = Random.Range(spawnArea.min.y, spawnArea.max.y);
                    Instantiate(Resource, new Vector3(x, y, 0), Resource.transform.rotation).GetComponent<ResourceAttributes>().SetSpawnController(gameObject);
                    ++_resourceCount;
                    Debug.Log("Resource Created: " + _resourceCount);
                }
            }
            
            yield return new WaitForSeconds(Resource.GetComponent<ResourceAttributes>().ResupplyWait);
        }
    }

    public void SubtractResources(int amount)
    {
        _resourceCount =- amount;
        Debug.Log("Resource Count after destroy: " + _resourceCount);
    }
}
