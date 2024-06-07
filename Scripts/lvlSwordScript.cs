using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvlSwordScript : MonoBehaviour
{
    public Text hudText;
    public NinjaScript ninja;

    public Text nStoneT;
    public Text nMagicT;
    public Text nBloodT;

    public GameObject sword;

    public TrailRenderer trail1;
    public TrailRenderer trail2;
    public TrailRenderer trail3;

    public AudioSource buy;

    public slasherScript slasher1;
    public slasherScript slasher2;
    public slasherScript slasher3;

    public void Upgrade()
    {
        if (ninja.lvlsword == 0)
        {
            if (ninja.nStone >= 3 && ninja.nMagic >= 1 && ninja.nBlood >= 5)
            {
                ninja.lvlsword += 1;
                ninja.nStone -= 3;
                ninja.nMagic -= 1;
                ninja.nBlood -= 5;
                sword.SetActive(true);

                TrailRenderer t1 = trail1.GetComponent<TrailRenderer>();
                t1.material.color = Color.yellow;
                TrailRenderer t2 = trail2.GetComponent<TrailRenderer>();
                t2.material.color = Color.yellow;
                TrailRenderer t3 = trail3.GetComponent<TrailRenderer>();
                t3.material.color = Color.yellow;
                slasher1.amplitude = 2.5f;
                slasher2.amplitude = 2.5f;
                slasher3.amplitude = 2.5f;
                ninja.distSlashing = 6;

                buy.Play();
            }
           
        }

        if (ninja.lvlsword == 1)
        {
            if (ninja.nStone >= 4 && ninja.nMagic >= 1 && ninja.nBlood >= 8)
            {
                ninja.lvlsword += 1;
                ninja.nStone -= 4;
                ninja.nMagic -= 1;
                ninja.nBlood -= 8;

                TrailRenderer t1 = trail1.GetComponent<TrailRenderer>();
                t1.material.color = Color.green;
                TrailRenderer t2 = trail2.GetComponent<TrailRenderer>();
                t2.material.color = Color.green;
                TrailRenderer t3 = trail3.GetComponent<TrailRenderer>();
                t3.material.color = Color.green;
                slasher1.amplitude = 3.0f;
                slasher2.amplitude = 3.0f;
                slasher3.amplitude = 3.0f;


                buy.Play();

            }

        }

        if (ninja.lvlsword == 2)
        {
            if (ninja.nStone >= 6 && ninja.nMagic >= 2 && ninja.nBlood >= 12)
            {
                ninja.lvlsword += 1;
                ninja.nStone -= 6;
                ninja.nMagic -= 2;
                ninja.nBlood -= 12;

                TrailRenderer t1 = trail1.GetComponent<TrailRenderer>();
                t1.material.color = Color.blue;
                TrailRenderer t2 = trail2.GetComponent<TrailRenderer>();
                t2.material.color = Color.blue;
                TrailRenderer t3 = trail3.GetComponent<TrailRenderer>();
                t3.material.color = Color.blue;
                slasher1.amplitude = 3.5f;
                slasher2.amplitude = 3.5f;
                slasher3.amplitude = 3.5f;
                ninja.distSlashing = 7;


                buy.Play();

            }

        }

        if (ninja.lvlsword == 3)
        {
            if (ninja.nStone >= 8 && ninja.nMagic >= 2 && ninja.nBlood >= 15)
            {
                ninja.lvlsword += 1;
                ninja.nStone -= 8;
                ninja.nMagic -= 2;
                ninja.nBlood -= 15;

                TrailRenderer t1 = trail1.GetComponent<TrailRenderer>();
                t1.material.color = Color.magenta;
                TrailRenderer t2 = trail2.GetComponent<TrailRenderer>();
                t2.material.color = Color.magenta;
                TrailRenderer t3 = trail3.GetComponent<TrailRenderer>();
                t3.material.color = Color.magenta;
                slasher1.amplitude = 4.0f;
                slasher2.amplitude = 4.0f;
                slasher3.amplitude = 4.0f;


                buy.Play();

            }

        }

        if (ninja.lvlsword == 4)
        {
            if (ninja.nStone >= 11 && ninja.nMagic >= 3 && ninja.nBlood >= 18)
            {
                ninja.lvlsword += 1;
                ninja.nStone -= 11;
                ninja.nMagic -= 3;
                ninja.nBlood -= 18;

                TrailRenderer t1 = trail1.GetComponent<TrailRenderer>();
                t1.material.color = Color.red;
                TrailRenderer t2 = trail2.GetComponent<TrailRenderer>();
                t2.material.color = Color.red;
                TrailRenderer t3 = trail3.GetComponent<TrailRenderer>();
                t3.material.color = Color.red;
                slasher1.amplitude = 4.5f;
                slasher2.amplitude = 4.5f;
                slasher3.amplitude = 4.5f;
                ninja.distSlashing = 8;



                buy.Play();

            }

        }

        if (ninja.lvlsword == 5)
        {
            if (ninja.nStone >= 15 && ninja.nMagic >= 4 && ninja.nBlood >= 30)
            {
                ninja.lvlsword += 1;
                ninja.nStone -= 15;
                ninja.nMagic -= 4;
                ninja.nBlood -= 30;

                TrailRenderer t1 = trail1.GetComponent<TrailRenderer>();
                t1.material.color = Color.black;
                TrailRenderer t2 = trail2.GetComponent<TrailRenderer>();
                t2.material.color = Color.black;
                TrailRenderer t3 = trail3.GetComponent<TrailRenderer>();
                t3.material.color = Color.black;
                slasher1.amplitude = 5.0f;
                slasher2.amplitude = 5.0f;
                slasher3.amplitude = 5.0f;
                ninja.distSlashing = 9;


                buy.Play();

            }

        }
    }

    void Start()
    {
        sword.SetActive(false);
    }

    void Update()
    {
        int LvlSword = ninja.lvlsword;
        hudText.text = "LVL " + LvlSword.ToString();

        int nWood = ninja.nWood;
        int nStone = ninja.nStone;
        int nMagic = ninja.nMagic;
        int nBlood = ninja.nBlood;
        int nRubis = ninja.nRubis;

        if (ninja.lvlsword == 0)
        {
            if (ninja.nStone < 3 || ninja.nMagic < 1 || ninja.nBlood < 5)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nStoneT.text = 3.ToString();
            nMagicT.text = 1.ToString();
            nBloodT.text = 5.ToString();

            if (ninja.nStone < 3)
            {
                nStoneT.color = Color.red;
            }
            else
            {
                nStoneT.color = Color.red;
            }

            if (ninja.nMagic < 1)
            {
                nMagicT.color = Color.red;
            }
            else
            {
                nMagicT.color = Color.red;
            }

            if (ninja.nBlood < 5)
            {
                nBloodT.color = Color.red;
            }
            else
            {
                nBloodT.color = Color.red;
            }


        }

        if (ninja.lvlsword == 1)
        {
            if (ninja.nStone < 4 || ninja.nMagic < 1 || ninja.nBlood < 8)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nStoneT.text = 4.ToString();
            nMagicT.text = 1.ToString();
            nBloodT.text = 8.ToString();

            if (ninja.nStone < 4)
            {
                nStoneT.color = Color.red;
            }
            else
            {
                nStoneT.color = Color.red;
            }

            if (ninja.nMagic < 1)
            {
                nMagicT.color = Color.red;
            }
            else
            {
                nMagicT.color = Color.red;
            }

            if (ninja.nBlood < 8)
            {
                nBloodT.color = Color.red;
            }
            else
            {
                nBloodT.color = Color.red;
            }
        }

        if (ninja.lvlsword == 2)
        {
            if (ninja.nStone < 6 || ninja.nMagic < 2 || ninja.nBlood < 12)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nStoneT.text = 6.ToString();
            nMagicT.text = 2.ToString();
            nBloodT.text = 12.ToString();

            if (ninja.nStone < 6)
            {
                nStoneT.color = Color.red;
            }
            else
            {
                nStoneT.color = Color.red;
            }

            if (ninja.nMagic < 2)
            {
                nMagicT.color = Color.red;
            }
            else
            {
                nMagicT.color = Color.red;
            }

            if (ninja.nBlood < 12)
            {
                nBloodT.color = Color.red;
            }
            else
            {
                nBloodT.color = Color.red;
            }
        }

        if (ninja.lvlsword == 3)
        {
            if (ninja.nStone < 8 || ninja.nMagic < 2 || ninja.nBlood < 15)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nStoneT.text = 8.ToString();
            nMagicT.text = 2.ToString();
            nBloodT.text = 15.ToString();

            if (ninja.nStone < 8)
            {
                nStoneT.color = Color.red;
            }
            else
            {
                nStoneT.color = Color.red;
            }

            if (ninja.nMagic < 2)
            {
                nMagicT.color = Color.red;
            }
            else
            {
                nMagicT.color = Color.red;
            }

            if (ninja.nBlood < 15)
            {
                nBloodT.color = Color.red;
            }
            else
            {
                nBloodT.color = Color.red;
            }
        }

        if (ninja.lvlsword == 4)
        {
            if (ninja.nStone < 11 || ninja.nMagic < 3 || ninja.nBlood < 18)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nStoneT.text = 11.ToString();
            nMagicT.text = 3.ToString();
            nBloodT.text = 18.ToString();

            if (ninja.nStone < 11)
            {
                nStoneT.color = Color.red;
            }
            else
            {
                nStoneT.color = Color.red;
            }

            if (ninja.nMagic < 3)
            {
                nMagicT.color = Color.red;
            }
            else
            {
                nMagicT.color = Color.red;
            }

            if (ninja.nBlood < 18)
            {
                nBloodT.color = Color.red;
            }
            else
            {
                nBloodT.color = Color.red;
            }
        }

        if (ninja.lvlsword == 5)
        {
            if (ninja.nStone < 15 || ninja.nMagic < 4 || ninja.nBlood < 30)
            {
                hudText.color = Color.red;
            }
            else
            {
                hudText.color = Color.green;

            }

            nStoneT.text = 15.ToString();
            nMagicT.text = 4.ToString();
            nBloodT.text = 30.ToString();

            if (ninja.nStone < 15)
            {
                nStoneT.color = Color.red;
            }
            else
            {
                nStoneT.color = Color.red;
            }

            if (ninja.nMagic < 4)
            {
                nMagicT.color = Color.red;
            }
            else
            {
                nMagicT.color = Color.red;
            }

            if (ninja.nBlood < 30)
            {
                nBloodT.color = Color.red;
            }
            else
            {
                nBloodT.color = Color.red;
            }
        }

        if (ninja.lvlsword == 6)
        {
            hudText.color = Color.magenta;

            nBloodT.text = "X";
            nStoneT.text = "X";
            nMagicT.text = "X";
            nBloodT.color = Color.magenta;
            nStoneT.color = Color.magenta;
            nMagicT.color = Color.magenta;


        }
    }
}
