using System;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance { get; private set; }

    [SerializeField] private Pool pool;
    private Dictionary<string, Queue<GameObject>> poolsDictionary = new Dictionary<string, Queue<GameObject>>();

    [SerializeField] private Transform targetPoint;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InstantiateObjects();
    }

    private void InstantiateObjects()
    {
        Queue<GameObject> objectPool = new Queue<GameObject>();

        for (int i = 0; i < pool.size; i++)
        {
            GameObject obj = Instantiate(pool.prefab);
            obj.SetActive(false);
            obj.GetComponent<Cube>().AddTarget(targetPoint);
            objectPool.Enqueue(obj);
        }

        poolsDictionary.Add(pool.tag, objectPool);
    }

    public GameObject SpawnFromPool(Vector3 position, Quaternion rotation)
    {
        GameObject objectToSpawn = poolsDictionary[pool.tag].Dequeue();

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);

        poolsDictionary[pool.tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}

[System.Serializable]
public class Pool
{
    public string tag;
    public GameObject prefab;
    public int size;
}
