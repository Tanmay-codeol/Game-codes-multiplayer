using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    Dictionary<Vector3Int, Hex> hexTileDict = new Dictionary<Vector3Int, Hex>();

    Dictionary<Vector3Int, List<Vector3Int>> hexTileNeighboursDict = new Dictionary<Vector3Int, List<Vector3Int>>();

    
    public CurrentHexInfo chi;

   

    private void Start()
    {
        foreach (Hex hex in FindObjectsOfType<Hex>())
        {
            hexTileDict[hex.HexCoords] = hex;
        }

        chi = GameObject.Find("Hex Manager").GetComponent<CurrentHexInfo>();

    }

    

    public void showNeighbours()
    {
        List<Vector3Int> neighbours = GetNeighboursFor(chi.CurrentHex.GetComponent<Hex>().HexCoords);
        //Debug.Log("Neighbours for " + gameObject.transform.name + " are :");
        foreach(Vector3Int neighbourPos in neighbours)
        {
            //Debug.Log(neighbourPos);
            //thisHexNeighbours.Add(neighbourPos);
        }
    }

    public Hex GetTileAt(Vector3Int hexCoordinates)
    {
        Hex result = null;
        hexTileDict.TryGetValue(hexCoordinates, out result);
        return result;
    }

    public List<Vector3Int> GetNeighboursFor(Vector3Int hexCoordinates)
    {
        if (hexTileDict.ContainsKey(hexCoordinates) == false)
            return new List<Vector3Int>();

        if (hexTileNeighboursDict.ContainsKey(hexCoordinates))
            return hexTileNeighboursDict[hexCoordinates];

        hexTileNeighboursDict.Add(hexCoordinates, new List<Vector3Int>());

        foreach (var direction in Direction.GetDirectionList(hexCoordinates.z))
        {
            if(hexTileDict.ContainsKey(hexCoordinates + direction))
            {
                hexTileNeighboursDict[hexCoordinates].Add(hexCoordinates + direction);
            }
        }

        return hexTileNeighboursDict[hexCoordinates];
    }

}

public static class Direction
{
    public static List<Vector3Int> directionsOffsetOdd = new List<Vector3Int>
    {
        new Vector3Int(-1,0,1),
        new Vector3Int(0,0,1),
        new Vector3Int(1,0,0),
        new Vector3Int(0,0,-1),
        new Vector3Int(-1,0,-1),
        new Vector3Int(-1,0,0),
    };

    public static List<Vector3Int> directionsOffsetEven = new List<Vector3Int>
    {
        new Vector3Int(0,0,1),
        new Vector3Int(1,0,1),
        new Vector3Int(1,0,0),
        new Vector3Int(1,0,-1),
        new Vector3Int(0,0,-1),
        new Vector3Int(-1,0,0),
    };
    public static List<Vector3Int> GetDirectionList(int z)
        => z % 2 == 0 ? directionsOffsetEven : directionsOffsetOdd;
}
