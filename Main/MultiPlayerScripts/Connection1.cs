using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Connection : MonoBehaviourPunCallbacks, IMatchmakingCallbacks, ILobbyCallbacks
{

    private byte MaPlayerr =4;
    public int currentPlayer;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = "0.0.1";

    }

    // Update is called once per frame
    void Update()
    {
        // int num;
        Debug.Log(currentPlayer);
        DontDestroyOnLoad(this.gameObject);
        Debug.Log(PhotonNetwork.CountOfPlayersInRooms + "main hu");
        Debug.Log(PhotonNetwork.CurrentRoom);
    }
    #region Callback
    public override void OnConnectedToMaster()
    {
        Debug.Log("MasterConnect");
        //  PhotonNetwork.JoinRoom("someRoom");
    
        //  PhotonNetwork.JoinOrCreateRoom();
        PhotonNetwork.JoinLobby();
       

    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
       // PhotonNetwork.Instantiate("Player", transform.position, Quaternion.identity);
        Debug.Log("New Room Creted");

    }
    public override void OnJoinedLobby()
    {
        //   JoinRoom();
       
          //  LobbyPanel.SetActive(true);
       
        Debug.Log("Im in Lobby");
        
        PhotonNetwork.JoinRandomRoom();

    }
   

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("JoinRoom");

        


            string RoomName = "Room" + Random.Range(1, 20000);

            RoomOptions option = new RoomOptions { MaxPlayers = MaPlayerr };
        PhotonNetwork.JoinOrCreateRoom(RoomName, option, null);

      
    }

    public override void OnCreatedRoom()
    {

        Debug.Log(currentPlayer + "In Room");
        Debug.Log("im in created room");
        photonView.RPC("AddCurrentPlayer", RpcTarget.All);
       

    }
    public virtual void OnPhotonSerializeView(PhotonStream photonStream, PhotonMessageInfo photonMessageInfo)
    {
        if (photonStream.IsReading)
        {
            currentPlayer = (int)photonStream.ReceiveNext();
        }
        if (photonStream.IsWriting)
        {
            photonStream.SendNext(currentPlayer);
        }
    }

    #endregion




    public override void OnJoinedRoom()
    {
     
        Debug.Log("Im in Room");
      
      
            PhotonNetwork.Instantiate("Players", transform.position, Quaternion.identity);
      //  }
       
      
          
        

      
    }
    [PunRPC]
    public void AddCurrentPlayer()
    {
        currentPlayer++;
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnect to server");
    }
  
}
