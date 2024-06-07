using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class DragonScript : MonoBehaviour
{
    private Animator animator;
    public int pv = 10000;
    public int pvmax = 10000;
    public CameraBossScript cam;
    public float timePassed = 0.0f;
    public bool firstFly = false;
    public bool firstFly2 = false;

    public float walkCD = 0.0f;
    public float idleCD = 0.0f;
    public AudioSource cri;
    public bool died = false;
    public GameObject ninja;
    public float v = 2.0f;
    public float w = 8.0f;
    public bool walkmode = true;
    public bool attacking = false;
    public float attackingTime = 0.0f;
    public int attackChoice = 0;
    public bool dont = false;
    public float cdAtk1 = 0.0f;
    public float cdAtk2 = 0.0f;
    public ParticleSystem flame;
    public ParticleSystem flame2;
    public bool TickAttack1 = false;
    public bool TickAttack2 = false;
    public AudioSource flamesong;
    public AudioSource slashSound;
    public NinjaScript ninjascript;

    public AudioSource dieSong;
    public AudioSource music;
    public float dieTime = 0.0f;
    public bool made = false;
    public bool made2 = false;
    public bool stopAll = false;

    public int cpt = 0;

    public GameObject t;
    public GameObject r;
    public GameObject f;

    public GameObject ath;
    public GameObject joystickAth;
    public GameObject actionsCanvas;

    public float a = 0.0f;

    public Spawner spawner;

    void Start()
    {
        animator = GetComponent<Animator>();
        PlayAnimationAtTime("Qishilong_fly2", 63.0f);
        flame.Stop();
        flame2.Stop();


        GameObject lightGameObject = new GameObject("Directional Light");
        Light lightComp = lightGameObject.AddComponent<Light>();
        lightComp.type = LightType.Directional;
        lightComp.intensity = 0.65f;
        lightGameObject.transform.position = new Vector3(0, 10, 0);
        lightGameObject.transform.rotation = Quaternion.Euler(20, -10, 0);

    }

    void Update()
    {
        float dt = Time.deltaTime;
        timePassed += dt;

        if (died == true)
        {
            dieTime += dt;
            if (dieTime >= 15f)
            {
                PlayerPrefs.SetInt("Lvl", ninjascript.level);
                PlayerPrefs.SetInt("Exp", ninjascript.exp);
                PlayerPrefs.SetInt("PvMax", ninjascript.pvmax);
                PlayerPrefs.SetInt("lvlAxe", ninjascript.lvlaxe);
                PlayerPrefs.SetInt("lvlPickaxe", ninjascript.lvlpickaxe);
                PlayerPrefs.SetInt("lvlSword", ninjascript.lvlsword);
                PlayerPrefs.SetInt("nWood", ninjascript.nWood);
                PlayerPrefs.SetInt("nStone", ninjascript.nStone);
                PlayerPrefs.SetInt("nMagic", ninjascript.nMagic);
                PlayerPrefs.SetInt("nBlood", ninjascript.nBlood);
                PlayerPrefs.SetInt("nRubis", ninjascript.nRubis);
                PlayerPrefs.SetInt("nSteak", ninjascript.nSteak);
                PlayerPrefs.SetInt("Made", 1);
                SceneManager.LoadScene("Game");
            }
        }

        if (firstFly2 == true && died == false)
        {
            Vector3 direction = ninja.transform.position - transform.position;
            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(direction * -1f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * w);
            if (walkmode == true && attacking == false && a > 2.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, ninja.transform.position, v * Time.deltaTime);
            }
            float distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(direction.x), 2) + Mathf.Pow(Mathf.Abs(direction.z), 2));

            if (distance > 11.0f)
            {
                walkmode = true;
            }
            else
            {
                walkmode = false;
            }
        }

        if (attacking == false)
        {
            a += dt;
        }
        else
        {
            a = 0;
        }

        if (timePassed > 53.0f && made == false && died == false)
        {
            made = true;
            PlayAnimationAtTime("Qishilong_fly2", 31.36f);
            stopAll = true;
            ath.SetActive(false);
            joystickAth.SetActive(false);
            actionsCanvas.SetActive(false);
            cam.travel = true;
        }

        if (timePassed > 53.0f + 68.14f - 31.36f && made2 == false && died == false)
        {
            made2 = true;
            stopAll = false;
            ath.SetActive(true);
            joystickAth.SetActive(true);
            actionsCanvas.SetActive(true);
            cam.travel = false;
            transform.position = new Vector3(transform.position.x,0.0f,transform.position.z);
            List<GameObject> remover = new List<GameObject>();
            foreach(GameObject mob in spawner.mobs)
            {
                remover.Add(mob);
            }
            foreach(GameObject mob in remover)
            {
                spawner.mobs.Remove(mob);
                Destroy(mob);
            }
            attacking = false;
            attackingTime = 5.0f;
            ninjascript.pv = ninjascript.pvmax;

        }

        if (stopAll == true)
        {
            if (timePassed > 53.0f + 2.0f && timePassed < 53.0f + 68.14f - 31.36f - 2.0f)
            {
                if (timePassed <= 53.0f + (68.14f - 31.36f) / 2f)
                {
                    transform.position += Vector3.up * 20f * Time.deltaTime;
                }
                else
                {
                    transform.position -= Vector3.up * 20f * Time.deltaTime;
                }
            }
            
        }

        if (firstFly == false && died == false)
        {
            if (timePassed > 68.14f - 63.0f)
            {
                firstFly = true;
                cam.tremblements = true;
                PlayAnimationAtTime("Qishilong_skill02", 73.2f);
                cri.Play();
            }
        }
        else if (stopAll == false && died == false)
        {
            if (timePassed < 79.02f - 73.2f + 68.14f - 63.0f - 0.7f && cam.tremblementsCd <= 0.0f && timePassed > 79.02f - 73.2f + 68.14f - 63.0f - 4.1f)
            {
                cam.tremblements = true;
            }

            if (timePassed > 79.02f - 73.2f + 68.14f - 63.0f && firstFly2 == false)
            {
                firstFly2 = true;
                PlayAnimationAtTime("Qishilong_walk", 134.06f);

                t.SetActive(true);
                r.SetActive(true);
                f.SetActive(true);
            }

            if (firstFly2 == true)
            {
                if (died == false)
                {

                    attackingTime += dt;
                    if (attackingTime > 8.0f)
                    {
                        attacking = true;
                        attackingTime = 0.0f;
                        walkCD = 0.0f;
                        idleCD = 0.0f;
                        attackChoice = Random.Range(1, 3);
                        dont = false;
                        cdAtk1 = 0.0f;
                        cdAtk2 = 0.0f;
                        walkmode = false;
                        TickAttack1 = false;
                        TickAttack2 = false;

                    }

                    if (attacking)
                    {

                        if (attackChoice == 1)
                        {
                            if (dont == false)
                            {
                                PlayAnimationAtTime("Qishilong_skill09", 98.04f);
                                flamesong.Play();
                                dont = true;
                            }
                            else
                            {
                                cdAtk1 += dt;
                                if (cdAtk1 > 103.40 - 98.04)
                                {
                                    attacking = false;
                                }
                                if (cdAtk1 > 99.45 - 98.04 +0.3 && TickAttack1 == false)
                                {
                                    TickAttack1 = true;
                                    flame.Play();
                                    flame2.Play();

                                }
                                if (cdAtk1 > 99.45 - 98.04 + 0.3 && cdAtk1 < 99.45 - 98.04 + 0.3 + 2.0f)
                                {
                                    float dx = transform.position.x - ninja.transform.position.x;
                                    float dy = transform.position.z - ninja.transform.position.z;
                                    float dist = Mathf.Sqrt(dx * dx + dy * dy);
                                    if (dist > 8f)
                                    {
                                        cpt += 1;
                                        if (cpt > 5)
                                        {
                                            ninjascript.pv -= 1;
                                            cpt = 0;
                                        }
                                    }
                                }

                                

                            }
                        }
                        else
                        {
                            if (dont == false)
                            {
                                PlayAnimationAtTime("Qishilong_skill11", 115.06f);
                                dont = true;
                            }
                            else
                            {
                                cdAtk2 += dt;
                                if (cdAtk2 > 118f - 115.06f - 1f)
                                {
                                    attacking = false;
                                }
                                if (cdAtk2 > 116.14f - 115.06f && TickAttack2 == false)
                                {
                                    TickAttack2 = true;
                                    slashSound.Play();
                                    float dx = transform.position.x - ninja.transform.position.x;
                                    float dy = transform.position.z - ninja.transform.position.z;
                                    float dist = Mathf.Sqrt(dx * dx + dy * dy);
                                    if (dist < 16f)
                                    {
                                        ninjascript.pv -= 45;
                                    }
                                }

                            }

                        }
                    }

                    if (attacking == false)
                    {
                        if (walkmode == true)
                        {
                            walkCD += dt;
                            if (walkCD >= 135.5f - 134.06f)
                            {
                                walkCD = 0.0f;
                                PlayAnimationAtTime("Qishilong_walk", 134.06f);
                            }
                        }
                        else
                        {
                            idleCD += dt;
                            if (idleCD >= 121.22f - 118.02f)
                            {
                                idleCD = 0.0f;
                                PlayAnimationAtTime("Qishilong_stand", 118.02f);
                            }
                        }
                    }

                    if (pv <= 0)
                    {
                        PlayAnimationAtTime("Qishilong_die", 18.40f);
                        music.Stop();
                        dieSong.Play();
                        died = true;
                        t.SetActive(false);
                        r.SetActive(false);
                        f.SetActive(false);
                        ninjascript.nRubis += 1;

                    }

                }

                
            }
            
        }

        
    }

    void PlayAnimationAtTime(string animationName, float timeInSeconds)
    {
        AnimationClip clip = GetAnimationClipByName(animationName);
        if (clip != null)
        {
            float animationDuration = clip.length;
            float normalizedTime = timeInSeconds / animationDuration;
            animator.Play(animationName, -1, normalizedTime);
        }

    }
    AnimationClip GetAnimationClipByName(string clipName)
    {
        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == clipName)
            {
                return clip;
            }
        }
        return null;
    }
}