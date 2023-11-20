using UnityEngine;
using UnityEngine.UI;

public class MapClickHandler : MonoBehaviour
{
    public InputField latLongTextField;
    public LayerMask whatIsHex;

    private void Start()
    {
        // latLongTextField = GetComponent<InputField>();
        
    }

    private void Update()
    {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit,whatIsHex))
            {
                Vector3 position = hit.transform.gameObject.GetComponent<MouseHover>().CentrePoint.transform.position;
                //latLongTextField.text = "Latitude: " + position.x +"<br>+, Longitude: " + position.z;
            }
        }
    }

