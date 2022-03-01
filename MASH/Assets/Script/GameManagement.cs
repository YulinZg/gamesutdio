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

    private int[,] map = new int[40, 20];

    private float[] timeRecord = new float[4];
    
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        for (int k = 0; k < timeRecord.Length; k++)
        {
            if (PlayerPrefs.HasKey(k.ToString()))
            {
                timeRecord[k] = float.Parse(PlayerPrefs.GetString(k.ToString()));
            }
            else
                timeRecord[k] = 999.99f;
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
            int x = Random.Range(6, 38);
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
            int x = Random.Range(6, 38);
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
    }

    public void reStart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void quit() 
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void winGame()
    {
        if(soldierNumber == 0)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
        }
        timeRecord[3] = float.Parse(time.text);
        float temp;
        for (int j = timeRecord.Length - 1; j > 0; j--)
        { 
            for (int k = 0; k < j; k++)
            { 
                if (timeRecord[k] > timeRecord[k + 1])
                {
                    temp = timeRecord[k];
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
