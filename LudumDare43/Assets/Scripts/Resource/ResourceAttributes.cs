using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceAttributes : MonoBehaviour
{
    public float ResupplyWait;
    public int ResupplyAmountAddition;
    public int MaxCount;
    public int StartingCount;
    public int ScoreValue;
    
    private GameObject _spawnController = null;

    public void SetSpawnController(GameObject spawnController)
    {
        _spawnController = spawnController;
    }
    
    public GameObject GetSpawnController()
    {
        return _spawnController;
    }

    private void Awake()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
