using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Vector3 target;
    public int bulletSpeed;
    public LayerMask shootMask;
    public void setTarget(Vector3 target, int bulletSpeed, LayerMask shootMask)
    {
        this.target = target;
        transform.LookAt(target);
        this.bulletSpeed = bulletSpeed;
        this.shootMask = shootMask;
        GameObject.Destroy(this.gameObject, 2);
    }
    public void Update()
    {
        transform.position += transform.forward * Time.deltaTime * bulletSpeed;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Time.deltaTime, shootMask))
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if ( other.GetComponent<Health>() != null)
        {
            other.GetComponent<Health>().TakeDamage(10);
        }
    }
}
