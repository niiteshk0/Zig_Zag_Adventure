using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatForm : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platformBlastEffect;
    public GameObject daimond;
    public GameObject star;
    void Start()
    {
        int randNum = Random.Range(1, 21);
        Vector3 tempPos = transform.position;
        tempPos.y += 1.2f;

        if (randNum < 4)
            Instantiate(star, tempPos, star.transform.rotation);

        if (randNum == 8)
            Instantiate(daimond, tempPos, daimond.transform.rotation);
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("fallDown", 0.2f);
        }
    }

    void fallDown()
    {
        Instantiate(platformBlastEffect, transform.position, Quaternion.identity);
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 05f);
    }
}
