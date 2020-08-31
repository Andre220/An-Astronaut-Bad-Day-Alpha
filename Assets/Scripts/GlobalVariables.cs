
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVariables : MonoBehaviour
{
    public static GlobalVariables instance;

    public GameObject PlayerNameForm;

    public Transform TargetTransform;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPlayerForm()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayerNameForm.SetActive(true);
        }
    }

    public void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "GameplayScene")
        {
            TargetTransform = GameObject.Find("NavePivot").transform;
        }
    }
}
