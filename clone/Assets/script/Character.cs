using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float jumpPower = 8.0f;

    private float jump = 0.0f;

    private float size = 0;

    bool jumpOK = true;

    private int waterCount = 0;

    // Update is called once per frame
    void Update()
    {
        // （右移動）
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += speed * transform.right * Time.deltaTime;
        }

        // (左移動）
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= speed * transform.right * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpOK == true)
        {
            jump = jumpPower;

            jumpOK = false;

        }

        transform.position += jump * transform.up * Time.deltaTime;
        jump *= 0.98f;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Stage")
        {
            jumpOK = true;
        }

        if(collision.gameObject.name == "CharacterPrefab(Clone)")
        {
            jumpOK = true;
        }

        if (collision.gameObject.name == "goal")
        {
            Debug.Log("goal");
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name == "waterCollider")
        {
            if (waterCount < 3)
            {
                StartCoroutine(ReplayerSize());
                transform.localScale = new Vector3(size, size, 1);
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
        while(size <= 1)
        {
            size += 0.01f;
            yield return new WaitForSeconds(0.1f);

        }
    }
}