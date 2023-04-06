using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchON_OFF : MonoBehaviour
{
    public bool DoorOpen;
    public bool clauseDoor;

    public GameObject Charaprefab;
    public GameObject Botton;
    public GameObject Door;

    private float doorOpen;
    private float switchON;

    private Vector3 door;
    private Vector3 bottons;

    // Update is called once per frame

    void Start()
    {
        door = Door.transform.position;
        bottons = Botton.transform.position;

        doorOpen = Door.transform.position.y + 3.0f;
        switchON = Botton.transform.position.y - 0.5f;
    }

    void Update()
    {
        if (DoorOpen == true)
        {
            Door.transform.position = new Vector3(Door.transform.position.x, doorOpen, Door.transform.position.z);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name == "bone_7" || collision.gameObject.name == "bone_8"
            || collision.gameObject.name == "bone_9" || collision.gameObject.name == "bone_10") && DoorOpen == false)
        {
            Botton.transform.position = new Vector3(Botton.transform.position.x, switchON, Botton.transform.position.z);
            DoorOpen = true;
        }
        else if((collision.gameObject.name == "CharacterPrefab(Clone)") && DoorOpen == false)
        {
            Botton.transform.position = new Vector3(Botton.transform.position.z, switchON, Botton.transform.position.z);
            DoorOpen = true;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(Timestop());
        if (clauseDoor == true)
        {
            DoorOpen = false;
            Door.transform.position = door;
            Botton.transform.position = bottons;
        }
    }

    IEnumerator Timestop()
    {
        clauseDoor = false;
        yield return new WaitForSeconds(1.0f);
        clauseDoor = true;
    }
}
