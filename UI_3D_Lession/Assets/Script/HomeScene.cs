using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScene : MonoBehaviour
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

    }
}
