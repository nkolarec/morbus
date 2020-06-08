using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTime : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
