using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EntityManager1 : MonoBehaviour
{
    public static EntityManager1 instance = null;
    public bool startRound;
    [Header("rounds settings")]
    [SerializeField] int rounds;
    [SerializeField] Transform startPosition;
    IEnumerator coroutine;
    [SerializeField]int EnemiesAlive;
    bool waveDone;
    public static EntityManager1 Instance
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
    public int DecreaseEnemies()
    {
        EnemiesAlive--;
        return EnemiesAlive;
    }
    void Update()
    {
        
        StartWave();
    }
    private void LateUpdate()
    {
        if (EnemiesAlive <= 0)
        {
            gird.instance.DisableGrid(false);
            UIManager.instance.DisableUIElements(false);

        }
        if (EnemiesAlive <= 0 && rounds == 5)
        {
            SceneManager.LoadScene(1);
        }
    }
    void StartWave()
    {
        if (startRound)
        {
            if (rounds == 1)
            {
                coroutine = SpawnEnemies(0, 5, 2f);
                StartCoroutine(coroutine);
                EnemiesAlive = 5;
                //yield return new WaitForSeconds(2f);
                //coroutine = SpawnEnemies(1, 2, 5f);
                //StartCoroutine(coroutine);
                startRound = false;

            }
            if (rounds == 2)
            {
                coroutine = SpawnEnemies(0, 5, 1f);
                StartCoroutine(coroutine);
                //yield return new WaitForSeconds(1f);
                coroutine = SpawnEnemies(1, 2, 1f);
                EnemiesAlive = 7 ;
                StartCoroutine(coroutine);
                //rounds++;
                startRound = false;
            }
            if (rounds == 3)
            {
                coroutine = SpawnEnemies(0, 10, 0.5f);
                StartCoroutine(coroutine);
                coroutine = SpawnEnemies(1, 2, 0.5f);
                EnemiesAlive = 12;
                StartCoroutine(coroutine);
                startRound = false;
            }
            if (rounds == 4)
            {
                coroutine = SpawnEnemies(0, 15, 0.5f);
                StartCoroutine(coroutine);
                coroutine = SpawnEnemies(1, 10, 0.5f);
                EnemiesAlive = 25;
                StartCoroutine(coroutine);
                startRound = false;
            }
            if (rounds == 5)
            {
                coroutine = SpawnEnemies(0, 30, 0.3f);
                StartCoroutine(coroutine);
                coroutine = SpawnEnemies(1, 15, 0.3f);
                EnemiesAlive = 45;
                StartCoroutine(coroutine);
                startRound = false;
            }
        }
    }
    //0 = normal enemy
    //1 = big enemy
    //2 = fast enemy
    //3 = tank enemy
    //4 = jugger naut enemy

    //aeral enemies
    //5 = chopper
    //6 = fast boy/fighter yet
    //7 = bombushka

    /// <summary>
    /// spawn enemies
    /// </summary>
    /// <param name="type">give type enemy to spawn</param>
    /// <param name="howmanny">how manny to spawn</param>
    /// <param name="waitSeconds">how long to wait between spawning</param>
    IEnumerator SpawnEnemies(int type, int howmanny, float waitSeconds)
    {
        switch (type)
        {
            case 0:
                for (int i = 0; i < howmanny; i++)
                {
                    instancer_objectPooling.instance.SpawnFromOBJPool("EnemyOne", startPosition.position, startPosition.rotation, true);
                    yield return new WaitForSeconds(waitSeconds);
                }
                break;
            case 1:
                for (int i = 0; i < howmanny; i++)
                {
                    instancer_objectPooling.instance.SpawnFromOBJPool("EnemyOne", startPosition.position, startPosition.rotation, true);
                    yield return new WaitForSeconds(waitSeconds);
                }
                break;
            case 2:
                Debug.LogWarning("this enemy hasn't been implemented yet");
                yield return null;
                break;
            case 3:
                Debug.LogWarning("this enemy hasn't been implemented yet");
                yield return null;
                break;
            case 4:
                Debug.LogWarning("this enemy hasn't been implemented yet");
                yield return null;
                break;
            case 5:
                Debug.LogWarning("this enemy hasn't been implemented yet");
                yield return null;
                break;
            case 6:
                Debug.LogWarning("this enemy hasn't been implemented yet");
                yield return null;
                break;
                
        }
    }

    public void OnClickButton()
    {
        startRound = true;
        rounds++;
        gird.instance.DisableGrid(true);
        UIManager.instance.DisableUIElements(true);
    }

}
