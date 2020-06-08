using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersonController : MonoBehaviour
{

    public GameObject DistanceKeeper;

    private NavMeshAgent _agent;
    private List<Vector3> _destinations = new List<Vector3>();
    private int _index;

    private bool _checkout;
    private bool _waiting;
    private float _timer;

    private void Start()
    {
        CreateDestinationsList();
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_destinations[0]);
    }

    private void Update()
    {

        if (_checkout)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _waiting = false;
            _agent.SetDestination(_destinations[_index]);
            _agent.isStopped = false;
            return;
        }
        
        if (_waiting)
        {

            if ((_timer -= Time.deltaTime) < 0)
            {
                _waiting = false;
                _agent.SetDestination(_destinations[_index]);
                _agent.isStopped = false;
            }

            return;

        }

        if (_agent.remainingDistance <= 0.5f)
        {

            _waiting = true;
            _timer = (_index > 0 && _index < _destinations.Count - 4) ? Random.Range(1.0f, 2.5f) : 0.05f;
            _index++;
            _agent.isStopped = true;

            if (_index == _destinations.Count)
                Destroy(gameObject);

        }

    }

    private void CreateDestinationsList()
    {
        foreach (Vector3 destination in LevelManager.LM.GetPoints(Random.Range(1, (int)LevelManager.LM.NumberOfPoints / 2)))
            _destinations.Add(destination);
    }

    public void CheckoutEnd()
    {
        _agent.isStopped = false;
        _checkout = false;
    }

    public void CheckoutStart()
    {
        _agent.isStopped = true;
        _checkout = true;
    }

}
