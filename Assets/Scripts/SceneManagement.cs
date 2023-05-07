using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject MainVol, GameOver;

    public float pathSpeed;

    public static SceneManagement Instance;
    int pressCount;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Instance = this;
        MainVol.SetActive(true);
        GameOver.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pressCount++;

            if( pressCount == 2 )
            {
                Application.Quit();
            }

            Invoke("pressCount", 2f);
        }
    }

    void pressReset()
    {
        pressCount = 0;
    }

    public void ShowGameOverUI()
    {
        MainVol.SetActive(false);
        GameOver.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
