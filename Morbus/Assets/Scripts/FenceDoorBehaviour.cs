using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceDoorBehaviour : DoorBehaviour
{

    public Transform Door;

    public float MovementDistance;
    public float MovementSpeed;
    public Vector3 MovementVector;

    public float OpenHoldTime;

    private Vector3 _destinationPoint;
    private Vector3 _startingPoint;

    private bool _opening;
    private bool _closing;
    private bool _waiting;

    private float _timer;

    private void Awake()
    {
        _destinationPoint = Door.position + MovementVector.normalized * MovementDistance;
        _startingPoint = Door.position;
    }

    private void Update()
    {

        if (_opening)
        {

            Door.position = Vector3.MoveTowards(Door.position, _destinationPoint, MovementSpeed * Time.deltaTime);

            if (Vector3.Distance(Door.position, _destinationPoint) <= 0.05f)
            {
                _timer = OpenHoldTime;
                _waiting = true;
                _opening = false;
            }

        }

        if (_waiting)
        {
            _timer -= Time.deltaTime;
            _waiting = _timer > 0;
            _closing = _timer < 0;
        }

        if (_closing)
        {

            Door.position = Vector3.MoveTowards(Door.position, _startingPoint, MovementSpeed * Time.deltaTime);

            if (Vector3.Distance(Door.position, _startingPoint) <= 0.05f)
                _closing = false;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Open();
    }

    public override void Open()
    {
        _opening = true;
        _closing = false;
        _waiting = false;
    }

}
