using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBound : MonoBehaviour
{
    [SerializeField]
    private GameObject FireObject;
    Vector2 startPos;
    Vector2 speed;
    private bool isFire; 
    // Start is called before the first frame update
    void Start()
    {
        isFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // マウスを話した座標
            Vector2 endPos = Input.mousePosition;
            //float swipeLengthX = endPos.x - this.startPos.x;
            //float swipeLengthY = endPos.y - this.startPos.x;
            Vector2 swipeLength = endPos - startPos;

            // スワイプの長さを初速度に変換する
            speed = swipeLength / 500.0f;
            speed *= -1;
            //this.speedX = swipeLengthX / 500.0f;
            ////if(swipeLengthX <= 0)
            ////{
            //this.speedX *= -1;
            ////}
            //this.speedY = swipeLengthY / 500.0f;
            ////if (swipeLengthY <= 0)
            ////{
            //this.speedY *= -1;
            ////}

            // 効果音再生
            //GetComponent<AudioSource>().Play();
            isFire = true;
        }
        if(isFire)
        {
            GameObject game = Instantiate(FireObject, transform.position, Quaternion.identity);
            StartCoroutine(DoSmole());
            StartCoroutine(DoMove(game));
            Destroy(game, 6.0f);
            isFire = false;
        }

        //transform.Translate(this.speedX, this.speedY, 0);
        //this.speedX *= 0.98f;
        //this.speedY *= 0.98f;

    }

    private IEnumerator DoMove(GameObject game)
    {
        Vector2 preSpeed = speed;
        while(true)
        {
            game.transform.Translate(preSpeed.x, preSpeed.y, 0);
            preSpeed.x *= 0.98f;
            preSpeed.y *= 0.98f;

            yield return new WaitForSeconds(0.01f);

        }

    }

    private IEnumerator DoSmole()
    {
        for(int i = 0; i < 10; i++)
        {
            transform.localScale *= 0.9999f;

            yield return new WaitForSeconds(0.01f);
        }
    }
}
