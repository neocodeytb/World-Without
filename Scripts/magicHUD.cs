using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class magicHUD : MonoBehaviour
{
    public Text hudText;
    public NinjaScript ninja;

    void Update()
    {
        int nMagic = ninja.nMagic;
        hudText.text = nMagic.ToString();
    }
}
