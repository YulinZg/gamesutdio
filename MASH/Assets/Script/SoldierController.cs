using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    private UIcontroller ui;
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
        if (collision.gameObject.GetComponent<HelicopterController>().soldiersCounter < 3)
        {
            collision.gameObject.GetComponent<HelicopterController>().soldiersCounter += 1;
            ui.updataHelicopterCounter(collision.gameObject.GetComponent<HelicopterController>().soldiersCounter);
            Destroy(gameObject);
        }
    }
}