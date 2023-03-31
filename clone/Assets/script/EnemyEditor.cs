using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyParam")]
public class EnemyEditor : ScriptableObject
{
    [SerializeField, Range(1, 10)]
    private int maxHP;
    [SerializeField]
    private GameObject gameObject;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
