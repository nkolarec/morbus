using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoorBehaviour : DoorBehaviour
{

    public Transform DoorLeft;
    public Transform DoorRight;

    public float MovementDistance;
    public float MovementSpeed;
    public Vector3 MovementVectorLeft;
    public Vector3 MovementVectorRight;

    public float OpenHoldTime;

    private Vector3 _destinationPointLeft;
    private Vector3 _destinationPointRight;

    private Vector3 _startingPointLeft;
    private Vector3 _startingPointRight;

    private bool _opening;
    private bool _closing;
    private bool _waiting;

    private float _timer;

    private void Awake()
    {

        _destinationPointLeft = DoorLeft.position + MovementVectorLeft.normalized * MovementDistance;
        _destinationPointRight = DoorRight.position + MovementVectorRight.normalized * MovementDistance;

        _startingPointLeft = DoorLeft.position;
        _startingPointRight = DoorRight.position;

    }

    private void Update()
    {

        if (_opening)
        {

            DoorLeft.position = Vector3.MoveTowards(DoorLeft.position, _destinationPointLeft, MovementSpeed * Time.deltaTime);
            DoorRight.position = Vector3.MoveTowards(DoorRight.position, _destinationPointRight, MovementSpeed * Time.deltaTime);

            if (Vector3.Distance(DoorLeft.position, _destinationPointLeft) <= 0.05f && Vector3.Distance(DoorRight.position, _destinationPointRight) <= 0.1f)
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

            DoorLeft.position = Vector3.MoveTowards(DoorLeft.position, _startingPointLeft, MovementSpeed * Time.deltaTime);
            DoorRight.position = Vector3.MoveTowards(DoorRight.position, _startingPointRight, MovementSpeed * Time.deltaTime);

            if (Vector3.Distance(DoorLeft.position, _startingPointLeft) <= 0.05f && Vector3.Distance(DoorRight.position, _startingPointRight) <= 0.1f)
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
