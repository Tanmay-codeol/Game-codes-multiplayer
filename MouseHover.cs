using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseHover : MonoBehaviour
{
    public GameObject HexBody;
    public GameObject CentrePoint;
    public GameObject otherCentre;
    public GameObject firstUnit;
    public GameObject secondUnit;
    public Material DefaultMaterial;
    public Material HoverMaterial;
    public Material OnClickMaterial;
    public TextMeshProUGUI inputFieldLat;
    public TextMeshProUGUI inputFieldLong;
    public CurrentHexInfo chi;
    public bool IsChiOccupied;
    public SelectedObject so;
    public UnitsMovement um;
    public bool MouseDown;
    

    public HexGrid hg;
    //public List<Vector3Int> thisHexNeighbours = new List<Vector3Int>();

    public List<Vector3Int> neighbours = new List<Vector3Int>();
    public List<GameObject> instantiatedObjects = new List<GameObject>();

    public void AddInstantiatedObject(GameObject obj) {
        instantiatedObjects.Add(obj);
    }

    private void Awake() {
      
    }
    private void Start()
    {
        chi = GameObject.Find("Hex Manager").GetComponent<CurrentHexInfo>();
        hg = GameObject.Find("HexGrid").GetComponent<HexGrid>();
        so = GameObject.Find("Objects Info").GetComponent<SelectedObject>();
        inputFieldLat = GameObject.Find("LATtext").GetComponent<TextMeshProUGUI>();
        inputFieldLong = GameObject.Find("LONGtext").GetComponent<TextMeshProUGUI>();
        
    }

    private void Update()
    {
        
        GetThisHexNeighbour();
        //um = so.SelectedGameObject.GetComponent<UnitsMovement>();
        
        
    //Attack();
    }

    public void GetThisHexNeighbour()
    {
        neighbours = hg.GetNeighboursFor(gameObject.GetComponent<Hex>().HexCoords);
        /*foreach (Vector3Int neighbourPos in neighbours)
        {
            //Debug.Log(neighbourPos);

            thisHexNeighbours.Add(neighbourPos);
        }*/
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        /*if(chi != null)
        {
            chi = null;
        }*/
        foreach (GameObject obj in instantiatedObjects)
    {
        // Ignore game objects that are not units or are on the same team.
        if (obj.tag != "Unit" || obj.GetComponent<DragDrop>().IsRedTeam == so.SelectedGameObject.GetComponent<DragDrop>().IsRedTeam)
        {
            continue;
        }

        // Check if the game object is in the same hexagon.
        if (obj.GetComponent<MouseHover>().CentrePoint.transform.position == CentrePoint.transform.position)
        {
            // Attack the game object.
            obj.GetComponent<Damage>().health -= so.SelectedGameObject.GetComponent<Damage>().damage;
            Debug.Log("Attacked " + obj.name + " for " + so.SelectedGameObject.GetComponent<Damage>().damage + " damage.");

            // Check if the game object was destroyed.
            if (obj.GetComponent<Damage>().health <= 0)
            {
                Destroy(obj);
                Debug.Log(obj.name + " was destroyed.");
            }
        }
    }
        chi.CurrentHex = gameObject;
        chi.HexCentreToWorld = CentrePoint.transform.position;
        chi.HexOtherCentreToWorld=otherCentre.transform.position;
        
        
        Debug.Log("Mouse is over "+ transform.name);
        inputFieldLat.text="Latitude "+CentrePoint.transform.position.x;
        //inputField.text+= "\r\n\r\n";
        inputFieldLong.text="Longitude "+CentrePoint.transform.position.z;
        
        Debug.Log(gameObject.GetComponent<MouseHover>().IsChiOccupied);

        if(MouseDown == false)
        {
            HexBody.GetComponent<MeshRenderer>().material = HoverMaterial;
        }
        
        //Attack();

    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        HexBody.GetComponent<MeshRenderer>().material = DefaultMaterial;
        
    }

    private void OnMouseDown()
    {
        um = so.SelectedGameObject.GetComponent<UnitsMovement>();
        if (um.CanClickHex == true)
        {
            //if(firstUnit==null)
            //{
            if(so.SelectedGameObject.GetComponent<DragDrop>().IsRedTeam == true)
            {
                um.TargetPosition = CentrePoint.transform.position;
            }

            else if (so.SelectedGameObject.GetComponent<DragDrop>().IsRedTeam == false)
            {
                um.TargetPosition = otherCentre.transform.position;
            }

            //firstUnit=so.SelectedGameObject;
            //}
            /*else if(secondUnit==null){
            um.TargetPosition=otherCentre.transform.position;
            secondUnit=so.SelectedGameObject;
            }*/
            so.SelectedGameObject = null;
            MouseDown = true;
            HexBody.GetComponent<MeshRenderer>().material = OnClickMaterial;
            
            
            um.ReachedPoint = false;
            Attack();


            //Debug.Log("click!");
        }
        
    }

    private void OnMouseUp()
    {
        MouseDown = false;
        //HexBody.GetComponent<MeshRenderer>().material = DefaultMaterial;
        //Attack();
    }

public void Attack()
    {
        if(firstUnit!=null && secondUnit!=null)
        {
            firstUnit.GetComponent<Damage>().health-=secondUnit.GetComponent<Damage>().damage;
                //chi.firstUnit.GetComponent<Damage>().slider.value=hit.transform.gameObject.GetComponent<Damage>().health;
                secondUnit.GetComponent<Damage>().health-=firstUnit.GetComponent<Damage>().damage;
                Debug.Log("Working!");
                
        }
    }
}
