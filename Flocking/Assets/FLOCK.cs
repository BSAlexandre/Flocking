using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FLOCK : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(swimgbitch.FM.minspeed, swimgbitch.FM.maxspeed);
    }

    // Update is called once per frame
    void Update()
    {
        ApplyRules();
        this.transform.Translate(0, 0, speed * Time.deltaTime);
        
    }


    void ApplyRules()
    {
        GameObject[] gos;
        gos = swimgbitch.FM.allfish;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gspeed = 0.01f;
        float inDistance;
        int groupsize = 0;

        foreach (GameObject go in gos)
        {

            if (go != this.gameObject)
            {
                inDistance = Vector3.Distance(go.transform.position, this.transform.position);
                if (inDistance <= swimgbitch.FM.neighbour)
                {
                    vcentre += go.transform.position;
                    groupsize++;

                    if(inDistance < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);

                    }
                    FLOCK anotherFlook = go.GetComponent<FLOCK>();
                    gspeed = gspeed + anotherFlook.speed;
                }

            }
            if (groupsize > 0)
            {
                vcentre = vcentre / groupsize;
                speed = gspeed/ groupsize;

                Vector3 direction = (vcentre + vavoid) - transform.position;  
                if(direction != Vector3.zero)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                        Quaternion.LookRotation(direction), swimgbitch.FM.rotationspeed * Time.deltaTime);
                }
            }
        }
    }   
    
}
