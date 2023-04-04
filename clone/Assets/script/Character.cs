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

    private Rigidbody2D rb;

    const float jumpDown = 0.98f;
    //private GroundCheck2D ground;
    public bool jumpOK = true;

    private touch Tou1;
    private touch Tou2;
    private touch Tou3;
    private touch Tou4;

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

        // �i�E�ړ��j
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(transform.right * speed, ForceMode2D.Force);
        }

        // (���ړ��j
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-transform.right * speed, ForceMode2D.Force);
        }

        //�W�����v
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpOK == true)
        {
            rb.AddForce(transform.up * jumpPower, ForceMode2D.Force);

            jumpOK = false;
        }

        jumpOK = Tou1.IsJump();
        jumpOK = Tou2.IsJump();
        jumpOK = Tou3.IsJump();
        jumpOK = Tou4.IsJump();

        transform.position += jump * transform.up * Time.deltaTime;
        jump *= jumpDown;

    }
}