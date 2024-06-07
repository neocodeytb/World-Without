using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CameraMenuScript : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(-6, 2, 6);

    void Start()
    {
        transform.position = new Vector3(0, 60, 0) + offset;
    }
void Update()
    {
    if (transform.position.y > 4)
    {
        transform.Translate(0, -0.1f, 0, Space.World);
    }
        transform.LookAt(target);
    }
}
