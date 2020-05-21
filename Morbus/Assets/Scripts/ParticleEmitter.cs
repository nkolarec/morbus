using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{

    [Header("Particle Details")]

    public GameObject ParticleObject;
    public int ParticlesInSceneLimit;

    [Header("Emission Details")]

    public Vector2 DirectionRangeX;
    public Vector2 DirectionRangeY;
    public Vector2 DirectionRangeZ;
    public Vector2 FrequencyRange;
    public Vector2 ScaleRange;
    public Vector2 SpeedRange;
    public Vector2 StartPointRangeX;
    public Vector2 StartPointRangeY;
    public Vector2 StartPointRangeZ;

    private int _particles;
    private float _timer;
    private Transform _transform;

    private void Awake()
    {

        _transform = transform;
        ParticleBehaviour.ParticleCreatedEvent.AddListener(ParticleNumberIncrease);
        ParticleBehaviour.ParticleDestroyedEvent.AddListener(ParticleNumberDecrease);

        CreateParticle();
        CreateParticle();
        CreateParticle();

    }

    private void Update()
    {

        _timer -= Time.deltaTime;

        if (_timer < 0 && _particles < ParticlesInSceneLimit)
        {
            _timer = FrequencyRange.RandomValue();
            CreateParticle();
        }

    }

    private void CreateParticle()
    {

        Vector3 direction = new Vector3(DirectionRangeX.RandomValue(), DirectionRangeY.RandomValue(), DirectionRangeZ.RandomValue());
        Vector3 position = new Vector3(StartPointRangeX.RandomValue(), StartPointRangeY.RandomValue(), StartPointRangeZ.RandomValue());

        GameObject spawnedParticleObject = Instantiate(ParticleObject, _transform);
        spawnedParticleObject.GetComponent<ParticleBehaviour>().SetUpTransform(position, ScaleRange.RandomValue());
        spawnedParticleObject.GetComponent<ParticleBehaviour>().SetUpRigidbody(direction.normalized, SpeedRange.RandomValue());

    }

    private void ParticleNumberDecrease()
    {
        _particles -= 1;
    }

    private void ParticleNumberIncrease()
    {
        _particles += 1;
    }

}
