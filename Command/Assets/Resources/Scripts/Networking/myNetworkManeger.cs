using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class myNetworkManeger : NetworkManager
{
    int i = 0;
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject player;
        PlayerOptions Options = gameObject.GetComponent<PlayerOptions>();
        if (i == 0)

        {
            //player = Instantiate(Resources.Load("Players/testPlayer"), transform.position, Quaternion.identity) as GameObject;
            player = Instantiate(Resources.Load("Players/VRPlayer"), transform.position, Quaternion.identity) as GameObject;
            i++;
        }
        else 
        {
            //player = Instantiate(Resources.Load("Players/VRPlayer"), transform.position, Quaternion.identity) as GameObject;
            player = Instantiate(Resources.Load("Players/testPlayer"), transform.position, Quaternion.identity) as GameObject;
            bool networkman = GameObject.FindGameObjectWithTag("VRPlayer").GetComponent<NetworkIdentity>().isClient;
            
            if (networkman)
            {
                var camera = GameObject.FindGameObjectWithTag("strategyCam").GetComponent<Camera>();
                camera.enabled = false;
            }
        }
            


        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }
    //Dictionary<int, int> currentPlayers;
    //public override GameObject OnLobbyServerCreateLobbyPlayer(NetworkConnection conn, short playerControllerId)
    //{
    //    if (!currentPlayers.ContainsKey(conn.connectionId))
    //        currentPlayers.Add(conn.connectionId, 0);

    //    return base.OnLobbyServerCreateLobbyPlayer(conn, playerControllerId);
    //}

    //public void SetPlayerTypeLobby(NetworkConnection conn, int _type)
    //{
    //    if (currentPlayers.ContainsKey(conn.connectionId))
    //        currentPlayers[conn.connectionId] = _type;
    //}

    //public override GameObject OnLobbyServerCreateGamePlayer(NetworkConnection conn, short playerControllerId)
    //{
    //    int index = currentPlayers[conn.connectionId];

    //    GameObject _temp = (GameObject)GameObject.Instantiate(spawnPrefabs[index],
    //        startPositions[conn.connectionId].position,
    //        Quaternion.identity);

    //    NetworkServer.AddPlayerForConnection(conn, _temp, playerControllerId);

    //    return _temp;
    //}
}
