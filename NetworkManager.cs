// // using UnityEngine;
// // using Photon.Pun;
// // using Photon.Realtime;
// // using TMPro;
// // using UnityEngine.UI;

// // public class NetworkManager : MonoBehaviourPunCallbacks
// // {
// //     [SerializeField] private TMP_InputField roomNameInput;
// //     [SerializeField] private Button joinButton;
// //     [SerializeField] private Button hostButton;

// //     private void Start()
// //     {
// //         // Connect to the PUN server
// //         PhotonNetwork.ConnectUsingSettings();

// //         // Set up button click events
// //         joinButton.onClick.AddListener(JoinRoom);
// //         hostButton.onClick.AddListener(CreateRoom);
// //     }

// //     // Callback when successfully connected to the PUN server
// //     public override void OnConnectedToMaster()
// //     {
// //         Debug.Log("Connected to PUN server");
// //     }

// //     // Join a room with a specific room name
// //     public void JoinRoom()
// //     {
// //         string roomName = roomNameInput.text;
// //         if (string.IsNullOrEmpty(roomName))
// //         {
// //             Debug.LogError("Room name is empty");
// //             return;
// //         }

// //         PhotonNetwork.JoinRoom(roomName);
// //     }

// //     // Create a new room with a specific room name
// //     public void CreateRoom()
// //     {
// //         string roomName = roomNameInput.text;
// //         if (string.IsNullOrEmpty(roomName))
// //         {
// //             Debug.LogError("Room name is empty");
// //             return;
// //         }

// //         PhotonNetwork.CreateRoom(roomName, new RoomOptions { MaxPlayers = 2 });
// //     }

// //     // Callback when failed to join a room
// //     public override void OnJoinRoomFailed(short returnCode, string message)
// //     {
// //         Debug.Log("Failed to join room: " + message);
// //     }

// //     // Callback when successfully joined a room
// //     public override void OnJoinedRoom()
// //     {
// //         Debug.Log("Joined room " + PhotonNetwork.CurrentRoom.Name);
// //     }

// //     // Callback when a new player joins the room
// //     public override void OnPlayerEnteredRoom(Player newPlayer)
// //     {
// //         Debug.Log("New player joined the room: " + newPlayer.NickName);
// //     }
// // }


// using UnityEngine;
// using Photon.Pun;
// using Photon.Realtime;
// using TMPro;
// using UnityEngine.UI;




// public class NetworkManager : MonoBehaviourPunCallbacks
// {
//     public TMP_InputField roomNameInput;

//     // [SerializeField] private Button joinButton;
//     // [SerializeField] private Button hostButton;

//     public void CreateRoom()
//     {   
//         // Connect to the PUN server
//         PhotonNetwork.CreateRoom(roomNameInput.text);
//     }
//     public void JoinRoom(){
//         PhotonNetwork.JoinRoom(roomNameInput.text);

//     }
//     public override void OnJoinedRoom(){
//         PhotonNetwork.LoadLevel("MainGame");
        
//     }
    
    
    
    
// }