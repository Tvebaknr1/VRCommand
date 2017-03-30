using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixmultiplayer : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        
    }
	
	// Update is called once per frame
	void Update () {
        var temp = this.transform.GetComponentInChildren<MeshRenderer>().GetComponent<Transform>().GetComponentInChildren<gun>();
        temp.gameObject.SetActive(true);
        Debug.Log(temp);

    }
}
