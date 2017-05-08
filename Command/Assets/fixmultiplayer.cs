using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixmultiplayer : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Transform[] temp = this.transform.GetComponentInChildren<MeshRenderer>(true).GetComponent<Transform>().GetComponentsInChildren<Transform>(true);
        foreach (Transform tra in temp)
        {
            tra.gameObject.SetActive(true);
        }
        if (temp != null)
            Destroy(this);

    }
}
