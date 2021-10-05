using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePlayerManager : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;

    private float _drag;

    public Transform point;

    void Start()
    {
        _drag = _rigidbody.drag;
    }

    private void Update()
    {
        if(point != null)
        {
            MovePlayer(point.position);
        }
    }

    public void MovePlayer(Vector3 pos)
    {
        Vector3 dir = pos - transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);

        _agent.SetDestination(pos);

        if (dir.magnitude >= 0.01f)
        {
            _animator.SetBool("OnRun", true);
            _animator.SetBool("OffRun", false);
        }
        else
        {
            _animator.SetBool("OnRun", false);
            _animator.SetBool("OffRun", true);
        }
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
