using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class player : MonoBehaviour {
    public GameObject vrplayer;
    public bool networkman;
    private LayerMask shootMask;
    public GameObject model;

    private void Awake()
    {
        try
        {
            model = Instantiate(vrplayer, new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z), new Quaternion(0,0,0,0));
            model.transform.parent = this.transform;
           

        }
        catch(UnassignedReferenceException ex)
        {
            Debug.Log(this);
        }

        model = GameObject.FindGameObjectWithTag("playerModel");
    }
    private void Update()
    {
        model.transform.LookAt(this.transform.forward);
    }
}
