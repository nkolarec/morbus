using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParticleBehaviour : MonoBehaviour
{

    public static UnityEvent ParticleCreatedEvent = new UnityEvent();
    public static UnityEvent ParticleDestroyedEvent = new UnityEvent();

    private bool _wasInScene = true;

    private void OnBecameInvisible()
    {
        if (_wasInScene)
        {
            ParticleDestroyedEvent.Invoke();
            Destroy(gameObject, 1);
        }
    }

    private void OnBecameVisible()
    {
        _wasInScene = true;
        ParticleCreatedEvent.Invoke();
    }

    public void SetUpTransform(Vector3 position, float scale)
    {
        transform.position = position;
        transform.localScale = scale * Vector3.one;
        transform.Rotate(Vector3.up, Random.Range(0.0f, 360.0f));
    }

    public void SetUpRigidbody(Vector3 direction, float speed)
    {
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().AddForce(speed * direction);
    }

}
