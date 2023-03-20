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

    public Rigidbody2D rb;

    public bool jumpOK = true;

    public touch Tou1;
    public touch Tou2;
    public touch Tou3;
    public touch Tou4;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();

        GameObject obj1 = GameObject.Find("bone_7");
        GameObject obj2 = GameObject.Find("bone_8");
        GameObject obj3 = GameObject.Find("bone_9");
        GameObject obj4 = GameObject.Find("bone_10");

        Tou1 = obj1.GetComponent<touch>();
        Tou2 = obj2.GetComponent<touch>();
        Tou3 = obj3.GetComponent<touch>();
        Tou4 = obj4.GetComponent<touch>();
    }

    // Update is called once per frame
    void Update()
    {
        // （右移動）
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(transform.right * speed, ForceMode2D.Force);
        }

        // (左移動）
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-transform.right * speed, ForceMode2D.Force);
        }

        //ジャンプ
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpOK == true)
        {
            rb.AddForce(transform.up * jumpPower, ForceMode2D.Force);

            jumpOK = false;

        }

        transform.position += jump * transform.up * Time.deltaTime;
        jump *= 0.98f;

        jumpOK = Tou1.jumpOK;
        jumpOK = Tou2.jumpOK;
        jumpOK = Tou3.jumpOK;
        jumpOK = Tou4.jumpOK;
    }
}