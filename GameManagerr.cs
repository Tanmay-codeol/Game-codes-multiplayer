using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManagerr : MonoBehaviourPunCallbacks
{
    // Keep track of the last game object that was moved
      public PhotonView photonView;
    public GameObject lastMoved;

    public void Start(){
        photonView = GetComponent<PhotonView>();
    }

    // Called when an object is clicked to move
    public void OnObjectMoved(GameObject movedObject)
    {
        // Set the lastMoved variable to the moved object
        lastMoved = movedObject;
         if (photonView.IsMine)
        {
            photonView.RPC("UpdateLastMoved", RpcTarget.Others, movedObject.GetPhotonView().ViewID);
        }
    }

    // Called when a collision occurs between two game objects
    public void OnObjectCollision(GameObject object1, GameObject object2)
    {
        // Get the Damage components of both game objects
        Damage damage1 = object1.GetComponent<Damage>();
        Damage damage2 = object2.GetComponent<Damage>();

        // Only deal damage if the lastMoved object is colliding with another object
        if (lastMoved != null && lastMoved == object1 && object2.name.Contains("(blue)"))
        {
            damage2.photonView.RPC("TakeDamage", RpcTarget.All, damage1.damage);
            damage2.slider.value = damage2.health;
            PhotonNetwork.Destroy(object2);
             lastMoved = null;

            if (damage2.health <= 0)
            {
                // Call the PhotonRPC method to destroy the game object across the network
                PhotonView photonView = object2.GetComponent<PhotonView>();
                photonView.RPC("DestroyObject", RpcTarget.AllBuffered, object2.GetPhotonView().ViewID);
            }
            Debug.Log("Red damaged blue!");
        }
        else if (lastMoved != null && lastMoved == object2 && object1.name.Contains("(red)"))
        {
            damage1.photonView.RPC("TakeDamage", RpcTarget.All, damage2.damage);
            damage1.slider.value = damage1.health;
            PhotonNetwork.Destroy(object1);
             lastMoved = null;
            if (damage1.health <= 0)
            {
                // Call the PhotonRPC method to destroy the game object across the network
                PhotonView photonView = object1.GetComponent<PhotonView>();
                photonView.RPC("DestroyObject", RpcTarget.AllBuffered, object1.GetPhotonView().ViewID);
            }
            Debug.Log("Blue damaged red!");
        }
    }
    [PunRPC]
    private void UpdateLastMoved(int viewID)
    {
        PhotonView photonView = PhotonView.Find(viewID);
        lastMoved = photonView.gameObject;
    }

    [PunRPC]
    void DestroyObject(int viewID)
    {
        PhotonView photonView = PhotonView.Find(viewID);
        PhotonNetwork.Destroy(photonView);
    }
}
