using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private Vector3 hitpoint;
    private int mag;

    public GameObject bullet;
    public int magsize;
    public int bulletSpeed;
    public LayerMask shootMask;
    public int rpm;
    public float cooldown;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        switchGun();
    }
    // Update is called once per frame
    public void switchGun()
    {
        gunInformation temp = gameObject.GetComponentInChildren<gunInformation>();
        bulletSpeed = temp.bulletSpeed;
        rpm = temp.rpm;
        shootMask = temp.shootMask;
        bullet = temp.bullet;
        magsize = temp.magsize;
        mag = magsize;
    }
    void Update () {
        cooldown -= Time.deltaTime;
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
           
            if (cooldown < 0 && mag > 0 )
            {
                RaycastHit hit;
                // 2

                if (Physics.Raycast(trackedObj.transform.position, trackedObj.transform.forward, out hit, 100, shootMask))
                {

                    hitpoint = hit.point;

                }
                else
                {
                    hitpoint = transform.position + (transform.forward * 100);
                }
                Debug.Log(hit.collider.gameObject);
                GameObject temp = GameObject.Instantiate(bullet, transform.position, transform.localRotation);
                temp.GetComponent<Bullet>().setTarget(hitpoint, bulletSpeed, shootMask);
                cooldown = 60 / rpm;
                mag--;
            }
        }

    }
}
