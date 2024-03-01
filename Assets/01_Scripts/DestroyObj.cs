using System;
using System.Collections;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (transform.position.x + 15 < cam.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
