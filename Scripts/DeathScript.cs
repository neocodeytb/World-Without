using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public GameObject redscreen;
    public NinjaScript ninja;
    private float dt;
    public GameObject text;
    public AudioSource deathSound;
    private bool played = false;

    void Awake()
    {

        text.SetActive(false);
        redscreen.SetActive(false);
        dt = 0.0f;
    }

    void Update()
    {
        bool death = ninja.isDead;
        if (death)
        {
            if (!played)
            {
                deathSound.Play();
                played = true;
            }

            text.SetActive(true);
            redscreen.SetActive(true);
            dt += Time.deltaTime;

            if (dt > 3.5f)
            {
                SceneManager.LoadScene("Menu");
            }

        }
    }
}
