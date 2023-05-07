using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("ER");
    }
    public void Exit()
    {
        Application.Quit();
    }
}