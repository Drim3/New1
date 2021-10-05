using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    Vector3 delta;

    private void Awake()
    {
        delta = player.position - transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position,player.position - delta, 5f);
    }
}
