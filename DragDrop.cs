using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DragDrop : MonoBehaviourPunCallbacks
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    public CurrentHexInfo chi;
    public bool clickedOnce;
    public GameObject CurrentHex;
    public SelectedObject so;
    public string ObjectType;
    PhotonView view;
    public bool IsRedTeam;
    // public GameManagerr gameManager;

    private void Start()
    {
        clickedOnce = false;
        chi = GameObject.Find("Hex Manager").GetComponent<CurrentHexInfo>();
        so = GameObject.Find("Objects Info").GetComponent<SelectedObject>();
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (view.IsMine)
        {
            if (clickedOnce == false)
            {
                transform.GetComponent<Collider>().enabled = false;
                transform.position = MouseWorldPosition() + offset;

                if (Input.GetMouseButtonDown(0))
                {
                    clickedOnce = true;
                    SnapToHex();
                }
            }
        }
    }

    void OnMouseDown()
    {
        if (view.IsMine)
        {
            so.SelectObject(transform.gameObject);

            if (clickedOnce == true)
            {
                offset = transform.position - MouseWorldPosition();
                transform.GetComponent<Collider>().enabled = false;
            }
            else
            {
                SnapToHex();
            }
            GameManagerr gameManager = GameObject.Find("GameManager").GetComponent<GameManagerr>();
            gameManager.OnObjectMoved(gameObject);
        }
    }

    void OnMouseDrag()
    {
        if (view.IsMine)
            transform.position = MouseWorldPosition() + offset;
    }

    public bool IsOpponentInSameHex(GameObject currentHex, bool isRedTeam)
    {
        // Find all objects in the current hexagon
        Collider[] objectsInHex = Physics.OverlapBox(currentHex.transform.position, new Vector3(0.5f, 0.5f, 0.5f));

        // Loop through all objects in the hexagon
        foreach (Collider obj in objectsInHex)
        {
            // Check if the object is on the opposite team
            if (obj.CompareTag("Unit") && obj.GetComponent<Damage>() != null && obj.GetComponent<DragDrop>().IsRedTeam != isRedTeam)
            {
                return true;
            }
        }

        return false;
    }

    void OnMouseUp()
    {
        if (view.IsMine)
        {
            if (clickedOnce == true)
            {
                SnapToHex();
            }
        }
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    public void SnapToHex()
    {
        if (IsRedTeam == true)
        {
            transform.position = chi.HexCentreToWorld;
        }
        else if (IsRedTeam == false)
        {
            transform.position = chi.HexOtherCentreToWorld;
        }

        transform.GetComponent<Collider>().enabled = true;
        CurrentHex = chi.CurrentHex;
    }
}
