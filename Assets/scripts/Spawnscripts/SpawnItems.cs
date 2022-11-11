using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour {

    public Transform[] SpawnPoints;
    public float spawnTime = 1.5f;

    public GameObject Coin;
    //public Gameobject[] Coin;

    //use this for initialization
    void Start ()
    {
        InvokeRepeating("SpawnCoin", spawnTime, spawnTime);
    }

    //Update is called once per frame
    void Update ()
    {

    }

    void SpawnCoin()
    {
        int spawnIndex = Random.Range(0, SpawnPoints.Length);

    
        Instantiate(Coin, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
    }

}
