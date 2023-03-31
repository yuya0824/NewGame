using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(menuName = "EnemyParam")]
public class EnemyEditor : ScriptableObject
{
    public enum EnemyType
    {
        Type1,
        Type2,
        Type3,

        None
    };

    [System.Serializable]
    public struct EnemyManage
    {
        [/*SerializeField,*/ Range(1, 10)]
        public int maxHP/* = 1*/;
        //[SerializeField]
        public GameObject gameObject;
        //[SerializeField]
        public bool isAlive/* = false*/;


        //[SerializeField]
        public EnemyType enemyType/* = EnemyType.None*/;

    }

    [SerializeField]
    private EnemyManage enemyManage;





    //[SerializeField, EnableIf("enemyType == EnemyType.Type1")]
    //private int offspring;


    //[SerializeField, EnableIf("enemyType = Type1")]
    //private int offspring;


    // Start is called before the first frame update
    void Start()
    {
        
    }       

    // Update is called once per frame
    void Update()
    {
        
    }

    public EnemyManage GetEnemyManage()
    {
        return enemyManage;
    }
}
