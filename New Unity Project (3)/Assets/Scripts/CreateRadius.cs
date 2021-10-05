using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRadius : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objects;   
    [SerializeField] private float _radius;
    [SerializeField] private bool _active = false;
    private void OnValidate()
    {
        if (_active)
        {
            float angle = 0;
            float deltaRadius = 360 / _objects.Count;
        
            for (int i = 0; i < _objects.Count; i++)
            {
                float x = _radius * Mathf.Cos(angle * Mathf.Deg2Rad);
                float z = _radius * Mathf.Sin(angle * Mathf.Deg2Rad);
                _objects[i].transform.position = transform.position +  new Vector3(x,0,z);
                angle += deltaRadius;
            }
        }
    }


}
