using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    private HexCoordinates hexCoordinates;
    private HexGrid hexGrid;

    private void Start()
    {
        hexCoordinates = GetComponent<HexCoordinates>();
        hexGrid = FindObjectOfType<HexGrid>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DamageObject") && gameObject.CompareTag("DamageObject"))
        {
            HexCoordinates otherHexCoords = other.gameObject.GetComponent<HexCoordinates>();
            if (otherHexCoords.GetHexCoords() == hexCoordinates.GetHexCoords())
            {
                if (other.gameObject.GetInstanceID() > gameObject.GetInstanceID())
                {
                    // Other object was instantiated later, so destroy this object
                    Destroy(gameObject);
                }
                else
                {
                    // This object was instantiated later, so destroy the other object
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
