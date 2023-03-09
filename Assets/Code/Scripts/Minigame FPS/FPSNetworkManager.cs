using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class FPSNetworkManager : MonoBehaviourPunCallbacks {

    [SerializeField] private GameObject fpsVRPlayerPrefab;
    [Space]
    [SerializeField] private Transform spawnPoint;

    
    private void Start() {
        Debug.Log("JOINED MINIGAME");
        GameObject _player = PhotonNetwork.Instantiate(fpsVRPlayerPrefab.name, spawnPoint.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
    }

    public override void OnJoinRoomFailed(short returnCode, string message) {
        PhotonNetwork.LoadLevel("Lobby Scene");
    }

    public override void OnLeftRoom() {
        PhotonNetwork.Disconnect();
    }
    
    public override void OnDisconnected(DisconnectCause cause) {
        PhotonNetwork.LoadLevel("Lobby Scene");
    }

}