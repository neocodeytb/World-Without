using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraBossScript : MonoBehaviour
{

    public Transform pos;
    public GameObject ninja;
    public GameObject dragon;
    public float yOffset;
    public float camOffsetY;
    public float norm;
    public float tremblementOffSet = 0.0f;
    public bool tremblements = false;
    public float tremblementsCd = 0.0f;
    public bool travel = false;

    void Update()
    {
        Vector3 lookAt = new Vector3(pos.position.x, pos.position.y + yOffset, pos.position.z);
        transform.LookAt(lookAt);

        if (travel == false)
        {
            if (tremblements)
            {
                tremblementsCd = 0.35f;
                tremblements = false;
            }

            if (tremblementsCd > 0)
            {
                tremblementOffSet = Random.Range(-0.2f, 0.2f);
                tremblementsCd -= Time.deltaTime;
                if (tremblementsCd < 0)
                {
                    tremblementsCd = 0;
                }
            }



            float dx = ninja.transform.position.x - dragon.transform.position.x;
            float dz = ninja.transform.position.z - dragon.transform.position.z;

            float compX = dx / (Mathf.Abs(dx) + Mathf.Abs(dz));
            float compZ = dz / (Mathf.Abs(dx) + Mathf.Abs(dz));

            transform.position = new Vector3(ninja.transform.position.x + compX * norm, ninja.transform.position.y + camOffsetY + tremblementOffSet, ninja.transform.position.z + compZ * norm);
        }

        
    }
}

