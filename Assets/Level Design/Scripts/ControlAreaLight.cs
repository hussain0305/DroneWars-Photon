using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAreaLight : MonoBehaviour {

    public float duration = 40.0F;
    public Light lt;
    void Start()
    {
        lt = GetComponent<Light>();
    }
    void Update()
    {
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = (Mathf.Sin(phi) + 1.0F);
        lt.intensity = amplitude;
    }
}
