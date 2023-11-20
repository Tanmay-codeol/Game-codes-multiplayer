using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;


public class InstantiateWep : MonoBehaviourPunCallbacks
{
    public GameObject weapon;
    public GameObject cam;
    private int x = 0;
    public OnGridList ogl;
    public SelectedObject so;
    public GameObject instantiatedObject;
    public MouseHover mouseHover;


    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        ogl = GameObject.Find("Hex Manager").GetComponent<OnGridList>();
        so = GameObject.Find("Objects Info").GetComponent<SelectedObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InstantiateWeapon()
    {
            // instantiatedObject = PhotonNetwork.Instantiate(weapon.name, new Vector3(0,2,0), weapon.transform.rotation);
            

        GameObject NewWep = PhotonNetwork.Instantiate(weapon.name, new Vector3(0,2,0), weapon.transform.rotation);
        mouseHover.AddInstantiatedObject(NewWep);
        string TeamColor;

        
        if(NewWep.GetComponent<DragDrop>().IsRedTeam == true)
        {
            TeamColor = " (red)";
                        Collider[] objectsInHex = Physics.OverlapBox(NewWep.transform.position, new Vector3(0.5f, 0.5f, 0.5f));
             foreach (Collider obj in objectsInHex)
            {
                // Check if the object is on the opposite team  
                if (obj.CompareTag("Unit") && obj.GetComponent<Damage>() != null && obj.GetComponent<DragDrop>().IsRedTeam != true)
                {
                    // Apply damage to the opposite team GameObject
                    obj.GetComponent<MouseHover>().Attack();

                
                }
            }
        }

        else
        {
            TeamColor = " (blue)";
        }

        //Debug.Log(NewWep.gameObject.transform.GetComponent<DragDrop>().ObjectType);
        if(NewWep.gameObject.transform.GetComponent<DragDrop>().ObjectType == "Air Defence")
        {
            so.AirDefenceNum++;
            NewWep.name = NewWep.gameObject.transform.GetComponent<DragDrop>().ObjectType + so.AirDefenceNum;
        }

        else if(NewWep.gameObject.transform.GetComponent<DragDrop>().ObjectType == "Army Jeep")
        {
            so.ArmyJeepNum++;
            NewWep.name = NewWep.gameObject.transform.GetComponent<DragDrop>().ObjectType + so.ArmyJeepNum;
        }

        else if (NewWep.gameObject.transform.GetComponent<DragDrop>().ObjectType == "Artilery")
        {
            so.ArtileryNum++;
            NewWep.name = NewWep.gameObject.transform.GetComponent<DragDrop>().ObjectType + so.ArtileryNum;
        }

        else if (NewWep.gameObject.transform.GetComponent<DragDrop>().ObjectType == "Engineer Corps")
        {
            so.EngineerCorpsNum++;
            NewWep.name = NewWep.gameObject.transform.GetComponent<DragDrop>().ObjectType + so.EngineerCorpsNum;
        }

        else if (NewWep.gameObject.transform.GetComponent<DragDrop>().ObjectType == "Infantry")
        {
            so.InfantryNum++;
            NewWep.name = NewWep.gameObject.transform.GetComponent<DragDrop>().ObjectType + so.InfantryNum;
        }

        else if (NewWep.gameObject.transform.GetComponent<DragDrop>().ObjectType == "Radar")
        {
            so.RadarNum++;
            NewWep.name = NewWep.gameObject.transform.GetComponent<DragDrop>().ObjectType + so.RadarNum;
        }

        else if (NewWep.gameObject.transform.GetComponent<DragDrop>().ObjectType == "Tank")
        {
            so.TankNum++;
            NewWep.name = NewWep.gameObject.transform.GetComponent<DragDrop>().ObjectType + so.TankNum;
        }

        NewWep.name = NewWep.name + TeamColor;
        
        ogl.AddToList(NewWep);
    }
}
