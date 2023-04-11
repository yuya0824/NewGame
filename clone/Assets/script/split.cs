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
    [SerializeField]
    private int waterMaxSpown;

    private int spownMath;

    private Character chara;
    //private GameObject[] cloneObject;

    [SerializeField]
    private LayerMask layer;
    [SerializeField]
    private LayerMask layer2;

    [SerializeField]
    private bool debug1 = false;

    private GroundCheck2D[] miniObj;
    // Start is called before the first frame update
    void Start()
    {
        character.transform.localScale = new Vector3(miniSize, miniSize, 1.0f);
        spownMath = 0;
        chara = gameObject.GetComponent<Character>();
        //cloneObject = new GameObject[maxSpown];
        //for(int i = 0; i < maxSpown; i++)
        //{
        //    cloneObject[i] = character;
        //}
        miniObj = GetChildren(this.gameObject.transform);

    }

    // Update is called once per frame
    void Update()
    {
        // �X�|�[������ɖ������Ă��Ȃ��ꍇ�̂ݓ���\
        if(maxSpown > spownMath)
        {
            SpownSlime();
        }
        // ���������I�u�W�F�N�g�̍폜�ƁA�T�C�Y�ύX
        if(Input.GetKeyDown(KeyCode.Return) && parentObj.HasChild() && debug1)
        {
            Destroy(parentObj.transform.GetChild(0).gameObject);
            miniSize *= 1.0f / 0.9f;
            gameObject.transform.localScale = new Vector3(miniSize, miniSize, 1.0f);
            spownMath--;
        }
        //LayerMask layerMask = 3;

        for(int i = 0; i< miniObj.Length; i++)
        {
            if (miniObj[i].CheckGroundStatus(layer2))
                IsWater();

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
            float spownPosY = 0.0f;
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector3.up, -1.5f, layer);
            if (/*chara.IsDoJump() || */hit)
            {
                spownPosY = 3.0f;
                Debug.DrawRay(transform.position, Vector3.up * -1.0f, Color.yellow);
                Debug.Log(hit.distance);
            }
            else
            {
                spownPosY = -1.0f;
                Debug.DrawRay(transform.position, Vector3.up * -1.0f, Color.green);
            }

            GameObject obj = Instantiate(character, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + spownPosY, gameObject.transform.position.z), Quaternion.identity);
            miniSize *= 0.9f;
            obj.transform.localScale = new Vector3(miniSize, miniSize, 1.0f);
            // �^�O�t��
            obj.tag = "Spowns";
            // �q�I�u�W�F�N�g��
            obj.transform.SetParent(parentObj.transform);
            // �T�C�Y�ύX
            gameObject.transform.localScale = new Vector3(miniSize, miniSize, 1.0f);
            spownMath++;
        }

    }

    public void SetSpownMath(int spown)
    {
        spownMath = spown;
    }

    public int GetSpownMath()
    {
        return spownMath;
    }

    public int GetMaxSpown()
    {
        return maxSpown;
    }

    private void IsWater()
    {
            Debug.Log(1);
            maxSpown = waterMaxSpown;
            miniSize = 1;
            character.transform.localScale = new Vector3(miniSize, miniSize, 1.0f);
            spownMath = 0;
            if (parentObj.HasChild())
            {
                //Destroy(parentObj.transform.gameObject);
                foreach (Transform c in parentObj.transform)
                {
                    GameObject.Destroy(c.gameObject);
                }
        }
    }

    public GroundCheck2D[] GetChildren(Transform parent)
    {
        // �q�I�u�W�F�N�g���i�[����z��쐬
        var children = new GroundCheck2D[parent.childCount];

        // 0�`��-1�܂ł̎q�����Ԃɔz��Ɋi�[
        for (var i = 0; i < children.Length; ++i)
        {
            children[i] = parent.GetChild(i).gameObject.GetComponent<GroundCheck2D>();
        }

        // �q�I�u�W�F�N�g���i�[���ꂽ�z��
        return children;
    }
}

/// <summary>
/// GameObject �^�̊g�����\�b�h���Ǘ�����N���X
/// </summary>
public static partial class GameObjectExtensions
{
    public static bool HasChild(this GameObject gameObject)
    {
        return 0 < gameObject.transform.childCount;
    }
}

/// <summary>
/// Transform �^�̊g�����\�b�h���Ǘ�����N���X
/// </summary>
public static partial class TransformExtensions
{
    public static bool HasChild(this Transform transform)
    {
        return 0 < transform.childCount;
    }
}