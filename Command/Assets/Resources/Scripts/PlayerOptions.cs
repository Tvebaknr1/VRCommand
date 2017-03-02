using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerOptions : MonoBehaviour {
    public bool usingVR;
    public GameObject canvas;
    public void vr(bool vr)
    {
        usingVR = vr;
        this.GetComponent<NetworkManagerHUD>().enabled = true;
        GameObject.Destroy(canvas);
    }
}
