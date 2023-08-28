using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public float moveSpeed;
    bool faceLeft, firstTab;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameStart)
        {
            Move();
            checkInput();
        }
        if (transform.position.y <= -2f)
        {
            GameManager.instance.GameOver();
        }
        
    }
    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void checkInput()
    {
        if (Input.GetMouseButtonDown(0))
            changeDr();
    }

    void changeDr()
    {
        if(faceLeft)
        {
            faceLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            faceLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
    }
}
