using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsClonePlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject character;

    [SerializeField]
    private GameObject player;

    private bool isPush;
    private bool isCloneObj;
    // Start is called before the first frame update
    void Start()
    {
        isCloneObj = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPush = !isPush;
            isCloneObj = true;
            //character.transform.localScale *= new Vector2(0.8f, 0.8f);
        }
        if(isCloneObj)
        {

        if(isPush)
        {
                foreach (Transform child in this.transform)
                {
                    // ˆê‚Â‚¸‚Â”jŠü‚·‚é
                    Destroy(child.gameObject);
                }
                GameObject @object2 = (GameObject)Instantiate(player, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z), Quaternion.identity);
                @object2.transform.parent = gameObject.transform;
                for (int i = 0; i < 10; i++)
                {
                    GameObject @object1 = (GameObject)Instantiate(character, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z), Quaternion.identity);
                    @object1.transform.parent = gameObject.transform;
                }

                //Destroy(@object2);
                isCloneObj = false;
        }
        else
        {
                foreach (Transform child in this.transform)
                {
                    // ˆê‚Â‚¸‚Â”jŠü‚·‚é
                    Destroy(child.gameObject);
                }
                GameObject @object2 = (GameObject)Instantiate(player, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z), Quaternion.identity);
                @object2.transform.parent = gameObject.transform;

                //Destroy(@object1);
                isCloneObj = false;
        }
        }

    }
}
