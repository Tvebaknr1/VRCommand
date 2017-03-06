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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //suppose i have two objects here named obj1 and obj2.. how do i select obj1 to be transformed 
                if (hit.transform != null)
                {
                    
                }
            }
        }
    }
}
