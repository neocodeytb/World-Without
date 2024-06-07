using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bloodHUD : MonoBehaviour
{
    public Text hudText;
    public NinjaScript ninja;

    void Update()
    {
        int nBlood = ninja.nBlood;
        hudText.text = nBlood.ToString();
    }
}