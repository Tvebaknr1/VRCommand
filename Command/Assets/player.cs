using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    public GameObject vrplayer;
    private void Awake()
    {
        var temp = Instantiate(vrplayer);
        temp.transform.parent = this.transform;
        var camera = GameObject.FindGameObjectWithTag("strategyCam").GetComponent<Camera>();
        camera.enabled = false;
    }
}
