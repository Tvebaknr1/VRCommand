using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class shot : NetworkBehaviour {
    private LayerMask shootMask;
    public GameObject bullet;
    [Command]
    public void CmdShoot(Vector3 startingPoint, Quaternion rotation, Vector3 direction, int bulletSpeed)
    {
        Debug.Log("fuck dis");
        
        //GameObject temp = (GameObject)Network.Instantiate(this.bullet, startingPoint, rotation, 0);
        GameObject temp = Instantiate(this.bullet, startingPoint, rotation);
        temp.GetComponent<Bullet>().setTarget(direction, bulletSpeed, shootMask);
        
        NetworkServer.Spawn(temp);
    }
}
