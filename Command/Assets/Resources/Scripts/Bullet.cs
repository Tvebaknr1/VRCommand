using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour
{

    Vector3 target;
    public int bulletSpeed;
    public LayerMask shootMask;
    public int damage;
    public void setTarget(Vector3 target, int bulletSpeed, LayerMask shootMask, int damage)
    {
        this.damage = damage;
        this.target = target;
        transform.LookAt(this.target);
        this.bulletSpeed = bulletSpeed;
        this.shootMask = shootMask;
        GameObject.Destroy(this.gameObject, 5);
    }
    public void Update()
    {
        transform.position += transform.forward * Time.deltaTime * bulletSpeed;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Time.deltaTime *bulletSpeed*  1.1f, shootMask))
        {
            Debug.Log(hit.collider.gameObject);

            GameObject other = hit.collider.gameObject;
            if (other.GetComponent<Health>() != null)
            {
                other.GetComponent<Health>().TakeDamage(damage);
            }
            else if(other.GetComponentInParent<Health>()!= null)
            {
                other.GetComponentInParent<Health>().TakeDamage(damage);
            }
            GameObject.Destroy(this.gameObject);
        }
    }
}
