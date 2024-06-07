using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpHUDBOSS : MonoBehaviour
{
    public Image Filler;
    public Text hudText;
    public DragonScript dragon;
    public GameObject t;
    public GameObject r;
    public GameObject f;

    void Start()
    {
        t.SetActive(false);
        r.SetActive(false);
        f.SetActive(false);

    }

    void Update()
    {
        float hp = (float)dragon.pv;
        float pvmax = (float)dragon.pvmax;
        hudText.text = hp.ToString();

        float ratio = hp / pvmax;
        Filler.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }
}