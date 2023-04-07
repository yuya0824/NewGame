using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    public enum ElevatorCondition1
    {
        Wait,
        Move
    }
    public enum ElevatorCondition2
    {
        Go,
        Come,
    }

    //[SerializeField, Header("エレベーター")]
    //private GameObject elevator;
    private ElevatorCondition1 condition1;
    private ElevatorCondition2 condition2;
    [System.Serializable]
    public struct ElevatorMove
    {
        [Range(0, 360)]
        public float elevatorVector;

        public float distance;
    };

    [SerializeField]
    private ElevatorMove[] elevatorMove;

    [SerializeField]
    private GameObject player;
    private Vector2 moveVelocity = new Vector2(0.0f, 0.0f);
    private Vector2 fastPos;
    private Vector2 lastPos;
    private bool isMove;
    private bool isFollowMove;
    //private ElevatorCondition elevatorCondition;
    // Start is called before the first frame update
    void Start()
    {
        fastPos = gameObject.transform.position;
        Vector2 vector2 = gameObject.transform.position;
        for (int i = 0; i < elevatorMove.Length; i++)
        {
            float radAngle = elevatorMove[i].elevatorVector * Mathf.Deg2Rad;

            float x = elevatorMove[i].distance * Mathf.Cos(radAngle);
            float y = elevatorMove[i].distance * Mathf.Sin(radAngle);
            vector2 += new Vector2(x, y);
        }
        lastPos = vector2;

        //elevatorCondition = ElevatorCondition.WaitDown;
        isMove = true;
        isFollowMove = false;
        condition1 = ElevatorCondition1.Wait;
        condition2 = ElevatorCondition2.Go;
    }

    private void OnDrawGizmos()
    {
        Vector2 vector2 = gameObject.transform.position;
        //赤い色で0,0,0から上に1の線を引く
        Gizmos.color = Color.red;
        for(int i = 0; i < elevatorMove.Length; i++)
        {
            float radAngle = elevatorMove[i].elevatorVector * Mathf.Deg2Rad;

            float x = elevatorMove[i].distance * Mathf.Cos(radAngle);
            float y = elevatorMove[i].distance * Mathf.Sin(radAngle);
            Gizmos.DrawLine(vector2, vector2 + new Vector2(x, y));
            vector2 += new Vector2(x, y);
        }
        lastPos = vector2;
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(moveVelocity.x, moveVelocity.y, 0.0f);

        if (condition1 == ElevatorCondition1.Wait)
        {
            if(isFollowMove)
            {
                StartCoroutine(ElevatorStop());
            }
            moveVelocity = Vector2.zero;
        }
        else if (isMove)
        {
            switch (condition2)
            {
                case ElevatorCondition2.Go:
                    StartCoroutine(ElevatorMove1());
                    break;
                case ElevatorCondition2.Come:
                    StartCoroutine(ElevatorMove2());
                    break;
                default:
                    break;
            }
        }

        //    switch (elevatorCondition)
        //{
        //    case ElevatorCondition.Down:
        //            StartCoroutine(ElevatorDown());
        //        break;
        //    case ElevatorCondition.Up:
        //            StartCoroutine(ElevatorUp());
        //        break;
        //    default:
        //            StartCoroutine(ElevatorStop());
        //            break;
        //}


    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            player.transform.SetParent(transform);
            if (condition1 == ElevatorCondition1.Wait)
            { 
                isMove = true;
                condition1 = ElevatorCondition1.Move;
                isFollowMove = true;
            }
        }
            //    switch (elevatorCondition)
            //    {
            //        case ElevatorCondition.WaitDown:
            //            elevatorCondition = ElevatorCondition.Down;
            //            isMove = true;
            //            break;
            //        case ElevatorCondition.WaitUp:
            //            elevatorCondition = ElevatorCondition.Up;
            //            isMove = true;
            //            break;
            //        case ElevatorCondition.Down:
            //            break;
            //        case ElevatorCondition.Up:
            //            break;
            //        default:
            //            break;
            //    }
            //    isFollowMove = false;
            //}

            //    if((collision.gameObject.name == "bone_7" || collision.gameObject.name == "bone_8"
            //        || collision.gameObject.name == "bone_9" || collision.gameObject.name == "bone_10") && elevator.transform.position.y >= fastPos.y && DOWN == true)
            //    {
            //        plusY = -0.01f;
            //    }
            //    if ((collision.gameObject.name == "bone_7" || collision.gameObject.name == "bone_8"
            //|| collision.gameObject.name == "bone_9" || collision.gameObject.name == "bone_10") && elevator.transform.position.y <= fastPos.y && UP == true)
            //    {
            //        plusY = 0.01f;
            //    }

    }
    //IEnumerator ElevatorUp()
    //{
    //    isMove = false;
    //    plusY = 0.01f;
    //    while (elevator.transform.position.y < fastPos.y)
    //        yield return new WaitForSeconds(0.1f);

    //    elevatorCondition = ElevatorCondition.WaitDown;
    //    yield break;
    //}

    //IEnumerator ElevatorDown()
    //{
    //    isMove = false;
    //    plusY = -0.01f;
    //    while (elevator.transform.position.y > fastPos.y - 5.0f)
    //        yield return new WaitForSeconds(0.1f);

    //    elevatorCondition = ElevatorCondition.WaitUp;
    //    yield break;
    //}
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.transform.SetParent(null);
        }
    }
    IEnumerator ElevatorMove1()
    {
        isMove = false;
        Vector2 vector2 = fastPos;
        //赤い色で0,0,0から上に1の線を引く
        for (int i = 0; i < elevatorMove.Length; i++)
        {
            float radAngle = elevatorMove[i].elevatorVector * Mathf.Deg2Rad;

            float x = elevatorMove[i].distance * Mathf.Cos(radAngle);
            float y = elevatorMove[i].distance * Mathf.Sin(radAngle);
            moveVelocity = new Vector2(x, y) / 100;
            Debug.Log(i);
            vector2 += new Vector2(x, y);
            while ((gameObject.transform.position.y) - (vector2.y) > 0.1 ||
                (gameObject.transform.position.y) - (vector2.y) < -0.1 &&
                (gameObject.transform.position.x - (vector2.x)) > 0.1 ||
                (gameObject.transform.position.x - (vector2.x)) < -0.1)
            {
                yield return new WaitForSeconds(0.1f);
            }
            //Gizmos.DrawLine(vector2, vector2 + new Vector2(x, y));
            gameObject.transform.position = vector2;
        }
        condition1 = ElevatorCondition1.Wait;
        condition2 = ElevatorCondition2.Come;
        yield break;
    }
    IEnumerator ElevatorMove2()
    {
        isMove = false;
        Vector2 vector2 = lastPos;
        //赤い色で0,0,0から上に1の線を引く
        for (int i = elevatorMove.Length; i > 1; i--)
        {
            float radAngle = elevatorMove[i].elevatorVector * Mathf.Deg2Rad;

            float x = elevatorMove[i].distance * Mathf.Cos(radAngle);
            float y = elevatorMove[i].distance * Mathf.Sin(radAngle);
            moveVelocity = (vector2 - new Vector2(x, y)) / 100;
            Debug.Log(i);
            vector2 += new Vector2(x, y);
            while ((gameObject.transform.position.y) - (vector2.y) > 0.1 ||
                (gameObject.transform.position.y) - (vector2.y) < -0.1 &&
                (gameObject.transform.position.x - (vector2.x)) > 0.1 ||
                (gameObject.transform.position.x - (vector2.x)) < -0.1)
            {
                yield return new WaitForSeconds(0.1f);
            }
            //Gizmos.DrawLine(vector2, vector2 + new Vector2(x, y));
        }
        moveVelocity = Vector2.zero;
        condition1 = ElevatorCondition1.Wait;
        condition2 = ElevatorCondition2.Go;

        yield break;
    }

    IEnumerator ElevatorStop()
    {
        isFollowMove = false;

        for (int i = 0; i < 10; i++)
            yield return new WaitForSeconds(0.1f);

        isFollowMove = true;
        yield break;
    }
}
