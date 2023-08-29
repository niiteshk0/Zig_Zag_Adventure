using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carController : MonoBehaviour
{
    public float moveSpeed;
    bool faceLeft, firstTab;
    public GameObject textPanel;
    public GameObject TapTostart;

    [Header("audio")]
    public AudioSource audioSource;
    public AudioClip audioclip;
    

    [Header("Text")]
    public Text daimondText;
    public Text starText;
    int starCollect;
    int daimondCollect;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameStart)
        {
            TapTostart.SetActive(false);
            textPanel.SetActive(true);
            Move();
            checkInput();
        }
        if (transform.position.y <= -2f)
        {
            GameManager.instance.GameOver();
            audioSource.Stop();
        }
        
    }
    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void checkInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            changeDr();
            audioSource.PlayOneShot(audioclip);
            
        }
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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "star")
        {
            starCollect++;
            starText.text = starCollect.ToString();
        }

        if (collision.gameObject.tag == "Daimond")
        {
            daimondCollect++;
            daimondText.text = daimondCollect.ToString();
        }
    }
}
