using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public GameObject starBlast;
    public GameObject daimondBlast;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 100f)* Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gameObject.tag == "star")
            {
                Instantiate(starBlast, transform.position, Quaternion.identity);
            }

            if(gameObject.tag == "Daimond")
            {
                Instantiate(daimondBlast, transform.position, Quaternion.identity);
            }
            Debug.Log("Enter in Collison");

            Destroy(gameObject);
        }
    }
}
