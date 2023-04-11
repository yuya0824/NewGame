using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private float timer;
    [SerializeField]
    private Text textTime;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        textTime.text = string.Format("{0:0.00} time", timer);
    }

    
}
