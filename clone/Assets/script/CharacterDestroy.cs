using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDestroy : MonoBehaviour
{
    private GameObject Object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Destroy")
        {
            split sp = Object.GetComponent<split>();
            sp.SizeUp();
            Destroy(gameObject);
        }
    }
    public void SetObject(GameObject gameObj)
    {
        Object = gameObj;
    }
}
