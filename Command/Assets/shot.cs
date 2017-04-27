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
        Debug.Log("fuck dis");
        gun gun = this.transform.GetComponentInChildren<MeshRenderer>(true).GetComponent<Transform>().GetComponentInChildren<gun>();
        this.bullet = gun.bullet;
        GameObject temp = (GameObject)Network.Instantiate(this.bullet, startingPoint, rotation, 0);
        //GameObject temp = GameObject.Instantiate(this.bullet, startingPoint, rotation);
        temp.GetComponent<Bullet>().setTarget(direction, bulletSpeed, shootMask);
        
        //NetworkServer.SpawnWithClientAuthority(temp,netID.connectionToClient);
    }
}
