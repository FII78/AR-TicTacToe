using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NetworkManagerScript : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text TextInfos;
    
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

     #region PUN2 CallBacks
    public override void OnConnected()  // Has reached internett
    {
        //base.OnConnected();
        TextInfos.text = "Connected...";
    }

    public override void OnConnectedToMaster()
    {
        TextInfos.text = "Connected to Master";
        //PhotonNetwork.JoinLobby(TypedLobby.Default);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom("TicTacToe", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        TextInfos.text = "Joined Lobby...";
    }

    public override void OnJoinedRoom()
    {
        TextInfos.text = "Joined Room...";
        if(PhotonNetwork.PlayerList.Length > 1)
        {
            PhotonNetwork.LocalPlayer.NickName = "Black";
            StartCoroutine(SpawnMyPlayer());
        }
        else
        {
            PhotonNetwork.LocalPlayer.NickName = "White";
            StartCoroutine(SpawnMyPlayer2());
        }
        TextInfos.text = PhotonNetwork.LocalPlayer.NickName + " Joined Room " + PhotonNetwork.CurrentRoom.Name + " now containing " + PhotonNetwork.CountOfPlayers.ToString();

        //PhotonNetwork.LoadLevel(1);  //Index of scene in building list
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
    }

    #endregion

    IEnumerator SpawnMyPlayer()
    {
        yield return new WaitForSeconds(1f);
    }
    IEnumerator SpawnMyPlayer2()
    {
        yield return new WaitForSeconds(1f);
    }

}
