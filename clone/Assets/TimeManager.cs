using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private float timer;
    [SerializeField]
    private Text textTime;
    private bool oneOrThen;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            oneOrThen = !oneOrThen;
        }
        //int oneOrThenGoodbye = 0;
        //if (oneOrThen)
        //{
        //    oneOrThenGoodbye = 1;
        //}
        if(oneOrThen)
        timer += Time.deltaTime/* * oneOrThenGoodbye*/;
        textTime.text = string.Format("{0:00.00} •b", timer);
    }

    
}
