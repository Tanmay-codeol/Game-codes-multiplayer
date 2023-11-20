using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectedObject : MonoBehaviour
{
    public GameObject SelectedGameObject;
    public int AirDefenceNum;
    public int ArmyJeepNum;
    public int ArtileryNum;
    public int EngineerCorpsNum;
    public int InfantryNum;
    public int RadarNum;
    public int TankNum;

    public float DistanceFromCurrentHex;
    public CurrentHexInfo chi;
    
    // Start is called before the first frame update
    void Start()
    {
        chi = GameObject.Find("Hex Manager").GetComponent<CurrentHexInfo>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DistanceFromCurrentHex = Vector3.Distance(SelectedGameObject.transform.position, chi.CurrentHex.GetComponent<MouseHover>().CentrePoint.transform.position);
    }

    public void SelectObject(GameObject ClickedObj)
    {
        if(SelectedGameObject != null)
        {
            SelectedGameObject = null;
        }

        SelectedGameObject = ClickedObj;
        
        
    }
}
