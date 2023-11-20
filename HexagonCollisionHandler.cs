using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonCollisionHandler : MonoBehaviour
{
    private bool isRedTeam;

    void Start()
    {
        // Check if the game object is from the red or blue team
        isRedTeam = gameObject.name.Contains("red");
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the other object is also a hexagon with a HexCoordinates component
        HexCoordinates otherHex = other.GetComponent<HexCoordinates>();
        if (otherHex != null)
        {
            // Check if the other object is from the other team and was instantiated after this one
            bool isOtherRedTeam = other.gameObject.name.Contains("red");
            if (isRedTeam != isOtherRedTeam && otherHex.WorldPosition.x > GetComponent<HexCoordinates>().WorldPosition.x)
            {
                // Destroy the other object
                Destroy(other.gameObject);
            }
        }
    }
}
