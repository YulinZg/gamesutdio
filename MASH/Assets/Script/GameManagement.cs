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
    GameObject soldier;

    [SerializeField]
    GameObject winPanel;

    [SerializeField]
    GameObject losePanel;

    


    private GameObject[] soldiers;
    // Start is called before the first frame update
    void Start()
    {
        soldiers = new GameObject[soldierNumber];
        for(int i = 0; i < soldierNumber; i++)
        {
            soldiers[i] = Instantiate(soldier, transform.position + new Vector3(i+1,0,0), transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
    }

    public void reStart()
    {
        SceneManager.LoadScene(0);
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
