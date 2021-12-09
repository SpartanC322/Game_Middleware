using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();

        Debug.Log("Connecting to Photon Network");

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel(0);
    }






    //public GameObject roomJoinUI;
    //public Text connectionStatus;
    //public Text roomNameField;
    //public Text playerStatus;

    //string playerName;
    //string roomName;
    //string gameVersion;
    //private bool isConnecting;
    //private Button buttonLoadArena;
    //private Button buttonJoinRoom;

    //// Start Method
    //void Start()
    //{
    //    //1
    //    PlayerPrefs.DeleteAll();

    //    Debug.Log("Connecting to Photon Network");

    //    //2
    //    roomJoinUI.SetActive(false);

    //    //3
    //    ConnectToPhoton();
    //}

    //void Awake()
    //{
    //    //4 
    //    PhotonNetwork.AutomaticallySyncScene = true;
    //}

    //// Helper Methods
    //public void SetPlayerName(string name)
    //{
    //    playerName = name;
    //}

    //public void SetRoomName(string name)
    //{
    //    roomName = name;
    //}

    //// Tutorial Methods
    //void ConnectToPhoton()
    //{
    //    connectionStatus.text = "Connecting...";
    //    PhotonNetwork.GameVersion = gameVersion; //1
    //    PhotonNetwork.ConnectUsingSettings(); //2
    //}

    //public void JoinRoom()
    //{
    //    if (PhotonNetwork.IsConnected)
    //    {
    //        PhotonNetwork.LocalPlayer.NickName = playerName; //1
    //        Debug.Log("PhotonNetwork.IsConnected! | Trying to Create/Join Room " +
    //            roomNameField.text);
    //        RoomOptions roomOptions = new RoomOptions(); //2
    //        TypedLobby typedLobby = new TypedLobby(roomName, LobbyType.Default); //3
    //        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, typedLobby); //4
    //    }
    //}

    //public void LoadArena()
    //{
    //    // 5
    //    if (PhotonNetwork.CurrentRoom.PlayerCount > 1)
    //    {
    //        PhotonNetwork.LoadLevel("MainArena");
    //    }
    //    else
    //    {
    //        playerStatus.text = "Minimum 2 Players required to Load Arena!";
    //    }
    //}

    //// Photon Methods
    //public override void OnConnected()
    //{
    //    // 1
    //    base.OnConnected();
    //    // 2
    //    connectionStatus.text = "Connected to Photon!";
    //    connectionStatus.color = Color.green;
    //    roomJoinUI.SetActive(true);
    //}

    //public override void OnDisconnected(DisconnectCause cause)
    //{
    //    // 3
    //    isConnecting = false;
    //    Debug.LogError("Disconnected. Please check your Internet connection.");
    //}

    //public override void OnJoinedRoom()
    //{
    //    // 4
    //    if (PhotonNetwork.IsMasterClient)
    //    {
    //        buttonLoadArena.enabled = true;
    //        buttonJoinRoom.enabled = false;
    //        playerStatus.text = "You are Lobby Leader";
    //    }
    //    else
    //    {
    //        playerStatus.text = "Connected to Lobby";
    //    }
    //}

}
