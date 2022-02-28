using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float moveSpeed = 1.0f;
    public int soldiersCounter = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            gameObject.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.DownArrow))
            gameObject.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, 0.5f, gameObject.transform.localScale.z);

        }
            
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, -0.5f, gameObject.transform.localScale.z);
        }
            

    }
}
