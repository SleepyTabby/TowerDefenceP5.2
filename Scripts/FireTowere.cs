using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTowere : MonoBehaviour
{
	[SerializeField] private float TimeBetweenShots;
	[SerializeField] private float startTimeBetweenShots;
	[SerializeField] private GameObject projectile;
	[SerializeField] private Transform firingPoint;
	[SerializeField] float range = 5;
	Transform Enemytransform;
	void Start()
	{
		TimeBetweenShots = startTimeBetweenShots;
	}
	void Update()
	{
		FindClosestEnemy();
		firingPoint.transform.LookAt(Enemytransform);
        if (Vector3.Distance(Enemytransform.position, transform.position) <= range)
        {
			ShootAtEnemy();
		}
		
	}
	public void ShootAtEnemy()
	{
		if (TimeBetweenShots <= 0)
		{
			instancer_objectPooling.instance.SpawnFromOBJPool("Bullet", firingPoint.position, firingPoint.rotation, false);
			//Instantiate(projectile, firingPoint.position, firingPoint.rotation);
			TimeBetweenShots = startTimeBetweenShots;
		}
		else
		{
			TimeBetweenShots -= Time.deltaTime;
		}
	}
	void FindClosestEnemy()
	{
		float distanceToClosestEnemy = Mathf.Infinity;
		EnemyOne closestEnemy = null;
		EnemyOne[] allEnemies = GameObject.FindObjectsOfType<EnemyOne>();

		foreach (EnemyOne currentEnemy in allEnemies)
		{
			float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToEnemy < distanceToClosestEnemy)
			{
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}
		}
		Enemytransform = closestEnemy.transform;
		Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
	}
	//public GameObject GetClosestEnemy()
	//{

	//}
}
