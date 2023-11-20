using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGridList : MonoBehaviour
{
    public List<GameObject> OnFieldList = new List<GameObject>();
    public List<GameObject> OnGridObjects;

    public void AddToList(GameObject newObject)
    {
        OnGridObjects.Add(newObject);
        OnFieldList.Add(newObject);

        if (newObject.GetComponent<DragDrop>().IsRedTeam == true)
        {
            // Find all objects in the current hexagon
            Collider[] objectsInHex = Physics.OverlapBox(newObject.transform.position, new Vector3(0.5f, 0.5f, 0.5f));

            // Loop through all objects in the hexagon
            foreach (Collider obj in objectsInHex)
            {
                // Check if the object is on the opposite team
                if (obj.CompareTag("Unit") && obj.GetComponent<Damage>() != null && obj.GetComponent<DragDrop>().IsRedTeam == false)
                {
                    // Apply damage to the opposite team GameObject
                    obj.GetComponent<Damage>().TakeDamage(100); // You can adjust the damage value as needed
                }
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void AddToList(GameObject NewWep)
    // {
    //     // OnFieldList.Add(NewWep);
    // }

    public void AdjustPos()
    {
        for(int i=0;i<OnFieldList.Count;i++)
        {
            OnFieldList[i].transform.position = OnFieldList[i].GetComponent<DragDrop>().CurrentHex.GetComponent<MouseHover>().CentrePoint.transform.position;
        }
    }
}
