using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class shot : NetworkBehaviour {
    private LayerMask shootMask;
    
    public GameObject bullet;

    public LayerMask shootmask;
    private Vector3 direction;

    private Vector3 start;
    private Vector3 rotation;
    private int bulletSpeed;

    public void shoot(Vector3 direction, Vector3 start, int bulletSpeed)
    {
        this.direction = direction;
        this.start = start;
        this.bulletSpeed = bulletSpeed;
        CmdShoot();
    }

    [Command]
    public void CmdShoot()
    {
        Debug.Log("fuck dis");
        //gun gun = this.transform.GetComponentInChildren<MeshRenderer>(true).GetComponent<Transform>().GetComponentInChildren<gun>();
        //this.bullet = gun.bullet;
        //GameObject temp = (GameObject)Network.Instantiate(this.bullet, startingPoint, rotation, 0);
        GameObject temp = Instantiate(this.bullet, this.transform.position, this.transform.rotation);
        temp.GetComponent<Bullet>().setTarget(direction, bulletSpeed, shootMask);

        NetworkServer.Spawn(temp);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            CmdShoot();
    }
}
