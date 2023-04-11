using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageManager : MonoBehaviour
{
    public GameObject objGage, objText;
    private Image imageGage;
    private Text text;
    private int maxGa, Gage;

    // Start is called before the first frame update
    void Start()
    {
        imageGage = objGage.GetComponent<Image>();
        text = objText.GetComponent<Text>();
    }

    public int GAGE
    {
        set { Gage = value; }
    }

    public int MAXGAGE
    {
        set { maxGa = value; }
    }

    // Update is called once per frame
    void Update()
    {
        imageGage.fillAmount = (float)Gage / maxGa;
        text.text = Gage.ToString();
    }
}
