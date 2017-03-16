using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class shot : NetworkBehaviour {
    private LayerMask shootMask;

    [Command]
    public void CmdShoot(Vector3 startingPoint, Quaternion rotation, Vector3 direction, GameObject bullet, int bulletSpeed)
    {
        GameObject temp = GameObject.Instantiate(bullet, startingPoint, rotation);
        NetworkServer.Spawn(temp);
        temp.GetComponent<Bullet>().setTarget(direction, bulletSpeed, shootMask);
    }
}
