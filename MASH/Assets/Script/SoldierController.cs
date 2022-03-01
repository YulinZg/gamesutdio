using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    private UIcontroller ui;
    
   
    private AudioSource pickupAudio;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UIcontroller>();
        pickupAudio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        gameObject.transform.Rotate(0f, 0f, 90f, Space.Self);
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<HelicopterController>().soldiersCounter < 3)
        {
            collision.gameObject.GetComponent<HelicopterController>().soldiersCounter += 1;
            ui.updataHelicopterCounter(collision.gameObject.GetComponent<HelicopterController>().soldiersCounter);
            pickupAudio.Play();
            Destroy(gameObject);
           
        }
    }
}
