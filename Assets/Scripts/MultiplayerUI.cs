using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class MultiplayerUI : MonoBehaviour
{
    [Header("UI Elements")]
    public Button hostButton;
    public Button clientButton;
    public Button serverButton;
    // public Text statusText;

    void Start()
    {
        // Assign button listeners
        hostButton.onClick.AddListener(StartHost);
        clientButton.onClick.AddListener(StartClient);
        serverButton.onClick.AddListener(StartServer);

        // Update status text
        UpdateStatus("Waiting for input...");
    }

    void StartHost()
    {
        UpdateStatus("Starting Host...");
        if (NetworkManager.Singleton.StartHost())
        {
            UpdateStatus("Host started successfully.");
        }
        else
        {
            UpdateStatus("Failed to start host.");
        }
    }

    void StartClient()
    {
        UpdateStatus("Starting Client...");
        if (NetworkManager.Singleton.StartClient())
        {
            UpdateStatus("Client started successfully. Connecting...");
        }
        else
        {
            UpdateStatus("Failed to start client.");
        }
    }

    void StartServer()
    {
        UpdateStatus("Starting Server...");
        if (NetworkManager.Singleton.StartServer())
        {
            UpdateStatus("Server started successfully.");
        }
        else
        {
            UpdateStatus("Failed to start server.");
        }
    }

    void UpdateStatus(string message)
    {
        // if (statusText != null)
        // {
        //     statusText.text = message;
        // }
        Debug.Log(message);
    }
}
