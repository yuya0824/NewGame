using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tennmetu : MonoBehaviour
{
    private float nextTime;
    public float interval = 1.0f;
    public GameObject a;
    Renderer rend;

    void Start()
    {
        nextTime = Time.time;
        rend = a.GetComponent<Renderer>();
    }

    void Update()
    {
        if (Time.time > nextTime)
        {
            rend.enabled = !rend.enabled;

            nextTime += interval;
        }
    }
}
