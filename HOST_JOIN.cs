/*using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class HOST_JOIN : MonoBehaviourPunCallbacks
{
    public GameObject hostMenu;
    public GameObject joinedMenu;
    public TMP_InputField input_create;
    public TMP_InputField input_join;

    public void CreateRoom()
    {
        // Connect to the PUN server
        PhotonNetwork.CreateRoom(input_create.text, new RoomOptions() { MaxPlayers = 2, IsVisible = true, IsOpen = true }, TypedLobby.Default, null);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(input_join.text);
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // Display the host menu if the current player is the host
            hostMenu.SetActive(true);
            joinedMenu.SetActive(false);
        }
        else
        {
            // Display the joined menu if the current player is a joined player
            hostMenu.SetActive(false);
            joinedMenu.SetActive(true);
        }
    }
}*/








using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;



public class HOST_JOIN : MonoBehaviourPunCallbacks
{
    public TMP_InputField input_create;
    public TMP_InputField input_join;
    

    // [SerializeField] private Button joinButton;
    // [SerializeField] private Button hostButton;

    public void CreateRoom()
    {   
        // Connect to the PUN server
        PhotonNetwork.CreateRoom(input_create.text , new RoomOptions() {MaxPlayers = 2 , IsVisible = true , IsOpen = true} , TypedLobby.Default , null);
        MenuHandler.isHost = true;

    }
    public void JoinRoom(){
        PhotonNetwork.JoinRoom(input_join.text);
        MenuHandler.isHost = false;
    }
    public override void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("MainGame");
        
    }
    
    
    
    
}