using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVLHUD : MonoBehaviour
{
    public Text hudText;
    public NinjaScript ninja;

    void Update()
    {
        int lvl = ninja.level;
        hudText.text = "LVL " + lvl.ToString();
    }
}