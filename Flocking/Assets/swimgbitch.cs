using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swimgbitch : MonoBehaviour
{
    public static swimgbitch FM;
    public GameObject fish;
    public int numfish = 20;
    public GameObject[] allfish;
    public Vector3 swimlimits = new Vector3(5, 5, 5);

    [Header("Fish Settings")]
    [Range(0.0f, 5.0f)]
    public float minspeed;
    [Range(0.0f, 5.0f)]
    public float maxspeed;
    [Range(1f, 10f)]
    public float neighbour;
    [Range(1f, 10f)]
    public float rotationspeed;

    // Start is called before the first frame update
    void Start()
    {
        allfish = new GameObject[numfish];
        for (int i = 0; i < numfish; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(UnityEngine.Random.Range(-swimlimits.x, swimlimits.x), UnityEngine.Random.Range(-swimlimits.y, swimlimits.y), UnityEngine.Random.Range(-swimlimits.z, swimlimits.z));

            allfish[i] = Instantiate(fish, pos, Quaternion.identity);
        }

        FM = this;
    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
