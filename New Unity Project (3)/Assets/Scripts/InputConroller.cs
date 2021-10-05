using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputConroller : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private PlayerManager _playerManager;

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_playerManager._previousLvl.CountBots <= 0)
        {
            _playerManager._previousLvl.LevelTransfer();
        }
        else
        if (_playerManager._nextLevl == null)
        {
            _playerManager.Shot();
        }
    }
}
