using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenScriot : MonoBehaviour
{
    public GameObject bs;
    public NinjaScript ninja;
    public GameObject ninjaG;
    public AudioSource dragon;
    public bool changeScene = false;
    public AudioSource blackHole;
    public bool played = false;
    public GameObject hudText;

    void Update()
    {
        if (ninja.endAnimation == true && ninjaG.transform.position.x > 2 && played == false)
        {
            bs.SetActive(true);
            hudText.SetActive(true);
            blackHole.Stop();
            dragon.Play();
            changeScene = true;
            played = true;

        }

        if (ninja.endAnimation)
        {
            ninja.levelUp = true;
        }
    }
}
