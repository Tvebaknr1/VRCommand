using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrateticPlayer : MonoBehaviour
{
    public playerMovement movement;
    // Use this for initialization
    void Awake()
    {
        //movement = GameObject.FindGameObjectWithTag("VRPlayer").GetComponent<playerMovement>() ;
        GameObject temp = new GameObject();
        temp.name = "Fuck unity and camaras";
        temp.AddComponent<Camera>();
        temp.transform.SetParent(this.transform);
        temp.transform.position = new Vector3(0, 10, 0);
        temp.transform.rotation = Quaternion.Euler(90,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(movement == null)
        {
            movement = GameObject.FindGameObjectWithTag("VRPlayer").GetComponent<playerMovement>();
        }
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
        float vertical = Input.GetAxis("Vertical") * 10 * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal") * 10 * Time.deltaTime;
        transform.Translate(horizontal, 0, vertical);
        {

        }
    }
}
