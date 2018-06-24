using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class NetworkCustom : NetworkManager
{

    public int chosenCharacter = 0;
    public GameObject[] characters;

    //subclass for sending network messages
    public class NetworkMessage : MessageBase
    {
        public int chosenClass;
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    {
        NetworkMessage message = extraMessageReader.ReadMessage<NetworkMessage>();
        int selectedClass = message.chosenClass;
        Debug.Log("server add with message " + selectedClass);
        Debug.Log("Player Controller ID - " + playerControllerId);

        GameObject player;
        Transform startPos = GetStartPosition();

        // Based on the player controller ID change the prefab to be loaded

        if (startPos != null)
        {
            player = Instantiate(characters[chosenCharacter], startPos.position, startPos.rotation) as GameObject;
        }
        else
        {
            player = Instantiate(characters[chosenCharacter], Vector3.zero, Quaternion.identity) as GameObject;

        }
        if(chosenCharacter < 1)
            player.transform.position = new Vector3(0.0f, 11.0f, 0.0f);
        else
            player.transform.position = new Vector3(2.0f, 11.0f, 0.0f);

        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);

    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("OnClientConnectCalled");
        NetworkMessage test = new NetworkMessage();
        test.chosenClass = chosenCharacter;

        ClientScene.AddPlayer(conn, 0, test);
        chosenCharacter = 1;
    }


    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        Debug.Log("OnClientSceneChanged Called");
        //base.OnClientSceneChanged(conn);
    }

    public void btn1()
    {
        chosenCharacter = 0;
    }

    public void btn2()
    {
        chosenCharacter = 1;
    }
}