using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// To destruct the object after certain time
/// </summary>
public class TimeObjectDestructor : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 7f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destruct",timeToDestroy);
    }

    void Destruct()
    {
        Destroy(gameObject);
    }
}
