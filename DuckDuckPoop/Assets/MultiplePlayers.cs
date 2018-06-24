using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultiplePlayers : NetworkManager {


    

        //Debug.Log("On clinet connect executed");
        //NetworkMessage test = new NetworkMessage();
        //test.model = 1;
        //ClientScene.AddPlayer(conn, 0, test);
        ////base.OnClientConnect(conn);


    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    {
        Debug.Log("On server add player executed");
        NetworkMessage message = extraMessageReader.ReadMessage<NetworkMessage>();
        int mes = message.model;
        GameObject player = Instantiate(spawnPrefabs[mes]) as GameObject;
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        //base.OnServerAddPlayer(conn, playerControllerId, extraMessageReader);
    }
    //   // #TODO - Add multiple players 
    //   enum Location
    //   {
    //       SERVER,
    //       CLIENT
    //   };

    //   public Transform[] Models; 
    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}

    //public void OVer

    //public void OnServerInitialized()
    //{
    //    Debug.Log("SERVER INITIALIZED");
    //    Network.Instantiate(Models[0], Models[0].position, Models[0].rotation, 0);
    //}

    //public void OnConnectedToServer()
    //{
    //    Network.Instantiate(Models[1], Models[1].position, Models[1].rotation, 0);
    //}

    //public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    //{
    //    base.OnServerAddPlayer(conn, playerControllerId);

    //}


}
