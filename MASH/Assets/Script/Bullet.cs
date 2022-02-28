using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float bulletSpeed;

    private GameObject helicopter;
    void Start()
    {
        helicopter = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (helicopter.transform.localScale.y == 0.5)
            gameObject.transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime, Space.World);
        if (helicopter.transform.localScale.y == -0.5)
            gameObject.transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime, Space.World);
    }
}
