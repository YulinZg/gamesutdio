using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float bulletSpeed;

    [SerializeField]
    Sprite[] anim;
    private GameObject helicopter;
    void Start()
    {
        helicopter = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(playAnim());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (helicopter.transform.localScale.y == 0.5)
            gameObject.transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime, Space.World);
        if (helicopter.transform.localScale.y == -0.5)
            gameObject.transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime, Space.World);
    }

    private IEnumerator playAnim()
    {
        int i = 0;
        int count = 0;
        while (count < 100)
        {
            count++;
            gameObject.GetComponent<SpriteRenderer>().sprite = anim[i];
            i++;
            if (i > 3)
                i = 0;
            yield return new WaitForSeconds(0.15f);
        }
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
