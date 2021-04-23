using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instancer_objectPooling : MonoBehaviour
{
    //brackeys object pooler was better than the one i made so i used this one :D
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    int size;
    public static instancer_objectPooling instance = null;

    public static instancer_objectPooling Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }

    [System.Serializable]
    public class pool
    {
        public string name;
        public GameObject obj;
        public int size;
    }

    [SerializeField]List<pool> pools;

    void Start()
    {
        
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.obj);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.name, objectPool);
        }
    }
    /// <summary>
    /// spawns enemies from and object pool
    /// </summary>
    /// <param name="name">fill in tag name</param>
    /// <param name="pos">desired spawn location</param>
    /// <param name="quaternion">desired spawn rotation</param>
    /// <param name="AIPrecautions">takes precautions for spawning AI</param>
    /// <returns></returns>
    public GameObject SpawnFromOBJPool(string name, Vector3 pos, Quaternion quaternion, bool AIPrecautions)
    {
        if (poolDictionary.ContainsKey(name) && !AIPrecautions)
        {
            GameObject objectToSpawn = poolDictionary[name].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = pos;
            objectToSpawn.transform.rotation = quaternion;

            poolDictionary[name].Enqueue(objectToSpawn);
            return objectToSpawn;
        }
        if (poolDictionary.ContainsKey(name) && AIPrecautions)
        {
            GameObject objectToSpawn = poolDictionary[name].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(pos);

            poolDictionary[name].Enqueue(objectToSpawn);
            return objectToSpawn;
        }
        else
        {
            Debug.LogError("couldn't Find " + name + "in poolDictionary. please check if spelling had been done correctly");
            return null;
        }
        
    }
}
