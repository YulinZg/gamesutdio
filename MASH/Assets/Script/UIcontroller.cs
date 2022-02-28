using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    [SerializeField]
    Text helicopterCounter;
    [SerializeField]
    Text hospitalCounter;
    [SerializeField]
    Text bulletCounter;
    [SerializeField]
    GameObject introductionPanel;

    [SerializeField]
    float typeIntervalTime = 0f;

    Text[] dialogText;
    string showDialog;

    private bool isTyping;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 0)
        {
            introductionPanel.SetActive(true);
            dialogText = introductionPanel.GetComponentsInChildren<Text>();
            isTyping = true;
            showDialog = "You are a helicopter pilot. Your mission is to rescue all the injured soldiers on the field.\n" +
                        "1. You can control your helicopter by using the arrow key. Your helicopter can only fit 3 soldiers at the time.\n" +
                        "2. Take injured soldiers to a hospital in batches. When all the soldiers are rescued, you win.\n" +
                        "3. If hitting a tree ends the game.\n" +
                        "4. Every time you rescue three people, you will get a bullet, press X to fire it, it can destroy the tree\n" +
                        "5. You can pressing the 'R' key resets the game.";
            StartCoroutine(typeText());
        }
        
    }

    private IEnumerator typeText()
    {
        foreach(char c in showDialog.ToCharArray())
        {
            dialogText[0].text += c;
            yield return new WaitForSeconds(typeIntervalTime);
        }
        dialogText[1].text = "Press Enter To Start";
        isTyping = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isTyping)
        {
            StopAllCoroutines();
            dialogText[0].text = showDialog;
            dialogText[1].text = "Press Enter To Start";
            isTyping = false;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && !isTyping)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void updataHelicopterCounter(int soldiersCounter)
    {
        helicopterCounter.text = soldiersCounter.ToString();
        
    }

    public void updataHospitalCounter(int rescuedCounter)
    {
        hospitalCounter.text = rescuedCounter.ToString();
    }

    public void updataBulletCounter(int bulletNumber)
    {
       bulletCounter.text = bulletNumber.ToString();
    }
}
