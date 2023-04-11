using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pause_1, pause_2, pause_3;
    private Vector2 pos_1, pos_2, pos_3, SelectPos;
    private bool pau1, pau2, pau3;
    private int pauseSelect;

    // Start is called before the first frame update
    void Start()
    {
        pos_1 = pause_1.transform.position;
        pos_2 = pause_2.transform.position;
        pos_3 = pause_3.transform.position;

        SelectPos = pos_1;
        pau1 = true;
        pau2 = false;
        pau3 = false;
        pauseSelect = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MOVESELECT();
        if (Input.GetKeyDown(KeyCode.DownArrow)) pauseSelect++;
        else if (Input.GetKeyDown(KeyCode.UpArrow)) pauseSelect--;
        if (pauseSelect > 2) pauseSelect = 0;
        else if (pauseSelect < 0) pauseSelect = 2;
    }

    void MOVESELECT()
    {
        if (pauseSelect == 0)
        {
            SelectPos = pos_1;
            //if (Input.GetKey(KeyCode.DownArrow))
            //{
            //    SelectPos = pos_2;
            //    pau1 = false;
            //    pau2 = true;
            //}
            //else if(Input.GetKey(KeyCode.UpArrow))
            //{
            //    SelectPos = pos_3;
            //    pau1 = false;
            //    pau3 = true;
            //}
        }

        else if (pauseSelect == 1)
        {
            SelectPos = pos_2;

            //if (Input.GetKeyDown(KeyCode.DownArrow))
            //{
            //    SelectPos = pos_3;
            //    pau2 = false;
            //    pau3 = true;
            //}
            //else if (Input.GetKeyDown(KeyCode.UpArrow))
            //{
            //    SelectPos = pos_1;
            //    pau2 = false;
            //    pau1 = true;
            //}
        }

        else if (pauseSelect == 2)
        {
            SelectPos = pos_3;
            //if (Input.GetKeyDown(KeyCode.DownArrow))
            //{
            //    SelectPos = pos_1;
            //    pau3 = false;
            //    pau1 = true;
            //}
            //else if (Input.GetKeyDown(KeyCode.UpArrow))
            //{
            //    SelectPos = pos_2;
            //    pau3 = false;
            //    pau2 = true;
            //}
        }

        transform.position = SelectPos;
    }
}
