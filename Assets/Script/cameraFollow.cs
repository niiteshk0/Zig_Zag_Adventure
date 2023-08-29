using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 distance;
    public float followSpeed;

    [SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] myColors;
    int colorIdx = 0;
    float change = 0;
    int len;

    // Start is called before the first frame update
    void Start()
    {
        distance = target.position - transform.position;
        len = myColors.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.y > 0)
            follow();

        // Auto color change
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, myColors[colorIdx], lerpTime * Time.deltaTime);
        change = Mathf.Lerp(change, 1f, lerpTime * Time.deltaTime);
        if (change > 0.9f)
        {
            change = 0;
            colorIdx++;
            colorIdx = (colorIdx >= len) ? 0 : colorIdx;
        }
    }

    void follow()
    {
        Vector3 currPos = transform.position;
        Vector3 targetPos = target.position - distance;

        transform.position = Vector3.Lerp(currPos, targetPos, followSpeed * Time.deltaTime); // camera ki curr pos  = (kha se start krna h , kisko follow krna h , kitni speed se follow krna h)
    }
}
