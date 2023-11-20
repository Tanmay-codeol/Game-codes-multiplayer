// using Photon.Realtime;
// using Photon.Pun;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PhotonLobby : MonoBehaviourPunCallbacks
// {
//     public static PhotonLobby lobby;

//     public GameObject battleButton;
//     public GameObject cancelButton;

//     public void Awake()
//     {
//         lobby = this;
//     }

//     void Start()
//     {
//         PhotonNetwork.ConnectUsingSettings();
//     }

//     public override void OnConnectedToMaster()
//     {
//         Debug.Log("player has connected");
//         battleButton.SetActive(true);


//     }

//     public void OnBattleButtonClicked()
//     {
//         battleButton.SetActive(false);
//         cancelButton.SetActive(true);
//         PhotonNetwork.JoinRandomRoom();
//         Debug.Log("test");
//     }
//     public override void OnJoinRandomFailed(short returnCode, string message)
//     {
//         Debug.Log("Tried to join random but fail");
//         CreateRoom();
//     }
//     void CreateRoom()
//     {
//         int randomRoomName = Random.Range(0, 10000);
//         // RoomOptions roomOps = new RoomOptions(){ IsVisible = true , Isopen = true , MaxPlayers = 2};
//         RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };

//         // PhotonNetwork.CreateRoom(null, new RoomOptions());
//         PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
//     }

//     public override void OnCreateRoomFailed(short returnCode, string message)
//     {
//         Debug.Log("tried to create room but failed");



//     }
//     // public void OnBattleButtonClicked(){
//     //     cancelButton.SetActive(false);
//     //     battleButton.SetActive(true);

//     //     PhotonNetwork.LeaveRoom();



//     // }
//     public void OnCancelButtonClicked()
//     {
//         cancelButton.SetActive(false);
//         battleButton.SetActive(true);
//         PhotonNetwork.LeaveRoom();

//     }


//     void Update()
//     {

//     }
// }
