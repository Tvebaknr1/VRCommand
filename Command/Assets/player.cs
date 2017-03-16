using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class player : MonoBehaviour {
    public GameObject vrplayer;
    private void Awake()
    {
        var temp = Instantiate(vrplayer);
        temp.transform.parent = this.transform;
        var networkman= GameObject.FindGameObjectWithTag("VRPlayer").GetComponent<NetworkIdentity>().isClient;
        if(networkman)
        {
            var camera = GameObject.FindGameObjectWithTag("strategyCam").GetComponent<Camera>();
            camera.enabled = false;
        }

    }
}
