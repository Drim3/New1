using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotManager : MonoBehaviour
{
    [SerializeField] private Levl _levl;
    [SerializeField] private Image _hpBar; 

    private float Health = 100;

    private void Awake()
    {
        _levl.IncreaseBots();
    }

    private void Hit(float damage)
    {
        Health -= damage;
        _hpBar.fillAmount -= damage / 100f;

        if(Health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        _levl.DecreasingBots();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            Hit(40);
        }
    }
}
