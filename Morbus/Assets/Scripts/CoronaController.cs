using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoronaController : MonoBehaviour
{

    public static UnityEvent PersonHealthyCreated = new UnityEvent();
    public static UnityEvent PersonInfectedCreated = new UnityEvent();
    public static UnityEvent PersonExposed = new UnityEvent();

    public static CustomEvent<bool, float, bool, bool> PersonDestroyed = new CustomEvent<bool, float, bool, bool>();

    public GameObject Person;

    public Color ColorHealthy;
    public Color ColorExposed;
    public Color ColorInfected;

    private MeshRenderer _meshRenderer;
    private MeshRenderer _meshRendererPerson;

    private bool _exposed;
    private bool _infected;

    private bool _distance;
    private bool _mask;
    private float _percentage;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRendererPerson = Person.GetComponent<MeshRenderer>();
    }

    private void OnDestroy()
    {
        PersonDestroyed.Invoke(_exposed, _percentage, _distance, _mask);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Person"))
            other.GetComponentInChildren<CoronaController>().StartContact(_infected);
    }

    private void ChangeColor()
    {

        Color color = ColorHealthy;

        if (_exposed)
            color = ColorExposed;

        if (_infected)
            color = ColorInfected;

        color.a = 0.05f;
        _meshRenderer.material.color = color;

        color.a = 1;
        _meshRendererPerson.material.color = color;

    }

    public void Initialize(bool infected, float percentage, bool distance, bool mask)
    {

        _infected = infected;
        ChangeColor();

        if (_infected)
            PersonInfectedCreated.Invoke();
        else
            PersonHealthyCreated.Invoke();

        _distance = distance;
        _mask = mask;
        _percentage = percentage;

    }

    public void StartContact(bool infected)
    {
        if (infected && _exposed == false && _infected == false)
        {
            _exposed = true;
            ChangeColor();
            PersonExposed.Invoke();
        }
    }

}
