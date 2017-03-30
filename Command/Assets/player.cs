﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class player : MonoBehaviour {
    public GameObject vrplayer;
    public bool networkman;
    private LayerMask shootMask;

    private void Awake()
    {
        try
        {
            var temp = Instantiate(vrplayer);
            temp.transform.parent = this.transform;
            networkman = GameObject.FindGameObjectWithTag("VRPlayer").GetComponent<NetworkIdentity>().isClient;
            if (!networkman)
            {
                var camera = GameObject.FindGameObjectWithTag("strategyCam").GetComponent<Camera>();
                camera.enabled = false;
            }
        }
        catch(UnassignedReferenceException ex)
        {
            Debug.Log(this);
        }
        
    }
    
}
