using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playershoot : MonoBehaviour
{
    [Header("Bullet Variables")]
    public float bulletSpeed;
    public float fireRate, bulletDamage;
    public bool isAuto;

    [Header("initial Setup")]
    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    private void Update() 
    {
        if (isAuto == true)
        {
            if (Input.GetButton("Fire1"))
            {
                Debug.Log("im shooting");
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();

                
            }
        }
    }

    void Shoot()
    {
         GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("WorldObjectHolder").transform);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward * bulletSpeed, ForceMode.Impulse);
    }
}

