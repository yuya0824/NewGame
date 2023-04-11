using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager2 : MonoBehaviour
{
    private float timer;
    [SerializeField]
    private Text textTime;
    private bool oneOrThen;
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        oneOrThen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            oneOrThen = !oneOrThen;
        }

        if (oneOrThen)
            textTime.text = string.Format("{0:00.00} •b", Time.time - timer);
    }
}
