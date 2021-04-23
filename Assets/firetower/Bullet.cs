using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject fireingpoint;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(Vector3.Distance(fireingpoint.transform.position, transform.position) >= 4)
        {
            DestroyBullet();
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 5f))
        {
            if (hit.collider.tag == "Enemy")
            {
                hit.collider.gameObject.SendMessage("ApplyDamage");
            }
        }
    }
    void DestroyBullet()
    {
        TrailRenderer trail = GetComponent<TrailRenderer>();
        trail.Clear();
        bullet.SetActive(false);
    }
}
