using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrateticPlayer : MonoBehaviour
{
    public playerMovement movement;
    // Use this for initialization
    void Awake()
    {
        movement = GameObject.FindGameObjectWithTag("VRPlayer").GetComponent<playerMovement>() ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = gameObject.GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log(hit.point);
                if (hit.transform != null)
                {
                    movement.giveTarget(hit.point);
                }
            }
        }
    }
}
