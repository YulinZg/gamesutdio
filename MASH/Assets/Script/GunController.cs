using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject bullet;


    [SerializeField]
    public int bulletNumber = 0;

    private UIcontroller ui;
    void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UIcontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            Fire();
    }

    public void Fire()
    {
        if(bulletNumber > 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            bulletNumber--;
            ui.updataBulletCounter(bulletNumber);
        }
    }
}
