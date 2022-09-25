using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WarController : MonoBehaviour
{
    public GameObject enemy;
    private NavMeshAgent v1_agent;
    private Vector3 _targ;
    private Transform trans;
    public Transform _Target;
    public float radiusVid = 10;
    public float radiusAtaki = 0.5f;
    private float distanceToEnemy;
    private float distanceToKoster;
    Animator v1_animator;

    public void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
        trans = this.transform;
        _targ = new Vector3(_Target.position.x+Random.Range(-5,5), _Target.position.y, _Target.position.z+Random.Range(-2,2));
        v1_agent = GetComponent<NavMeshAgent>();
        v1_animator = GetComponent<Animator>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        distanceToEnemy = Vector3.Distance(trans.position, enemy.transform.position);
        if (distanceToEnemy < radiusVid && distanceToEnemy > radiusAtaki)
        {
            v1_agent.speed = 3;
            v1_animator.SetBool("walk", false);
            v1_animator.SetBool("attack", false);
            v1_animator.SetBool("run", true);
            v1_agent.SetDestination(enemy.transform.position);
        }
        else if (distanceToEnemy < radiusAtaki)
        {
            v1_animator.SetBool("run", false);
            v1_animator.SetBool("walk", false);
            v1_animator.SetBool("attack", true);
        }
        else
        {
            distanceToKoster = Vector3.Distance(trans.position, _targ);
            if (distanceToKoster > v1_agent.stoppingDistance)
            {
                v1_agent.speed = 1;
                v1_animator.SetBool("run", false);
                v1_animator.SetBool("attack", false);
                v1_animator.SetBool("walk", true);
                v1_agent.SetDestination(_targ);
            }
            else
            {
                v1_animator.SetBool("run", false);
                v1_animator.SetBool("attack", false);
                v1_animator.SetBool("walk", false);
                trans.rotation = Quaternion.Euler(0,0,0);
            }
        }
    }

}
