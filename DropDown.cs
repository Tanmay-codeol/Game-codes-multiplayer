using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    public TMPro.TMP_Dropdown MyDropDown;
    public GameObject ArtileryPanel;
    public GameObject InfantryPanel;
    public GameObject GroundPanel;
    public GameObject RadarPanel;
    public GameObject JCBPanel;
    public GameObject AirDefencePanel;
    public GameObject JeepPanel;
    public GameObject currentPanel;
    public GameObject previousPanel;
    // Start is called before the first frame update
    void Start()
    {
currentPanel = ArtileryPanel;
        previousPanel=  null;
    }

    // Update is called once per frame
    void Update()
    {

        /*if(ArtileryPanel.activeSelf == true)
        {
            currentPanel = ArtileryPanel;
        }
        
        else if (InfantoryPanel.activeSelf == true)
        {
            currentPanel = InfantoryPanel;
        }*/

        //OnOptionChange();
    }

    public void OnOptionChange()
    {
        

        if (MyDropDown.value == 0)
        {
            InfantryPanel.SetActive(false);
            currentPanel = ArtileryPanel;
        }

        if (MyDropDown.value == 1)
        {
            previousPanel=currentPanel;
            currentPanel=InfantryPanel;
        }if (MyDropDown.value == 2)
        {
           previousPanel=currentPanel;
           currentPanel=JeepPanel;
        }if (MyDropDown.value == 3)
        {
            previousPanel=currentPanel;
            currentPanel = GroundPanel;
            
        }if (MyDropDown.value == 4)
        {
            previousPanel=currentPanel;
            currentPanel = JCBPanel;
            
        }
        if (MyDropDown.value == 5)
        {
            previousPanel=currentPanel;
            currentPanel = RadarPanel;
            
        }
         if (MyDropDown.value == 6)
        {
            previousPanel=currentPanel;
            currentPanel = AirDefencePanel;
            
        }
        previousPanel.SetActive(false);
        currentPanel.SetActive(true);

        
    }
}
