using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(menuName = "EnemyParam")]
public class EnemyEditor : ScriptableObject
{
    [SerializeField, Range(1, 10)]
    private int maxHP = 1;
    [SerializeField]
    private GameObject gameObject;
    [SerializeField]
    private bool isAlive = false;

    [SerializeField, EnableIf("isAlive")]
    private int aliveLife = 0;

    //[SerializeField]
    private enum EnemyType
    {
        Type1,
        Type2,
        Type3,

        None
    };

    [SerializeField]
    private EnemyType enemyType = EnemyType.None;

    

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
}
