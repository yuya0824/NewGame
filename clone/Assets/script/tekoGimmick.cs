using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tekoGimmick : MonoBehaviour
{
    [SerializeField]
    private float power = 20.0f;

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        Debug.DrawLine(transform.position + Vector3.up * 0.1f, transform.position + Vector3.up * 0.1f + Vector3.down * 0.2f, Color.red);

        if(Physics2D.Linecast(transform.position + Vector3.up * 0.1f,transform.position + Vector3.up + Vector3.down * 0.2f,LayerMask.GetMask("Block")))
        {
            col.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(Vector3.down * power, transform.position, ForceMode2D.Force);
        }
    }

}
