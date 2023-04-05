using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class touch : MonoBehaviour
{
    private float size = 0;

    //private bool jumpOK = true;

    private int waterCount = 0;

    public GameObject player;

    void Start()
    {
        //jumpOK = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.name == "Stage")
        //{
        //    jumpOK = true;
        //}
        //if (collision.gameObject.name == "CharacterPrefab(Clone)")
        //{
        //    jumpOK = true;
        //}

        if (collision.gameObject.name == "goal")
        {
            SceneManager.LoadScene("ResultScene");
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name == "waterCollider")
        {
            if (waterCount < 3)
            {
                StartCoroutine(ReplayerSize());
                player.transform.localScale = new Vector3(size, size, 1);
            }
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (transform.localScale.x >= 1.0f && transform.localScale.y >= 1.0f && transform.localScale.z >= 1.0f)
        {
            waterCount += 1;
        }
    }

    IEnumerator ReplayerSize()
    {
        size = transform.localScale.x;
        while (size <= 1)
        {
            size += 0.01f;
            yield return new WaitForSeconds(0.1f);

        }
    }

    //public bool IsJump()
    //{
    //    return jumpOK;
    //}
}
