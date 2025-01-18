using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayGameScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    
}
