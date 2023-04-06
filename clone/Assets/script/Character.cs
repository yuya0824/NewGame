using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField, Header("�n��ɂ���Ƃ��̉��ړ�")]
    private float speed = 5.0f;
    [SerializeField, Header("�󒆂ɂ���Ƃ��̉��ړ�")]
    private float jumpSpeed;
    [SerializeField, Header("���x����")]
    private float LimitSpeed;
    [SerializeField]
    private float jumpPower = 8.0f;

    //private float jump = 0.0f;

    private Rigidbody2D rb;

    const float jumpDown = 0.98f;
    //private GroundCheck2D ground;
    public bool isJump = true;
    [SerializeField, Header("�ڒn�������点�郂�m")]
    private GroundCheck2D[] groundCheck2Ds;

    //private bool zeroFlag;
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
        //zeroFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        float speedPower = 0;
        if (isJump)
            speedPower = speed;
        else
            speedPower = jumpSpeed;


        // �i�E�ړ��j
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (rb.velocity.magnitude < LimitSpeed)
            {
                rb.AddForce(transform.right * (speedPower), ForceMode2D.Force);
            }
        }
        // (���ړ��j
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (rb.velocity.magnitude < LimitSpeed)
            {
                rb.AddForce(-transform.right * (speedPower), ForceMode2D.Force);
            }
        }
        //�W�����v
        if (Input.GetKeyDown(KeyCode.UpArrow) && isJump == true)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0.0f;
            rb.AddForce(transform.up * (jumpPower), ForceMode2D.Force);
            isJump = false;
            //jumpOK = false;
        }
        IsJump();
        //if(!zeroFlag)
        //{
        //    rb.velocity = Vector2.zero;
        //    rb.angularVelocity = 0.0f;
        //}
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
                if(isJump == true)
                {
                    break;
                }
                else
                {
                    isJump = true;
                }
                break;
            }
            isJump = false;
        }

    }

    public bool IsDoJump()
    {
        return isJump;
    }
}