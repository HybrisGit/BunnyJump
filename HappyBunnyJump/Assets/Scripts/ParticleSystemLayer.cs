using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemLayer : MonoBehaviour {

    public string sortingLayer = "Foreground";

    void Awake()
    {
        this.GetComponent<ParticleSystemRenderer>().sortingLayerName = this.sortingLayer;
    }
}
