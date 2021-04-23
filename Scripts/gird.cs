using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gird : MonoBehaviour
{


    public static gird instance = null;
    public static gird Instance
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

    [SerializeField] GameObject tilePrefab;
    [SerializeField] Vector2 mapSize;
    [SerializeField] float heightOffset;
    [SerializeField] float xOffset;
    [SerializeField] float zOffset;
    [SerializeField] float howClose;
    [SerializeField] bool build;
    List<GameObject> gameObjects = new List<GameObject>();
    //List<GameObject> selectedGameObjects = new List<GameObject>();
    private void Start()
    {
        GenerateMap();
    }
    void GenerateMap()
    {
        if(build)
        {
            for (float x = 0; x < mapSize.x; x = ((1 + x) - howClose))
            {
                for (float y = 0; y < mapSize.y; y = ((1 + y) - howClose))
                {
                    Vector3 tilePos = new Vector3((-mapSize.x + xOffset) + x, heightOffset, (-mapSize.y + zOffset) + y);
                    gameObjects.Add(Instantiate(tilePrefab, tilePos, transform.rotation));
                }
            }
        }
    }

    public void DisableGrid(bool disable)
    {
        if (disable)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].SendMessage("RemSelected");
                gameObjects[i].SetActive(false);
            }
        }
        if (disable != true)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].SetActive(true);
            }
        }
    }

    private void OnDrawGizmos()
    {
        for (float x = 0; x < mapSize.x; x = ((1 + x) - howClose))
        {
            for (float y = 0; y < mapSize.y; y = ((1 + y) - howClose))
            {
                Vector3 tilePos = new Vector3((-mapSize.x + xOffset) + x, heightOffset, (-mapSize.y + zOffset) + y);
                Gizmos.DrawWireCube(tilePos, new Vector3(0.56f, 0f, 0.56f));
            }
        }
    }

}
