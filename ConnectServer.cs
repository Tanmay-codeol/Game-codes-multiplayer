/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectServer : MonoBehaviourPunCallbacks
{
    public GameObject hostMenu;
    public GameObject joinedMenu;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // Display the host menu if the current player is the host
            GameObject.Find(hostMenu.transform.name).SetActive(true);
            GameObject.Find(joinedMenu.transform.name).SetActive(false);
        }
        else
        {
            // Display the joined menu if the current player is a joined player
            GameObject.Find(hostMenu.transform.name).SetActive(false);
            GameObject.Find(joinedMenu.transform.name).SetActive(true);
        }
    }
}*/






using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;



public class ConnectServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

    }
    public override void OnConnectedToMaster(){
        PhotonNetwork.JoinLobby();

    }
    public override void OnJoinedLobby(){
        SceneManager.LoadScene("Lobby");
        

    }

    
}
