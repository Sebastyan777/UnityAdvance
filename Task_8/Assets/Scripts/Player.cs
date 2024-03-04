using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private Camera camera;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Input.mousePosition;

            RaycastHit hit;

            if (Physics.Raycast(camera.ScreenPointToRay(mousePosition), out hit))
                _agent.SetDestination(hit.point);
        }
    }
}
