using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyOne : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] Transform start;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float health = 5;


    void Start()
    {
        Target = GameObject.Find("end").transform;
        start = GameObject.Find("startSpawnPoint").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Target.position);
    }

    void ApplyDamage()
    {
        health--;
    }

    void Update()
    {
        if (health <= 0)
        {
            EntityManager1.instance.DecreaseEnemies();
            UIManager.instance.IncreaseScore(false, false);
            gameObject.SetActive(false);
        }
        if(Vector3.Distance(transform.position, Target.position) <= 1)
        {
            UIManager.instance.playerHealth--;
            gameObject.SetActive(false);
        }
    }
}
