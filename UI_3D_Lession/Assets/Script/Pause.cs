using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject go;
    public static bool GameIsPause = false;
    // Start is called before the first frame update
    void Start()
    {
        go.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Menu()
    {
        go.SetActive(true);
        Time.timeScale = 0; // Pause Time
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    public void Resume()
    {
        go.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Retry()
    {
        Application.LoadLevel(1);
        Time.timeScale = 1.0f;
    }
}
