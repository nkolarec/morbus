using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestructor : MonoBehaviour
{

    public float Lifetime;

    private float _timer;

    private void Update()
    {
        if ((_timer += Time.deltaTime) > Lifetime)
            Destroy(gameObject);
    }

}
