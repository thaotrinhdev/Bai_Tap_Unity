using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField] private GameObject view;
    public static bool GameIsPause = false;
    // Start is called before the first frame update
    void Start()
    {
        view.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Play()
    {
        view.SetActive(false);
        Application.LoadLevel(1);
    }
    public void Close()
    {
        view.SetActive(true);

    }
}
