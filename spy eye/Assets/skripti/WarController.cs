using UnityEngine;
using UnityEngine.AI;

public class WarController : MonoBehaviour
{
    GameObject[] enemies;
    GameObject nearestEnemy;

    private NavMeshAgent v1_agent;
    private Vector3 _targ;
    public GameObject targetAttack;
    private Transform trans;
    public Transform _Target;
    public float radiusVid = 10;
    public float radiusAtaki = 0.5f;
    private float distanceToEnemy;
    private float distanceToFire;
    Animator v1_animator;
    public bool attack;
    

    public void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        targetAttack = GameObject.FindGameObjectWithTag("target");
        trans = this.transform;
        _targ = new Vector3(_Target.position.x + Random.Range(-5, 5), _Target.position.y, _Target.position.z + Random.Range(-2, 2));
        v1_agent = GetComponent<NavMeshAgent>();
        v1_animator = GetComponent<Animator>();
    }

    public void Start()
    {
        attack = false;
    }

    public GameObject ClosestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        nearestEnemy = enemies[0];
        return nearestEnemy;
    }

    public void Update()
    {
        nearestEnemy=ClosestEnemy();
        distanceToEnemy = Vector3.Distance(trans.position, nearestEnemy.transform.position);
        if (distanceToEnemy < radiusVid && distanceToEnemy > radiusAtaki)
        {
            v1_agent.speed = 3;
            v1_animator.SetBool("walk", false);
            v1_animator.SetBool("attack", false);
            v1_animator.SetBool("run", true);
            v1_agent.SetDestination(nearestEnemy.transform.position);
        }
        else if (distanceToEnemy < radiusAtaki)
        {
            v1_animator.SetBool("run", false);
            v1_animator.SetBool("walk", false);
            v1_animator.SetBool("attack", true);
        }
        else if (attack)
        {
                v1_agent.speed = 3;
                v1_animator.SetBool("walk", false);
                v1_animator.SetBool("attack", false);
                v1_animator.SetBool("run", true);
                v1_agent.SetDestination(targetAttack.transform.position);
        }
        else 
        {
                distanceToFire = Vector3.Distance(trans.position, _targ);
                if (distanceToFire > v1_agent.stoppingDistance)
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
                    trans.rotation = Quaternion.Euler(0, 0, 0);
                }
        }
        
    }
    public void Attack()
    { 
        attack = !attack;
    }
}
