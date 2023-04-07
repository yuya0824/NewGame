using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{

    [SerializeField, Header("エレベーター")]
    public GameObject elevator;

    private bool UP;
    private bool DOWN;

    private float plusY = 0.0f;
    private Vector3 fastPos;

    // Start is called before the first frame update
    void Start()
    {
        fastPos = elevator.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        elevator.transform.position += new Vector3(0.0f, plusY, 0.0f);

        if(elevator.transform.position.y >= fastPos.y)
        {
            DOWN = true;
            UP = false;
            plusY = 0.0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "stage")
        {
            plusY = 0.0f;
            UP = true;
            DOWN = false;
        }

        if((collision.gameObject.name == "bone_7" || collision.gameObject.name == "bone_8"
            || collision.gameObject.name == "bone_9" || collision.gameObject.name == "bone_10") && elevator.transform.position.y >= fastPos.y && DOWN == true)
        {
            plusY = -0.01f;
        }
        if ((collision.gameObject.name == "bone_7" || collision.gameObject.name == "bone_8"
    || collision.gameObject.name == "bone_9" || collision.gameObject.name == "bone_10") && elevator.transform.position.y <= fastPos.y && UP == true)
        {
            plusY = 0.01f;
        }

    }
}
