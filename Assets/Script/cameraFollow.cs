using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 distance;
    public float followSpeed;

    // Start is called before the first frame update
    void Start()
    {
        distance = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.y > 0)
            follow();  
    }

    void follow()
    {
        Vector3 currPos = transform.position;
        Vector3 targetPos = target.position - distance;

        transform.position = Vector3.Lerp(currPos, targetPos, followSpeed * Time.deltaTime); // camera ki curr pos  = (kha se start krna h , kisko follow krna h , kitni speed se follow krna h)
    }
}
