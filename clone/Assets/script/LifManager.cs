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

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
