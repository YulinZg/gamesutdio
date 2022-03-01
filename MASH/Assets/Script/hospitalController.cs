using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hospitalController : MonoBehaviour
{
    private UIcontroller ui;
    private int rescuedCounter = 0;
    private int bulletLogicCounter = 0;
    private GameManagement management;
    private AudioSource pickupAudio;
    [SerializeField]
    GunController gun;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UIcontroller>();
        management = GameObject.FindGameObjectWithTag("management").GetComponent<GameManagement>();
        pickupAudio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<HelicopterController>().soldiersCounter != 0)
            {
                pickupAudio.Play();
            }
            rescuedCounter += collision.gameObject.GetComponent<HelicopterController>().soldiersCounter;
            bulletLogicCounter += collision.gameObject.GetComponent<HelicopterController>().soldiersCounter;
            management.minSoldierNumber(collision.gameObject.GetComponent<HelicopterController>().soldiersCounter);
            collision.gameObject.GetComponent<HelicopterController>().soldiersCounter = 0;
            ui.updataHelicopterCounter(collision.gameObject.GetComponent<HelicopterController>().soldiersCounter);
            ui.updataHospitalCounter(rescuedCounter);
            
            management.winGame();
            if (bulletLogicCounter == 3)
            {
                bulletLogicCounter = 0;
                gun.bulletNumber++;
                ui.updataBulletCounter(gun.bulletNumber);
            }
            else if(bulletLogicCounter > 3)
            {
                bulletLogicCounter = bulletLogicCounter - 3;
                gun.bulletNumber++;
                ui.updataBulletCounter(gun.bulletNumber);
            }
        } 
    }
}
