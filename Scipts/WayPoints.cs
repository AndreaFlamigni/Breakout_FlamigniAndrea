using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public List<Transform> Positions = new List<Transform>();
    int posIndex = 0;

    public float MoveSpeed = 3;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Positions[posIndex].position, Time.deltaTime * MoveSpeed);
        if (Vector3.Distance(transform.position, Positions[posIndex].position) < 0.4f)
        {
            posIndex++;
            if (posIndex >= Positions.Count)
            {
                posIndex = 0;
            }
        }
    }
}
