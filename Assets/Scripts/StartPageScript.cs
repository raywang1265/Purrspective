using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine.SceneManagement; // For loading scenes

public class StartPageScript : MonoBehaviour
{
    [Header("UI Elements")]
    public Button hostButton;
    public Button clientButton;

    void Start()
    {
        // Assign button listeners
        hostButton.onClick.AddListener(StartHost);
        clientButton.onClick.AddListener(StartClient);

        // Update status text
        UpdateStatus("Waiting for input...");
    }

    void StartHost()
    {
        UpdateStatus("Starting Host...");
        if (NetworkManager.Singleton.StartHost())
        {
            UpdateStatus("Host started successfully.");

            // Register callback to detect client connections
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        }
        else
        {
            UpdateStatus("Failed to start host.");
        }
    }

    void StartClient()
    {
        UpdateStatus("Starting Client...");
        
        // Set public IP
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData("100.66.196.211", 7777);
        if (NetworkManager.Singleton.StartClient())
        {
            UpdateStatus("Client started successfully. Connecting...");
        }
        else
        {
            UpdateStatus("Failed to start client.");
        }
    }

    void OnClientConnected(ulong clientId)
    {
        UpdateStatus($"Client {clientId} connected!");

        // Check if this is the first client to connect
        if (NetworkManager.Singleton.ConnectedClients.Count == 2) // Host + 1 client
        {
            UpdateStatus("All players connected. Loading level...");
            NetworkManager.Singleton.SceneManager.LoadScene("level", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }

    void UpdateStatus(string message)
    {
        Debug.Log(message);
    }
}