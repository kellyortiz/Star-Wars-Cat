using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Vector3 cameraPosition = Vector3.zero;
    public Transform target;




    void FixedUpdate()
    {
        cameraPosition = new Vector3(
            Mathf.SmoothStep(transform.position.x, target.transform.position.x, 4f),
            Mathf.SmoothStep(transform.position.y, target.transform.position.y, 4f));
    }

    void LateUpdate()
    {
        transform.position = cameraPosition + Vector3.forward * -10;
    }
}
