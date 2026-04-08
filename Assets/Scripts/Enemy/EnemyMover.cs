using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private bool _randomPatrol = false;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private PlayerMover _player;
    [SerializeField] private EnemyAnimationEventHandler _animationEvents;
    [SerializeField] private EnemyHealth _health;
    [SerializeField] private EnemyAttacker _attacker;
    [SerializeField] private float _playerNoticeDistance;
    [SerializeField] private float _viewAngle;

    private NavMeshAgent _agent;
    private int _wayPointIndex;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        _health.TookDamage += StopMoving;
        _animationEvents.HitAnimationEnded += ContinueMoving;
        _animationEvents.AttackEnded += ContinueMoving;
        _attacker.Attaking += StopMoving;
    }


    private void Start()
    {
        PickNewPatrolPoint();
    }

    private void Update()
    {
        bool playerIsSeen = TrySeePlayer();

        if (playerIsSeen)
        {
            ChasePlayer();
        }

        if (Vector3.Distance(transform.position, _agent.destination) < _agent.stoppingDistance && playerIsSeen == false)
        {
            PickNewPatrolPoint();
        }

    }
 
    private void OnDisable()
    {
        _health.TookDamage -= StopMoving;
        _animationEvents.HitAnimationEnded -= ContinueMoving;
        _animationEvents.AttackEnded -= ContinueMoving;
        _attacker.Attaking -= StopMoving;
    }

    private void PickNewPatrolPoint()
    {
        if (_randomPatrol)
        {
            _agent.SetDestination(_points[Random.Range(0, _points.Count)].position);
        }
        else
        {
            _agent.SetDestination(_points[_wayPointIndex].position);
            _wayPointIndex = (_wayPointIndex + 1) % _points.Count;
        }
    }

    private void ChasePlayer()
    {
            _agent.SetDestination(_player.transform.position);
    }

    private bool TrySeePlayer()
    {
        Vector3 origin = transform.position + Vector3.up;
        Vector3 direction = _player.transform.position - transform.position;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, _playerNoticeDistance))
        {
            if (hit.collider.TryGetComponent(out PlayerMover player))
            {
                if (Vector3.Angle(transform.forward, _player.transform.position) < _viewAngle)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void StopMoving()
    {
        _agent.isStopped = true;
    }

    private void ContinueMoving()
    {
        _agent.isStopped = false;
    }
}
