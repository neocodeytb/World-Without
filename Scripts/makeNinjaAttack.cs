using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class makeNinjaAttack : MonoBehaviour
{

    public NinjaScript ninja;

    public void MakeNinjaAttack()
    {
        ninja.attackToggleButton = true;
    }
}

