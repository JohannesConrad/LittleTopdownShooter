using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform followTransform;

    void Start () {
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, -10f);
    }
}
