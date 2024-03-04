using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform currentSurface;

    private Vector3 _targetPosition;
    private NavMeshAgent _agent;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _agent = GetComponent<NavMeshAgent>();

        var newTarget = (Vector3) Random.insideUnitCircle.normalized * 5f;
        _targetPosition = newTarget + transform.position;
        _agent.SetDestination(_targetPosition);
    }

    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) <= 5f &&
            Vector3.Distance(transform.position, currentSurface.position) <= 5f)
        {
            _agent.SetDestination(_player.transform.position);
        }
        else
        {
            var newTarget = (Vector3) Random.insideUnitCircle.normalized * 5f;
            _targetPosition = newTarget += transform.position;
            _agent.SetDestination(_targetPosition);
        }
    }
}
