using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameStartUI : NetworkManager {


    NetworkManager manager;
    public InputField ip; 
    void Awake()
    {
        manager = GetComponent<NetworkManager>();
        manager.networkAddress = "192.168.43.116";
        manager.networkPort = 7777;
    }


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ip.text = manager.networkAddress;
	}

    public void startHost()
    {
        manager.StartHost();
    }

    public void startClient()
    {
        manager.networkAddress = ip.text;
        manager.StartClient();
    }
}
