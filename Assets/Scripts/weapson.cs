using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapson : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform firePointGeneric = null;

    void Update()
    {

        if (Input.GetKeyUp(KeyCode.S) && (this.tag == "Player"))
        {
            this.firePointGeneric = firePoint;

        }
        if (firePointGeneric != null)
        {
            Instantiate(bulletPrefab, this.firePointGeneric.position, this.firePointGeneric.rotation);
            firePointGeneric = null;

        }
    }
}
