using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WarController : MonoBehaviour
{
    public Transform enemy;
    private NavMeshAgent v1_agent;
    public Vector3 _targ;
    public Transform trans;
    public Transform _koster;
    public float Speed = 0.0f;
    public float radiusVid=10;
    public float radiusAtaki=2;
    public float distance; 
    Animator v1_animator;

    public void Awake()
    {
        trans=this.transform;
        _targ = _koster.position;
        v1_agent = GetComponent<NavMeshAgent>();
        v1_agent.speed = Speed;
        v1_animator = GetComponent<Animator>();
    }

    private void Start()
    {       
        
    }

    private void Update()
    {
        distance = Vector3.Distance(trans.position, enemy.transform.position);
        Debug.Log(distance);
        if (distance < radiusVid && distance>radiusAtaki)
        {
            v1_animator.SetBool("vizhuvraga", true);
            v1_agent.SetDestination(enemy.transform.position);
        }
        else if (distance < radiusAtaki)
        {
            v1_animator.SetBool("vizhuvraga", false);
            v1_animator.SetBool("byuvraga", true);
            v1_agent.enabled = false;
        }
        else
        {
            v1_agent.SetDestination(_targ);
        }
    }

}
