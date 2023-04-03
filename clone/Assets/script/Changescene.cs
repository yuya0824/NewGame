using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changescene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "TitleScene")
        {
            SceneManager.LoadScene("GameScene");
        }

        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "ResultScene")
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
