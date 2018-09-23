using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkollonProjectile : MonoBehaviour
{
    public float timeToLive;

    private void Awake()
    {
        Destroy(gameObject, timeToLive);
    }

}
