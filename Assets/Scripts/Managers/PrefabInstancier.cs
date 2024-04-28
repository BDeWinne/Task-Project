using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInstancier : MonoBehaviour
{
    public static PrefabInstancier Instance;
    [SerializeField] GameObject[] startingPrefabs;
    [SerializeField] GameObject squarePrefab;
    [SerializeField] float squareDelay;
     private float nextSpawnTime;

    [SerializeField] float minRange, maxRange;
    [SerializeField] float yPosSpawn;

    void Awake()
    {
        if(Instance == null){
            Instance = this;
        }else{
            Destroy(this);
        }
    }

    void Start()
    {
        for (int i = 0; i < startingPrefabs.Length; i++)
        {
            Instantiate(startingPrefabs[i]);
        }
    }

    void Update()
    {
        SqaureSpawner();
    }


    void SqaureSpawner(){
        nextSpawnTime -= Time.deltaTime;
        if (nextSpawnTime <= 0)
        {
            SpawnSquare(); 
            nextSpawnTime = squareDelay;
        }
    }
    void SpawnSquare(){
        float randomX = Random.Range(minRange, maxRange);
        Vector2 spawnPosition = new Vector2(randomX, yPosSpawn);

        GameObject newSquare = Instantiate(squarePrefab, spawnPosition, Quaternion.identity);
    }
}
