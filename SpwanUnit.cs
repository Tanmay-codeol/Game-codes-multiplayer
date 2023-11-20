// using UnityEngine;

// public class SpawnUnit : MonoBehaviour
// {
//     public GameObject unitPrefab;
//     public bool isRedTeam;

//     private HexGrid hexGrid;

//     private void Start()
//     {
//         hexGrid = FindObjectOfType<HexGrid>();

//         Spawn();
//     }

//     public void Spawn()
//     {
//         // Spawn the unit prefab at this object's position
//         GameObject unit = Instantiate(unitPrefab, transform.position, Quaternion.identity);

//         // Set the unit's team color
//         DragDrop dragDrop = unit.GetComponent<DragDrop>();
//         if (dragDrop != null)
//         {
//             dragDrop.IsRedTeam = isRedTeam;
//         }

//         // Damage any blue team object within the hexagon
//         GameObject currentHex = hexGrid.GetHexFromWorldPosition(transform.position);
//         Collider[] objectsInHex = Physics.OverlapBox(currentHex.transform.position, new Vector3(0.5f, 0.5f, 0.5f));
//         foreach (Collider obj in objectsInHex)
//         {
//             if (obj.CompareTag("Unit") && obj.GetComponent<DragDrop>().IsRedTeam != isRedTeam)
//             {
//                 obj.GetComponent<Damage>().TakeDamage(1);
//             }
//         }
//     }
// }
