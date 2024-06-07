using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpHUD : MonoBehaviour
{
    public Image Filler;
    public Text hudText;
    public NinjaScript ninja;

    void Update()
    {
        float hp = (float)ninja.pv;
        float pvmax = (float)ninja.pvmax;
        hudText.text = hp.ToString();

        float ratio = hp / pvmax;
        Filler.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }
}