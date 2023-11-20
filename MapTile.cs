// using System.Collections; Vector3(10.4837132,8.23126221,8.23126221)
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Networking;
// using System;

// public class MapTile : MonoBehaviour
// {
//     public Button zoomInButton;
//     public InputField inputField;
//     public Button zoomOutButton;
//     public GameObject cam;
//     public float zValue;

//     public string apiKey;
//     public float lat = -33.85660618894087f;
//     public float lon = 151.21500701957325f;
//     public float zoom = 14;
//     public enum resolution { low = 1, high = 2 };
//     public resolution mapResolution = resolution.low;
//     public enum type { roadmap, satellite, gybrid, terrain };
//     public type mapType = type.roadmap;
//     private string url = "";
//     private int mapWidth = 640;
//     private int mapHeight = 640;
//     private bool mapIsLoading = false; //not used. Can be used to know that the map is loading 
//     private Rect rect;
//     public float scaleFactor = 1f;

//     private string apiKeyLast;
//     private float latLast = -33.85660618894087f;
//     private float lonLast = 151.21500701957325f;
//     private float zoomLast = 14;
//     private resolution mapResolutionLast = resolution.low;
//     private type mapTypeLast = type.roadmap;
//     private bool updateMap = true;
//     public Transform Map;
//     private float lastScaleFactor;
//     private Vector3 originalScale = new Vector3(4.4f, 1, 4.4f);

//     public OnGridList ogl;
    


//     // Start is called before the first frame update
//     public void AssignScaleFactor()
//     {
//         scaleFactor = float.Parse(inputField.text);
//         if(float.Parse(inputField.text) > 0)
//         {
//             Map.localScale = scaleFactor * originalScale;
//             ogl.AdjustPos();
//         }
        
//     }
//     public void ResetScaleFactor()
//     {
//         Map.localScale = new Vector3(4.4f, 1, 4.4f);
//         ogl.AdjustPos();
//     }
//     void Start()
//     {
//         StartCoroutine(GetGoogleMap());
//         rect = gameObject.GetComponent<RawImage>().rectTransform.rect;
//         mapWidth = (int)Math.Round(rect.width);
//         mapHeight = (int)Math.Round(rect.height);
//         //zoomInButton.onClick.AddListener(ZoomIn);
//         //zoomOutButton.onClick.AddListener(ZoomOut);
//         GetGoogleMap();
//         cam = GameObject.Find("Main Camera");
//         zValue = -19f;

//         Map.localScale = new Vector3(4.4f, 1, 4.4f);
//         ogl = GameObject.Find("Hex Manager").GetComponent<OnGridList>();
        
        
//     }

//     /*void ZoomIn()
//     {
//         if (cam.GetComponent<Camera>().fieldOfView > 15)
//         {
//             cam.GetComponent<Camera>().fieldOfView -= 20;
//             zoom += 1;
//         }
//         GetGoogleMap();
//     }
//     void ZoomOut()
//     {
//         zoom -= 1;
//         zValue -= 10;
//         cam.GetComponent<Camera>().fieldOfView += 20;
//         GetGoogleMap();
//     }*/

//     // Update is called once per frame
//     void Update()
//     {
        

//         if (Input.GetKey(KeyCode.UpArrow))
//         {
//             lat += 0.00005f;
//             GetGoogleMap();
//             Vector3 newPosition = cam.transform.position;
//             // newPosition.z += 1f; // or any other value to move the camera up
//             // cam.transform.position = newPosition;
//         }
//         if (Input.GetKey(KeyCode.DownArrow))
//         {
//             lat -= 0.00005f;
//             GetGoogleMap();
//             Vector3 newPosition = cam.transform.position;
//             // newPosition.z -= 1f; // or any other value to move the camera down
//             // cam.transform.position = newPosition;
//         }
//         if (Input.GetKey(KeyCode.LeftArrow))
//         {
//             lon -= 0.00005f;
//             GetGoogleMap();
//             Vector3 newPosition = cam.transform.position;
//             // newPosition.x -= 1f; // or any other value to move the camera to the left
//             // cam.transform.position = newPosition;
//         }
//         if (Input.GetKey(KeyCode.RightArrow))
//         {
//             lon += 0.00005f;
//             GetGoogleMap();
//             Vector3 newPosition = cam.transform.position;
//             // newPosition.x += 1f; // or any other value to move the camera to the right
//             // cam.transform.position = newPosition;

//         }
//         // if (Input.GetKey(KeyCode.z)) {
//         //     zoom += 1;
//         // }
//         // if (Input.GetKey(KeyCode.Z)) {
//         //     zoom -= 1;
//         // }


//         /*if (updateMap && (apiKeyLast != apiKey || !Mathf.Approximately(latLast, lat) || !Mathf.Approximately(lonLast, lon) || zoomLast != zoom || mapResolutionLast != mapResolution || mapTypeLast != mapType))
//         {
//             rect = gameObject.GetComponent<RawImage>().rectTransform.rect;
//             mapWidth = (int)Math.Round(rect.width);
//             mapHeight = (int)Math.Round(rect.height);
//             StartCoroutine(GetGoogleMap());
//             updateMap = false;
//         }*/
        


//     }


//     IEnumerator GetGoogleMap()
//     {
//         url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon + "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + mapResolution + "&maptype=" + mapType + "&key=" + apiKey;
//         mapIsLoading = true;
//         UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
//         yield return www.SendWebRequest();
//         if (www.result != UnityWebRequest.Result.Success)
//         {
//             Debug.Log("WWW ERROR: " + www.error);
//         }
//         else
//         {
//             mapIsLoading = false;
//             gameObject.GetComponent<RawImage>().texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

//             apiKeyLast = apiKey;
//             latLast = lat;
//             lonLast = lon;
//             zoomLast = zoom;
//             mapResolutionLast = mapResolution;
//             mapTypeLast = mapType;
//             updateMap = true;
//         }
//     }

// }
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Networking;
// using System;

// public class MapTile : MonoBehaviour
// {
//     public Button zoomInButton;
//     public InputField inputField;
//     public Button zoomOutButton;
//     public GameObject cam;
//     public float zValue;

//     public string apiKey;
//     public float lat = -33.85660618894087f;
//     public float lon = 151.21500701957325f;
//     public float zoom = 14;
//     public enum resolution { low = 1, high = 2 };
//     public resolution mapResolution = resolution.low;
//     public enum type { roadmap, satellite, gybrid, terrain };
//     public type mapType = type.roadmap;
//     private string url = "";
//     private int mapWidth = 640;
//     private int mapHeight = 640;
//     private bool mapIsLoading = false; //not used. Can be used to know that the map is loading 
//     private Rect rect;
//     // public float scaleFactor = 1f;

//     private string apiKeyLast;
//     private float latLast = -33.85660618894087f;
//     private float lonLast = 151.21500701957325f;
//     private float zoomLast = 14;
//     private resolution mapResolutionLast = resolution.low;
//     private type mapTypeLast = type.roadmap;
//     private bool updateMap = true;      
//     // public Transform Map;
//     // private float lastScaleFactor;
//     // private Vector3 originalScale = new Vector3(4.4f, 1, 4.4f);

//     public OnGridList ogl;
    


//     // Start is called before the first frame update
//     // public void AssignScaleFactor()
//     // {
//     //     scaleFactor = float.Parse(inputField.text);
//     //     if(float.Parse(inputField.text) > 0)
//     //     {
//     //         Map.localScale = scaleFactor * originalScale;
//     //         ogl.AdjustPos();
//     //     }
        
//     // }
//     // public void ResetScaleFactor()
//     // {
//     //     Map.localScale = new Vector3(4.4f, 1, 4.4f);
//     //     ogl.AdjustPos();
//     // }
//     void Start()
//     {
//         StartCoroutine(GetGoogleMap());
//         rect = gameObject.GetComponent<RawImage>().rectTransform.rect;
//         mapWidth = (int)Math.Round(rect.width);
//         mapHeight = (int)Math.Round(rect.height);
//         // zoomInButton.onClick.AddListener(ZoomIn);
//         // zoomOutButton.onClick.AddListener(ZoomOut);
//         // GetGoogleMap();
//         // cam = GameObject.Find("Main Camera");
//         // zValue = -19f;

//         // Map.localScale = new Vector3(4.4f, 1, 4.4f);
//         ogl = GameObject.Find("Hex Manager").GetComponent<OnGridList>();
        
        
//     }

//     /*void ZoomIn()
//     {
//         if (cam.GetComponent<Camera>().fieldOfView > 15)
//         {
//             cam.GetComponent<Camera>().fieldOfView -= 20;
//             zoom += 1;
//         }
//         GetGoogleMap();
//     }
//     void ZoomOut()
//     {
//         zoom -= 1;
//         zValue -= 10;
//         cam.GetComponent<Camera>().fieldOfView += 20;
//         GetGoogleMap();
//     }*/

//     // Update is called once per frame
//     void Update()
//     {
        

//         // if (Input.GetKey(KeyCode.UpArrow))
//         // {
//         //     lat += 0.00005f;
//         //     GetGoogleMap();
//         //     Vector3 newPosition = cam.transform.position;
//         //     // newPosition.z += 1f; // or any other value to move the camera up
//         //     // cam.transform.position = newPosition;
//         // }
//         // if (Input.GetKey(KeyCode.DownArrow))
//         // {
//         //     lat -= 0.00005f;
//         //     GetGoogleMap();
//         //     Vector3 newPosition = cam.transform.position;
//         //     // newPosition.z -= 1f; // or any other value to move the camera down
//         //     // cam.transform.position = newPosition;
//         // }
//         // if (Input.GetKey(KeyCode.LeftArrow))
//         // {
//         //     lon -= 0.00005f;
//         //     GetGoogleMap();
//         //     Vector3 newPosition = cam.transform.position;
//         //     // newPosition.x -= 1f; // or any other value to move the camera to the left
//         //     // cam.transform.position = newPosition;
//         // }
//         // if (Input.GetKey(KeyCode.RightArrow))
//         // {
//         //     lon += 0.00005f;
//         //     GetGoogleMap();
//         //     Vector3 newPosition = cam.transform.position;
//         //     // newPosition.x += 1f; // or any other value to move the camera to the right
//         //     // cam.transform.position = newPosition;

//         // }
//         // if (Input.GetKey(KeyCode.z)) {
//         //     zoom += 1;
//         // }
//         // if (Input.GetKey(KeyCode.Z)) {
//         //     zoom -= 1;
//         // }


//         if (updateMap && (apiKeyLast != apiKey || !Mathf.Approximately(latLast, lat) || !Mathf.Approximately(lonLast, lon) || zoomLast != zoom || mapResolutionLast != mapResolution || mapTypeLast != mapType))
//         {
//             rect = gameObject.GetComponent<RawImage>().rectTransform.rect;
//             mapWidth = (int)Math.Round(rect.width);
//             mapHeight = (int)Math.Round(rect.height);
//             StartCoroutine(GetGoogleMap());
//             updateMap = false;
//         }
        


//     }


//     IEnumerator GetGoogleMap()
//     {
//         url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon + "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + mapResolution + "&maptype=" + mapType + "&key=" + apiKey;
//         mapIsLoading = true;
//         UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
//         yield return www.SendWebRequest();
//         if (www.result != UnityWebRequest.Result.Success)
//         {
//             Debug.Log("WWW ERROR: " + www.error);
//         }
//         else
//         {
//             mapIsLoading = false;
//             gameObject.GetComponent<RawImage>().texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

//             apiKeyLast = apiKey;
//             latLast = lat;
//             lonLast = lon;
//             zoomLast = zoom;
//             mapResolutionLast = mapResolution;
//             mapTypeLast = mapType;
//             updateMap = true;
//         }
//     }

// } ... code not in use


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class MapTile : MonoBehaviour
{
    public Button zoomInButton;
    public InputField inputField;
    public Button zoomOutButton;
    public GameObject cam;
    public float zValue;

    public string apiKey;
    public float lat = -33.85660618894087f;
    public float lon = 151.21500701957325f;
    public float zoom = 14;
    public enum resolution { low = 1, high = 2 };
    public resolution mapResolution = resolution.low;
    public enum type { roadmap, satellite, gybrid, terrain };
    public type mapType = type.roadmap;
    private string url = "";
    private int mapWidth = 640;
    private int mapHeight = 640;
    private bool mapIsLoading = false; //not used. Can be used to know that the map is loading 
    private Rect rect;
    

    private string apiKeyLast;
    private float latLast = -33.85660618894087f;
    private float lonLast = 151.21500701957325f;
    private float zoomLast = 14;
    private resolution mapResolutionLast = resolution.low;
    private type mapTypeLast = type.roadmap;
    private bool updateMap = true;      
    

    public OnGridList ogl;
    void Start()
    {
        zoomInButton.onClick.AddListener(ZoomIn);
        zoomOutButton.onClick.AddListener(ZoomOut);
        
        StartCoroutine(GetGoogleMap());
        rect = gameObject.GetComponent<RawImage>().rectTransform.rect;
        mapWidth = (int)Math.Round(rect.width);
        mapHeight = (int)Math.Round(rect.height);
       
        ogl = GameObject.Find("Hex Manager").GetComponent<OnGridList>();
        
        
    }

    void ZoomIn(){
        zoom+=1;
        updateMap = true;
        
    }
    void ZoomOut(){
        zoom-=1;
        updateMap = true;

    }

    
    void Update()
    {
        
        

        if (updateMap && (apiKeyLast != apiKey || !Mathf.Approximately(latLast, lat) || !Mathf.Approximately(lonLast, lon) || zoomLast != zoom || mapResolutionLast != mapResolution || mapTypeLast != mapType))
        {
            rect = gameObject.GetComponent<RawImage>().rectTransform.rect;
            mapWidth = (int)Math.Round(rect.width);
            mapHeight = (int)Math.Round(rect.height);
            StartCoroutine(GetGoogleMap());
            updateMap = false;
        }
        


    }


    IEnumerator GetGoogleMap()
    {
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon + "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + mapResolution + "&maptype=" + mapType + "&key=" + apiKey;
        mapIsLoading = true;
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("WWW ERROR: " + www.error);
        }
        else
        {
            mapIsLoading = false;
            gameObject.GetComponent<RawImage>().texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            apiKeyLast = apiKey;
            latLast = lat;
            lonLast = lon;
            zoomLast = zoom;
            mapResolutionLast = mapResolution;
            mapTypeLast = mapType;
            updateMap = true;
        }
    }

}
