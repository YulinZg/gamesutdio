using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hospitalController : MonoBehaviour
{
    private UIcontroller ui;
    private int rescuedCounter = 0;
    [SerializeField]
    GameManagement management;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UIcontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        management.minSoldierNumber(collision.gameObject.GetComponent<HelicopterController>().soldiersCounter);
        rescuedCounter += collision.gameObject.GetComponent<HelicopterController>().soldiersCounter;
        collision.gameObject.GetComponent<HelicopterController>().soldiersCounter = 0;
        ui.updataHelicopterCounter(collision.gameObject.GetComponent<HelicopterController>().soldiersCounter);
        ui.updataHospitalCounter(rescuedCounter);
        management.winGame();
    }
}
