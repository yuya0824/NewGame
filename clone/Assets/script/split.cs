using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class split : MonoBehaviour
{
    [SerializeField]
    private GameObject character;

    [SerializeField]
    private GameObject parentObj;

    [SerializeField, Range(0.0f, 1.0f)]
    private float miniSize = 1.0f;

    [SerializeField]
    private int maxSpown;

    private int spownMath;
    //private GameObject[] cloneObject;
    // Start is called before the first frame update
    void Start()
    {
        character.transform.localScale = new Vector3(miniSize, miniSize, 1.0f);
        spownMath = 0;
        //cloneObject = new GameObject[maxSpown];
        //for(int i = 0; i < maxSpown; i++)
        //{
        //    cloneObject[i] = character;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(maxSpown >= spownMath)
        {
            SpownSlime();
        }

        
    }

    private void SpownSlime()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameObject.transform.localScale.x >= 1.0f && gameObject.transform.localScale.y >= 1.0f && gameObject.transform.localScale.z >= 1.0f)
            {
                miniSize = 0.8f;
            }
            //character.transform.localScale *= new Vector2(0.8f, 0.8f);
            GameObject obj = Instantiate(character, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1.0f, gameObject.transform.position.z), Quaternion.identity);
            miniSize = miniSize * 0.9f;
            obj.transform.localScale = new Vector3(miniSize, miniSize, 1.0f);
            obj.tag = "Spowns";
            obj.transform.SetParent(parentObj.transform);
            gameObject.transform.localScale = new Vector3(miniSize, miniSize, 1.0f);
            spownMath++;
        }

    }
}
