using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class shot : NetworkBehaviour {
    private LayerMask shootMask;
    
    public GameObject bullet;
    private int damage;

    private Vector3 direction;
    private Vector3 start;
    private Vector3 rotation;
    private int bulletSpeed;
    
    
    public void shoot(Vector3 direction, Vector3 start, int bulletSpeed,LayerMask shootmask, int damage)
    {
        this.damage = damage;
        this.direction = direction;
        this.start = start;
        this.bulletSpeed = bulletSpeed;
        this.shootMask = shootmask;
        //Debug.Log(direction+" "+ start);
        CmdShoot();
    }

    [Command]
    public void CmdShoot()
    {
        //Debug.Log(direction + " " + start);
        //gun gun = this.transform.GetComponentInChildren<MeshRenderer>(true).GetComponent<Transform>().GetComponentInChildren<gun>();
        //this.bullet = gun.bullet;
        //GameObject temp = (GameObject)Network.Instantiate(this.bullet, startingPoint, rotation, 0);
        GameObject temp = Instantiate(this.bullet, start, new Quaternion (0,0,0,0));
        temp.GetComponent<Bullet>().setTarget(direction, bulletSpeed, shootMask,damage);

        NetworkServer.Spawn(temp);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0.1F;
            CmdShoot();
        }
    }
}
