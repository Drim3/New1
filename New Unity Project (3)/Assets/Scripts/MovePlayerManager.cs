using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _shot;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LineRenderer _laser;

    public Levl _nextLevl;
    public Levl _previousLvl;

    private float _drag;


    void Start()
    {
        _drag = _rigidbody.drag;
    }

    private void Update()
    {
        if(_nextLevl != null)
        {
            MovePlayer(_nextLevl.transform.position);
        }
        else
        {
            _animator.SetBool("Idle", true);
            _animator.SetBool("Run", false);
            _animator.SetBool("Pistol", true);
        }
    }

    public void Shot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if ((Mathf.Round(_agent.desiredVelocity.magnitude) == 0) && _animator.GetBool("Pistol"))
            {
                LookPosition(hit.point);
                _shot.Invoke();
            }
        }
    }

    public void LookPosition(Vector3 pos)
    {
        Vector3 dir = pos - transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
    }

    public void MovePlayer(Vector3 pos)
    {
        _laser.enabled = false;

        LookPosition(pos);
        _agent.SetDestination(pos);

        Debug.Log(_agent.desiredVelocity.magnitude);
        if (_agent.desiredVelocity.magnitude >= 0.001f)
        {
            _animator.SetBool("Run", true);        
            _animator.SetBool("Pistol", false);
            _animator.SetBool("Idle", false);
        }
    }

    public void ChangingTheLevel(Levl levl)
    {
        _nextLevl = levl;
    }

    public void OnLaser()
    {
        _laser.enabled = true; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody.drag = _drag;
    }

    private void OnCollisionExit(Collision collision)
    {
        _rigidbody.drag = 0;
    }
}
