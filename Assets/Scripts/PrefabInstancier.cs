using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInstancier : MonoBehaviour
{
    public static PrefabInstancier Instance;
    [SerializeField] GameObject[] startingPrefabs;

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
            InstantiatePrefab(startingPrefabs[i]);
        }
    }

    public void InstantiatePrefab(GameObject prefab){
        Instantiate(prefab);
    }
}
