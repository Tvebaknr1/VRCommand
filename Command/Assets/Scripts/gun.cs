using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class gun : NetworkBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private Vector3 hitpoint;
    public int mag;

    public GameObject bullet;
    public int magsize;
    public int bulletSpeed;
    public LayerMask shootMask;
    public int rpm;
    public float cooldown;
    public AudioClip gunSound;
    public AudioClip reloadSound;
    public shot player;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        switchGun();
        player = transform.GetComponentInParent<Transform>().GetComponentInParent<shot>();
    }
    // Update is called once per frame
    //[Command]
    public void switchGun()
    {
        gunInformation temp = gameObject.GetComponentInChildren<gunInformation>();
        bulletSpeed = temp.bulletSpeed;
        rpm = temp.rpm;
        shootMask = temp.shootMask;
        bullet = temp.bullet;
        magsize = temp.magsize;
        mag = magsize;
        gunSound = temp.gunsound;
        reloadSound = temp.reloadSound;
    }
    void Update () {
        cooldown -= Time.deltaTime;
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
           
            if (cooldown < 0 && mag > 0 )
            {
                soundplay(gunSound);
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
                player.CmdShoot(transform.position, transform.localRotation, hitpoint, bullet, bulletSpeed);
                cooldown = 60 / rpm;
                mag--;
            }
        }
        else if (Controller.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            if (mag <= 0)
            {

                mag = magsize;
                soundplay(reloadSound);

            }
                
        }

    }
    
    void soundplay(AudioClip sound)
    {
        AudioSource soundmaker = this.gameObject.GetComponent<AudioSource>();
        if(sound!= null)
        {
            soundmaker.clip = sound;
            soundmaker.Play();
        }
    }
}
