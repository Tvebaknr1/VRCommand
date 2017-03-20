using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class shot : NetworkBehaviour {
    private LayerMask shootMask;
    private GameObject bullet;

    [Command]
    public void CmdShoot(Vector3 startingPoint, Quaternion rotation, Vector3 direction, GameObject bullet, int bulletSpeed)
    {
        this.bullet = bullet;
        GameObject temp = GameObject.Instantiate(this.bullet, startingPoint, rotation);
        temp.GetComponent<Bullet>().setTarget(direction, bulletSpeed, shootMask);
        NetworkServer.Spawn(temp);
    }
}
