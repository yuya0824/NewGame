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
        // スポーン上限に満たしていない場合のみ動作可能
        if(maxSpown > spownMath)
        {
            SpownSlime();
        }
        // 生成したオブジェクトの削除と、サイズ変更
        if(Input.GetKeyDown(KeyCode.Return) && parentObj.HasChild())
        {
            Destroy(parentObj.transform.GetChild(0).gameObject);
            miniSize *= 1.0f / 0.9f;
            gameObject.transform.localScale = new Vector3(miniSize, miniSize, 1.0f);
            spownMath--;
        }
        
    }

    private void SpownSlime()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if (gameObject.transform.localScale.x >= 1.0f && gameObject.transform.localScale.y >= 1.0f && gameObject.transform.localScale.z >= 1.0f)
            //{
            //    miniSize = 0.8f;
            //}
            //character.transform.localScale *= new Vector2(0.8f, 0.8f);
            GameObject obj = Instantiate(character, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3.0f, gameObject.transform.position.z), Quaternion.identity);
            miniSize *= 0.9f;
            obj.transform.localScale = new Vector3(miniSize, miniSize, 1.0f);
            // タグ付け
            obj.tag = "Spowns";
            // 子オブジェクト化
            obj.transform.SetParent(parentObj.transform);
            // サイズ変更
            gameObject.transform.localScale = new Vector3(miniSize, miniSize, 1.0f);
            spownMath++;
        }

    }


}

/// <summary>
/// GameObject 型の拡張メソッドを管理するクラス
/// </summary>
public static partial class GameObjectExtensions
{
    public static bool HasChild(this GameObject gameObject)
    {
        return 0 < gameObject.transform.childCount;
    }
}

/// <summary>
/// Transform 型の拡張メソッドを管理するクラス
/// </summary>
public static partial class TransformExtensions
{
    public static bool HasChild(this Transform transform)
    {
        return 0 < transform.childCount;
    }
}