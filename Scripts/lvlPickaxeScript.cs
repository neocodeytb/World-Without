using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvlPickaxeScript : MonoBehaviour
{
    public Text hudText;
    public NinjaScript ninja;

    public Text nStoneT;
    public Text nWoodT;

    public GameObject pickaxe;

    public AudioSource buy;

    public void Upgrade()
    {
        if (ninja.lvlpickaxe == 0)
        {
            if (ninja.nWood >= 2 && ninja.nStone >= 2)
            {
                ninja.lvlpickaxe += 1;
                ninja.nWood -= 2;
                ninja.nStone -= 2;
                pickaxe.SetActive(true);
                ninja.nHitsMax -= 1;
                buy.Play();

            }

        }

        if (ninja.lvlpickaxe == 1)
        {
            if (ninja.nWood >= 3 && ninja.nStone >= 3)
            {
                ninja.lvlpickaxe += 1;
                ninja.nWood -= 3;
                ninja.nStone -= 3;

                buy.Play();

            }

        }

        if (ninja.lvlpickaxe == 2)
        {
            if (ninja.nWood >= 4 && ninja.nStone >= 5)
            {
                ninja.lvlpickaxe += 1;
                ninja.nWood -= 4;
                ninja.nStone -= 5;

                buy.Play();

            }

        }

        if (ninja.lvlpickaxe == 3)
        {
            if (ninja.nWood >= 6 && ninja.nStone >= 8)
            {
                ninja.lvlpickaxe += 1;
                ninja.nWood -= 6;
                ninja.nStone -= 8;

                buy.Play();

            }

        }

        if (ninja.lvlpickaxe == 4)
        {
            if (ninja.nWood >= 8 && ninja.nStone >= 10)
            {
                ninja.lvlpickaxe += 1;
                ninja.nWood -= 8;
                ninja.nStone -= 10;

                buy.Play();

            }

        }

        if (ninja.lvlpickaxe == 5)
        {
            if (ninja.nWood >= 10 && ninja.nStone >= 15)
            {
                ninja.lvlpickaxe += 1;
                ninja.nWood -= 10;
                ninja.nStone -= 15;

                buy.Play();

            }

        }
    }

    void Start()
    {
        pickaxe.SetActive(false);
    }

    void Update()
    {
        int LvlPickaxe = ninja.lvlpickaxe;
        hudText.text = "LVL " + LvlPickaxe.ToString();

        int nWood = ninja.nWood;
        int nStone = ninja.nStone;
        int nMagic = ninja.nMagic;
        int nBlood = ninja.nBlood;
        int nRubis = ninja.nRubis;

        if (ninja.lvlpickaxe == 0)
        {
            if (ninja.nWood < 2 || ninja.nStone < 2)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nWoodT.text = 2.ToString();
            nStoneT.text = 2.ToString();


            if (ninja.nWood < 2)
            {
                nWoodT.color = Color.red;
            }
            else
            { 
                nWoodT.color = Color.red;
            }

            if (ninja.nStone < 2)
            {
                nStoneT.color = Color.red;
            }
            else
            {
                nStoneT.color = Color.red;
            }

            
        }

        if (ninja.lvlpickaxe == 1)
        {
            if (ninja.nWood < 3 || ninja.nStone < 3)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nWoodT.text = 3.ToString();
            nStoneT.text = 3.ToString();

            if (ninja.nWood < 3)
            {
                nWoodT.color = Color.red;
            }
            else
            {
                nWoodT.color = Color.red;
            }

            if (ninja.nStone < 3)
            {
                nStoneT.color = Color.red;
            }
            else
            {
                nStoneT.color = Color.red;
            }
        }

        if (ninja.lvlpickaxe == 2)
        {
            if (ninja.nWood < 4 || ninja.nStone < 5)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nWoodT.text = 4.ToString();
            nStoneT.text = 5.ToString();

            if (ninja.nWood < 4)
            {
                nWoodT.color = Color.red;
            }
            else
            {
                nWoodT.color = Color.red;
            }

            if (ninja.nStone < 5)
            {
                nStoneT.color = Color.red;
            }
            else
            {
                nStoneT.color = Color.red;
            }
        }

        if (ninja.lvlpickaxe == 3)
        {
            if (ninja.nWood < 6 || ninja.nStone < 8)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nWoodT.text = 6.ToString();
            nStoneT.text = 8.ToString();

            if (ninja.nWood < 6)
            {
                nWoodT.color = Color.red;
            }
            else
            {
                nWoodT.color = Color.red;
            }

            if (ninja.nStone < 8)
            {
                nStoneT.color = Color.red;
            }
            else
            {
                nStoneT.color = Color.red;
            }
        }

        if (ninja.lvlpickaxe == 4)
        {
            if (ninja.nWood < 8 || ninja.nStone < 10)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nWoodT.text = 8.ToString();
            nStoneT.text = 10.ToString();

            if (ninja.nWood < 8)
            {
                nWoodT.color = Color.red;
            }
            else
            {
                nWoodT.color = Color.red;
            }

            if (ninja.nStone < 10)
            {
                nStoneT.color = Color.red;
            }
            else
            {
                nStoneT.color = Color.red;
            }
        }

        if (ninja.lvlpickaxe == 5)
        {
            if (ninja.nWood < 10 || ninja.nStone < 15)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nWoodT.text = 10.ToString();
            nStoneT.text = 15.ToString();

            if (ninja.nWood < 10)
            {
                nWoodT.color = Color.red;
            }
            else
            {
                nWoodT.color = Color.red;
            }

            if (ninja.nStone < 15)
            {
                nStoneT.color = Color.red;
            }
            else
            {
                nStoneT.color = Color.red;
            }
        }

        if (ninja.lvlpickaxe == 6)
        {
            hudText.color = Color.magenta;

            nWoodT.text = "X";
            nStoneT.text = "X";
            nWoodT.color = Color.magenta;
            nStoneT.color = Color.magenta;

        }
    }
}
