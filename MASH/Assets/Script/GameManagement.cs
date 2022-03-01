using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    [SerializeField]
    int soldierNumber = 0;

    [SerializeField]
    int treeNumber = 0;

    [SerializeField]
    GameObject soldier;

    [SerializeField]
    GameObject tree;

    [SerializeField]
    GameObject winPanel;

    [SerializeField]
    GameObject losePanel;

    [SerializeField]
    Text time;

    [SerializeField]
    Text first;

    [SerializeField]
    Text second;

    [SerializeField]
    Text third;

    private int[,] map = new int[36, 20];

    private float[] timeRecord = new float[4] { 999.99f, 999.99f, 999.99f, 999.99f };
    
    // Start is called before the first frame update
    void Start()
    {
        for (int k = 0; k < timeRecord.Length; k++)
        {
            if (PlayerPrefs.HasKey(k.ToString()))
            {
                timeRecord[k] = float.Parse(PlayerPrefs.GetString(k.ToString()));
            }
        }
        //for(int i = 0; i < 10; i++)
        //{
        //    for(int j = 0; j < 20; j++)
        //    {
        //        map[i, j] = 1;
        //        Debug.Log(map[i, j]);
        //    }
        //}
        //soldiers = new GameObject[soldierNumber];
        int i = 0;
        while(i < soldierNumber)
        {
            int x = Random.Range(8, 34);
            int y = Random.Range(2, 18);
            if (map[x, y] == 0 && map[x - 1, y] == 0 && map[x + 1, y] == 0 && map[x, y - 1] == 0 && map[x, y + 1] == 0)
            {
                Instantiate(soldier, gameObject.transform.position + new Vector3(x/2.0f, y/2.0f, 0), transform.rotation);
                i++;
                map[x, y] = 1;
            }    
            
        }
        int j = 0;
        while (j < treeNumber)
        {
            int x = Random.Range(8, 34);
            int y = Random.Range(2, 18);
            if (map[x, y] == 0 && map[x - 1, y] == 0 && map[x + 1, y] == 0 && map[x, y - 1] == 0 && map[x, y + 1] == 0)
            {
                Instantiate(tree, gameObject.transform.position + new Vector3(x/2.0f, y/2.0f, 0), transform.rotation);
                j++;
                map[x, y] = 1;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            reStart();
        if (Input.GetKeyDown(KeyCode.Escape))
            quit();
    }

    public void reStart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void quit() 
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void winGame()
    {
        if(soldierNumber == 0)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
            timeRecord[3] = float.Parse(time.text);
            for (int j = 0; j < timeRecord.Length; j++)
            {
                for (int k = 0; k < timeRecord.Length - j - 1; k++)
                {
                    if (timeRecord[k] > timeRecord[k + 1])
                    {
                        float temp = timeRecord[k];
                        timeRecord[k] = timeRecord[k + 1];
                        timeRecord[k + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < timeRecord.Length; i++)
            {
                PlayerPrefs.SetString(i.ToString(), timeRecord[i].ToString());
            }
            first.text = timeRecord[0].ToString();
            second.text = timeRecord[1].ToString();
            third.text = timeRecord[2].ToString();
        }

        
        //if (PlayerPrefs.HasKey("1st") && PlayerPrefs.HasKey("2nd") && PlayerPrefs.HasKey("3rd"))
        //{
        //    if(float.Parse(PlayerPrefs.GetString("3rd")) > float.Parse(time.text))

        //}
        //    PlayerPrefs.SetString("1st", time.text);
        //if (!PlayerPrefs.HasKey("1st"))
        //    PlayerPrefs.SetString("1st", time.text);
        //if (!PlayerPrefs.HasKey("2nd"))
        //    PlayerPrefs.SetString("2nd", time.text);
        //if (!PlayerPrefs.HasKey("3rd"))
        //    PlayerPrefs.SetString("3rd", time.text);

    }

    public void loseGame()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void minSoldierNumber(int number)
    {
        soldierNumber = soldierNumber - number;
    }
}
