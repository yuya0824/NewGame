using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float LimitSpeed;
    [SerializeField]
    private float jumpPower = 8.0f;

    //private float jump = 0.0f;

    private Rigidbody2D rb;

    const float jumpDown = 0.98f;
    //private GroundCheck2D ground;
    public bool isJump = true;
    [SerializeField]
    private GroundCheck2D[] groundCheck2Ds;

    //private touch Tou1;
    //private touch Tou2;
    //private touch Tou3;
    //private touch Tou4;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();

        //GameObject obj1 = GameObject.Find("bone_7");
        //GameObject obj2 = GameObject.Find("bone_8");
        //GameObject obj3 = GameObject.Find("bone_9");
        //GameObject obj4 = GameObject.Find("bone_10");

        //Tou1 = obj1.GetComponent<touch>();
        //Tou2 = obj2.GetComponent<touch>();
        //Tou3 = obj3.GetComponent<touch>();
        //Tou4 = obj4.GetComponent<touch>();
    }

    // Update is called once per frame
    void Update()
    {

        // （右移動）
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (rb.velocity.magnitude < LimitSpeed)
            {
                if (isJump)
                rb.AddForce(transform.right * (speed), ForceMode2D.Force);
                else
                    rb.AddForce(transform.right * (speed * 0.8f), ForceMode2D.Force);
            }
        }
        // (左移動）
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (rb.velocity.magnitude < LimitSpeed)
            {
                if(isJump)
                rb.AddForce(-transform.right * (speed), ForceMode2D.Force);
                else
                    rb.AddForce(-transform.right * (speed * 0.8f), ForceMode2D.Force);
            }
        }
        //ジャンプ
        if (Input.GetKeyDown(KeyCode.UpArrow) && isJump == true)
        {
            rb.AddForce(transform.up * (jumpPower), ForceMode2D.Force);
            isJump = false;
            //jumpOK = false;
        }
        IsJump();
        //jumpOK = Tou1.IsJump();
        //jumpOK = Tou2.IsJump();
        //jumpOK = Tou3.IsJump();
        //jumpOK = Tou4.IsJump();
        //jumpOK = 

        //transform.position += jump * transform.up * Time.deltaTime;
        //jump *= jumpDown;

    }

    private void IsJump()
    {
        foreach (GroundCheck2D groundCheck2D in groundCheck2Ds)
        {
            if (groundCheck2D.CheckGroundStatus())
            {
                isJump = true;
                break;
            }
            isJump = false;
        }

    }
}