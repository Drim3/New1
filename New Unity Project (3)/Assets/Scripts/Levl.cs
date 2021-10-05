using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Levl : MonoBehaviour
{   
    [SerializeField] Levl _nextLevel;
    public int CountBots { get; private set; }

    public PlayerManager _player;
    public void IncreaseBots()
    {
        CountBots++;
    }

    public void DecreasingBots()
    {
        CountBots--;    
    }

    public void LevelTransfer()
    {
        if (CountBots <= 0)
        {
            _player.ChangingTheLevel(_nextLevel);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out _player))
        {
            _player._previousLvl = gameObject.GetComponent<Levl>();
            _player._nextLevl = null;
            _player.OnLaser();
        }
    }

}
