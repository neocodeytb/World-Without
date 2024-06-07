using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aggressiveMobScript : MonoBehaviour
{

    public int[,,] map;
    public WorldGeneration worldGen;
    public float delay = 0.3f;

    public int H;
    public int negH;
    public int V;
    public int negV;

    public int x;
    public int y;
    public int z;

    public float vx;
    public float vy;
    public float vz;

    public int orientationState = 0;
    public float speed = 8.0f;

    public AudioSource audioSource;

    public NinjaScript ninja;

    public AudioSource audioSourceWalk1;
    public AudioSource audioSourceWalk2;

    public string typeMob;

    public float cooldown = 0.0f;

    public ParticleSystem blood;

    public AudioSource damaged;

    public int moveHorizontal = 0;
    public int moveVertical = 0;

    public DragonScript dragon;


    void Start()
    {
        map = worldGen.map;
        InvokeRepeating("Moove", delay, delay);
        InvokeRepeating("Translate", delay / 10, delay / 10);
        InvokeRepeating("Damage", delay * 2,delay*2);
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        int song = UnityEngine.Random.Range(0, 5000);
        if (song == 0)
        {
            int nx = ninja.x;
            int ny = ninja.y;
            int dp = Mathf.Abs((nx - x)) + Mathf.Abs((ny - y));
            if (Mathf.Abs(dp) < 10)
            {
                audioSource.Play();
            }
        }

        int moove = UnityEngine.Random.Range(0, 10);

        if (moove == 0 && cooldown <= 0.0f && ninja.levelUp == false && ninja.inInventory == false)
        {
            cooldown = 0.5f;
            int xNinja = ninja.x;
            int yNinja = ninja.y;

            if (xNinja - x > 0)
            {
                moveHorizontal = 1;

            }

            if (xNinja - x < 0)
            {
                moveHorizontal = -1;

            }

            if (yNinja - y > 0)
            {
                moveVertical = 1;

            }

            if (yNinja - y < 0)
            {
                moveVertical = -1;

            }

            if (yNinja - y == 0)
            {
                moveVertical = 0;

            }

            if (xNinja - x == 0)
            {
                moveHorizontal = 0;

            }
        }

        bool hAxis = moveVertical > 0;
        bool vAxis = moveHorizontal > 0;

        bool neghAxis = moveVertical < 0;
        bool negvAxis = moveHorizontal < 0;

        H = hAxis & true ? 1 : 0;
        negH = neghAxis & true ? 1 : 0;

        V = vAxis & true ? 1 : 0;
        negV = negvAxis & true ? 1 : 0;


    }

    void Moove()
    {
        int nx = ninja.x;
        int ny = ninja.y;
        
        vx = (V - negV);
        vy = (H - negH);
        bool boolean = (Mathf.Abs(vx) > 0 || Mathf.Abs(vy) > 0);
        vz = boolean & true ? 1 : 0;

        moveHorizontal = 0;
        moveVertical = 0;

        if (boolean)
        {
            int sort = UnityEngine.Random.Range(1, 4);
            if (sort == 1)
            {
                int dp = Mathf.Abs((nx - x)) + Mathf.Abs((ny - y));
                if (Mathf.Abs(dp) < 20)
                {
                    audioSourceWalk1.Play();

                }
            }
            if (sort == 2)
            {
                int dp = Mathf.Abs((nx - x)) + Mathf.Abs((ny - y));
                if (Mathf.Abs(dp) < 20)
                {
                    audioSourceWalk2.Play();

                }
            }
        }

        if (vx > 0)
        {
            transform.rotation = Quaternion.Euler(-90, 180, 0);
            orientationState = 1;

        }

        if (vy > 0)
        {
            transform.rotation = Quaternion.Euler(-90, 90, 0);
            orientationState = 2;
        }

        if (vx < 0)
        {
            transform.rotation = Quaternion.Euler(-90, 360, 0);
            orientationState = 0;
        }

        if (vy < 0)
        {
            transform.rotation = Quaternion.Euler(-90, 270, 0);
            orientationState = 3;

        }

        if (vx > 0 && vy > 0)
        {
            transform.rotation = Quaternion.Euler(-90, 135, 0);
            orientationState = 4;
        }

        if (vx > 0 && vy < 0)
        {
            transform.rotation = Quaternion.Euler(-90, 225, 0);
            orientationState = 5;


        }

        if (vx < 0 && vy > 0)
        {
            transform.rotation = Quaternion.Euler(-90, 45, 0);
            orientationState = 6;


        }

        if (vx < 0 && vy < 0)
        {
            transform.rotation = Quaternion.Euler(-90, 315, 0);
            orientationState = 7;
        }

        if (map[x + (int)vx, y + (int)vy, 0] == 0 && !(x + (int)vx == 251 && (y + (int)vy == 249 || y + (int)vy == 250 || y + (int)vy == 251)))
        {
            x = x + (int)vx;
            y = y + (int)vy;
        }

        else
        {
            vx = 0.0f;
            vy = 0.0f;
        }

    }

    void Translate()
    {
        transform.Translate(vx * delay / 10 * speed, vz * delay, vy * delay / 10 * speed, Space.World);

        if (transform.position.y >= 1.15f)
        {
            vz = vz - 0.3f;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 1.15f, transform.position.z);
            vz = 0;
        }

    }

    void Damage()
    {
        int nx = ninja.x;
        int ny = ninja.y;
        if (x == nx && y == ny && ninja.levelUp == false && !ninja.isDead && ninja.inInventory == false)
        {
            if (dragon != null)
            {
                if (dragon.stopAll == false)
                {
                    ninja.pv -= 15;
                    blood.Play();
                    damaged.Play();
                }
            }
            else
            {
                ninja.pv -= 15;
                blood.Play();
                damaged.Play();
            }
            
        }
    }
}
