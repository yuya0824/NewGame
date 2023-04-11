using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pause_1, pause_2, pause_3;
    private Vector2 pos_1, pos_2, pos_3, SelectPos;

    // Start is called before the first frame update
    void Start()
    {
        pos_1 = pause_1.transform.position;
        pos_2 = pause_2.transform.position;
        pos_3 = pause_3.transform.position;

        SelectPos = pos_1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
