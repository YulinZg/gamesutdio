using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [SerializeField]
    Text helicopterCounter;
    [SerializeField]
    Text hospitalCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updataHelicopterCounter(int soldiersCounter)
    {
        helicopterCounter.text = soldiersCounter.ToString();
        
    }

    public void updataHospitalCounter(int rescuedCounter)
    {
        hospitalCounter.text = rescuedCounter.ToString();
    }
}
