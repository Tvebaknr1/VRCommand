using System.Collections;
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
            var temp = Instantiate(vrplayer, new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z), new Quaternion(0,0,0,0));
            temp.transform.parent = this.transform;

        }
        catch(UnassignedReferenceException ex)
        {
            Debug.Log(this);
        }
        
    }
    
}
