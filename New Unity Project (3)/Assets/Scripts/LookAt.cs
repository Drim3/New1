using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        Vector3 temp = _mainCamera.transform.position - transform.position;

        transform.rotation = Quaternion.LookRotation(-temp);
    }
}
