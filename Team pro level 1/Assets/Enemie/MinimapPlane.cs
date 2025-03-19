using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class MinimapPlane : MonoBehaviour
{
    public float fixedY;



    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.zero;
        transform.position = new Vector3(transform.position.x, fixedY, transform.position.z);
        transform.eulerAngles = Vector3.zero;
    }
}
