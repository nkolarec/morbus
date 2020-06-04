using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaController : MonoBehaviour
{

    public GameObject Person;

    public Color ColorHealthy;
    public Color ColorExposed;
    public Color ColorInfected;

    private MeshRenderer _meshRenderer;
    private MeshRenderer _meshRendererPerson;

    private bool _exposed;
    private bool _infected;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRendererPerson = Person.GetComponent<MeshRenderer>();
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

    public void Initialize(bool infected)
    {
        _infected = infected;
        ChangeColor();
    }

    public void StartContact(bool infected)
    {
        if (infected)
        {
            _exposed = true;
            ChangeColor();
        }
    }

}
