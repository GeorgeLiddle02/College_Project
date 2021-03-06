﻿using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 10f;
    public Recoil RecoilObject;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            RecoilObject.recoil += 0.1f;
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    void Shoot()
        {

        muzzleFlash.Play();

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
            {
                target.TakeDamage(damage);
            }
         }
     }
}
