using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WarController : MonoBehaviour
{
    private NavMeshAgent v1_agent;
    public Vector3 _targ;
    public GameObject _koster;
    public float Speed = 0.0f;

    public void Awake()
    {
        _targ = _koster.transform.position;
        v1_agent = GetComponent<NavMeshAgent>();
        v1_agent.speed = Speed;

    }

    private void Start()
    {
        SledKoster();
    }


    public void SledKoster()
    {

        v1_agent.SetDestination(_targ);
    }
}
