using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _speedBullet;

    public void Shot()
    {
        GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward*_speedBullet;
        Destroy(bullet, 5f);
    }
}
