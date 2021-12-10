using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;
    public InputField playerName;

    public void CreateRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.CreateRoom(createInput.text, new RoomOptions());
            Debug.Log("Creating Room " + createInput.text);
        }
    }

    public void JoinRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRoom(joinInput.text);
            Debug.Log("Joining Room " + joinInput.text);
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LocalPlayer.NickName = playerName.text;
        PhotonNetwork.LoadLevel("Room for 1");
    }

    public void LeaveRoom()
    {
        SceneManager.LoadScene("MySceneAnimation");
    }
}