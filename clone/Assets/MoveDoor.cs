using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    //private Collision2D get2D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetBool("isMove", get2D.gameObject.CompareTag("MoveCollider"));
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //get2D = collision;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MoveCollider")
        {
            Debug.Log(collision.gameObject.tag);
            animator.SetBool("isMove", false);
        }
        //else
        //{
        //    animator.SetBool("isMove", false);
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("isMove", true);
    }
}
