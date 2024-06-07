using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class lvlAxeScript : MonoBehaviour
{

    public Text hudText;
    public NinjaScript ninja;

    public Text nMagicT;
    public Text nWoodT;

    public GameObject axe;
    public AudioSource buy;

    void Start()
    {
        axe.SetActive(false);
    }

    public void Upgrade()
    {
        if (ninja.lvlaxe == 0)
        {
            if (ninja.nWood >= 2 && ninja.nMagic >= 1)
            {
                ninja.lvlaxe += 1;
                ninja.nWood -= 2;
                ninja.nMagic -= 1;
                axe.SetActive(true);
                buy.Play();
                ninja.nHitsMax -= 1;

            }

        }

        if (ninja.lvlaxe == 1)
        {
            if (ninja.nWood >= 4 && ninja.nMagic >= 2)
            {
                ninja.lvlaxe += 1;
                ninja.nWood -= 4;
                ninja.nMagic -= 2;
                buy.Play();

            }
        }

        if (ninja.lvlaxe == 2)
        {
            if (ninja.nWood >= 6 && ninja.nMagic >= 3)
            {
                ninja.lvlaxe += 1;
                ninja.nWood -= 6;
                ninja.nMagic -= 3;
                buy.Play();

            }
        }

        if (ninja.lvlaxe == 3)
        {
            if (ninja.nWood >= 8 && ninja.nMagic >= 4)
            {
                ninja.lvlaxe += 1;
                ninja.nWood -= 8;
                ninja.nMagic -= 4;
                buy.Play();

            }
        }

        if (ninja.lvlaxe == 4)
        {
            if (ninja.nWood >= 12 && ninja.nMagic >= 5)
            {
                ninja.lvlaxe += 1;
                ninja.nWood -= 12;
                ninja.nMagic -= 5;
                buy.Play();

            }
        }

        if (ninja.lvlaxe == 5)
        {
            if (ninja.nWood >= 18 && ninja.nMagic >= 6)
            {
                ninja.lvlaxe += 1;
                ninja.nWood -= 18;
                ninja.nMagic -= 6;
                buy.Play();

            }
        }
    }
    void Update()
    {
        int LvlAxe = ninja.lvlaxe;
        hudText.text = "LVL " + LvlAxe.ToString();

        int nWood = ninja.nWood;
        int nStone = ninja.nStone;
        int nMagic = ninja.nMagic;
        int nBlood = ninja.nBlood;
        int nRubis = ninja.nRubis;

        if (ninja.lvlaxe == 0)
        {
            if (ninja.nWood < 2 || ninja.nMagic < 1)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nWoodT.text = 2.ToString();
            nMagicT.text = 1.ToString();

            if (ninja.nWood < 2)
            {
                nWoodT.color = Color.red;
            }
            else
            {
                nWoodT.color = Color.red;
            }

            if (ninja.nMagic < 1)
            {
                nMagicT.color = Color.red;
            }
            else
            {
                nMagicT.color = Color.red;
            }

        }

        if (ninja.lvlaxe == 1)
        {
            if (ninja.nWood < 4 || ninja.nMagic < 2)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nWoodT.text = 4.ToString();
            nMagicT.text = 2.ToString();

            if (ninja.nWood < 4)
            {
                nWoodT.color = Color.red;
            }
            else
            {
                nWoodT.color = Color.red;
            }

            if (ninja.nMagic < 2)
            {
                nMagicT.color = Color.red;
            }
            else
            {
                nMagicT.color = Color.red;
            }
        }

        if (ninja.lvlaxe == 2)
        {
            if (ninja.nWood < 6 || ninja.nMagic < 3)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nWoodT.text = 6.ToString();
            nMagicT.text = 3.ToString();

            if (ninja.nWood < 6)
            {
                nWoodT.color = Color.red;
            }
            else
            {
                nWoodT.color = Color.red;
            }

            if (ninja.nMagic < 3)
            {
                nMagicT.color = Color.red;
            }
            else
            {
                nMagicT.color = Color.red;
            }
        }

        if (ninja.lvlaxe == 3)
        {
            if (ninja.nWood < 8 || ninja.nMagic < 4)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nWoodT.text = 8.ToString();
            nMagicT.text = 4.ToString();

            if (ninja.nWood < 8)
            {
                nWoodT.color = Color.red;
            }
            else
            {
                nWoodT.color = Color.red;
            }

            if (ninja.nMagic < 4)
            {
                nMagicT.color = Color.red;
            }
            else
            {
                nMagicT.color = Color.red;
            }
        }

        if (ninja.lvlaxe == 4)
        {
            if (ninja.nWood < 12 || ninja.nMagic < 5)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nWoodT.text = 12.ToString();
            nMagicT.text = 5.ToString();

            if (ninja.nWood < 12)
            {
                nWoodT.color = Color.red;
            }
            else
            {
                nWoodT.color = Color.red;
            }

            if (ninja.nMagic < 5)
            {
                nMagicT.color = Color.red;
            }
            else
            {
                nMagicT.color = Color.red;
            }
        }

        if (ninja.lvlaxe == 5)
        {
            if (ninja.nWood < 18 || ninja.nMagic < 6)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nWoodT.text = 18.ToString();
            nMagicT.text = 6.ToString();

            if (ninja.nWood < 18)
            {
                nWoodT.color = Color.red;
            }
            else
            {
                nWoodT.color = Color.red;
            }

            if (ninja.nMagic < 6)
            {
                nMagicT.color = Color.red;
            }
            else
            {
                nMagicT.color = Color.red;
            }
        }

        if (ninja.lvlaxe == 6)
        {
            hudText.color = Color.magenta;

            nWoodT.text = "X";
            nMagicT.text = "X";
            nWoodT.color = Color.magenta;
            nMagicT.color = Color.magenta;

        }
    }
}
