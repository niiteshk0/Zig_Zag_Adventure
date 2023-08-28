using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platfromSpawner : MonoBehaviour
{
    public GameObject Platform;
    public Transform lastPlatform;

    public bool stop;

    Vector3 newPos;
    Vector3 lastPos;

    // Update is called once per frame
    private void Start()
    {
        lastPos = lastPlatform.position;
        StartCoroutine(spawnPlatform());
    }
    void Update()
    {
        
    }

    void GeneratePos()
    {
        newPos = lastPos;
        int midRange = Random.Range(0, 3);

        if (midRange > 0)
            newPos.x += 2f;
        else
        {
            newPos.z += 2f;
        }

    }

    IEnumerator spawnPlatform()
    {
        while(!stop)
        {
            GeneratePos();
            Instantiate(Platform, newPos, Quaternion.identity);
            lastPos = newPos; 
            yield return new WaitForSeconds(0.2f);
        }
    }
}
