using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageManager : MonoBehaviour
{
    [SerializeField]
    private split spl;
    public GameObject objGage;
    private int cageMath;
    // Start is called before the first frame update
    void Start()
    {
        cageMath = spl.GetSpownMath();
    }
    // Update is called once per frame
    void Update()
    {
        //if(cageMath < spl.GetSpownMath())
        //{
        //    Gage();
        //    cageMath++;
        //}
        //else if(cageMath > spl.GetSpownMath())
        //{
        //    UpGage();
        //    cageMath--;
        //}
        this.objGage.GetComponent<Image>().fillAmount = ((float)(spl.GetMaxSpown() - spl.GetSpownMath()) / (float)spl.GetMaxSpown());
    }

    void Gage()
    {
        this.objGage.GetComponent<Image>().fillAmount -= (float)(1.0f/spl.GetMaxSpown());
    }

    void UpGage()
    {
        this.objGage.GetComponent<Image>().fillAmount += (float)(1.0f / spl.GetMaxSpown());
    }
}
