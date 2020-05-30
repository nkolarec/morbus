using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersonController : MonoBehaviour
{

    public Vector3 BuildingEntryPoint;
    public Vector3 BuildingExitPoint;
    public Vector3 SceneExitPoint;

    private NavMeshAgent _agent;
    private List<Vector3> _destinations = new List<Vector3>();
    private int _index;

    private bool _waiting;
    private float _timer;

    private void Awake()
    {
        CreateDestinationsList();
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_destinations[0]);
    }

    private void Update()
    {
        
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

        if (_agent.remainingDistance <= 0.05f)
        {

            _waiting = true;
            // Promijeniti u nešto smisleno, 
            // npr. da na nekim pozicijama poput 
            // pozicije polica ili blagajne čeka 
            // neko vrijeme.
            _timer = 0;
            _index++;
            _agent.isStopped = true;

            if (_index == _destinations.Count)
                Destroy(gameObject);

        }

    }

    private void CreateDestinationsList()
    {

        _destinations.Add(BuildingEntryPoint);

        // Izvući točke unutar prostorije 
        //iz neke posebne skripte or something.
        _destinations.Add(new Vector3(-25, 1, 10));
        _destinations.Add(new Vector3(25, 1, 0));
        _destinations.Add(new Vector3(-35, 1, -20));

        _destinations.Add(BuildingExitPoint);
        _destinations.Add(SceneExitPoint);

    }

}
