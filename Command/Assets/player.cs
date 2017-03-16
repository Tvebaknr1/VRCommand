﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class player : NetworkBehaviour {
    public GameObject vrplayer;
    public bool networkman;
    private LayerMask shootMask;

    private void Awake()
    {
        var temp = Instantiate(vrplayer);
        temp.transform.parent = this.transform;
        networkman= GameObject.FindGameObjectWithTag("VRPlayer").GetComponent<NetworkIdentity>().isClient;
        if(!networkman)
        {
            var camera = GameObject.FindGameObjectWithTag("strategyCam").GetComponent<Camera>();
            camera.enabled = false;
        }
    }
    [Command]
    public void CmdShoot(Vector3 startingPoint,Quaternion rotation, Vector3 direction,GameObject bullet, int bulletSpeed)
    {
        GameObject temp = GameObject.Instantiate(bullet, startingPoint, rotation);
        NetworkServer.Spawn(temp);
        temp.GetComponent<Bullet>().setTarget(direction, bulletSpeed, shootMask);
    }
}
