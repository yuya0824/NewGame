using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifManager : MonoBehaviour
{
    [SerializeField, Header("ƒŠƒtƒg")]
    public GameObject lift;

    private bool RIGHT;
    private bool LEFT;

    private float plusX = 0.0f;
    private Vector3 fastPos;

    // Start is called before the first frame update
    void Start()
    {
        fastPos = lift.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lift.transform.position += new Vector3(plusX, 0.0f,  0.0f);

        if (lift.transform.position.x >= fastPos.x)
        {
            RIGHT = true;
            LEFT = false;
            plusX = 0.0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "stage")
        {
            plusX = 0.0f;
            RIGHT = true;
            LEFT = false;
        }

        if ((collision.gameObject.name == "bone_7" || collision.gameObject.name == "bone_8"
            || collision.gameObject.name == "bone_9" || collision.gameObject.name == "bone_10") && lift.transform.position.x >= fastPos.x && LEFT == true)
        {
            plusX = -0.01f;
        }
        if ((collision.gameObject.name == "bone_7" || collision.gameObject.name == "bone_8"
    || collision.gameObject.name == "bone_9" || collision.gameObject.name == "bone_10") && lift.transform.position.x <= fastPos.x && RIGHT == true)
        {
            plusX = 0.01f;
        }

    }
}
