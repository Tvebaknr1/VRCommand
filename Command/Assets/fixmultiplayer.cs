using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixmultiplayer : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        this.transform.GetComponentInChildren<MeshRenderer>().GetComponent<Transform>().GetComponentInChildren<gun>().gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
