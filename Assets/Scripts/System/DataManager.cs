using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public Text UIPlayerName;

    public GameObject PlayerNameForm;

    public const string PlayerNameKey = "PlayerName";
    public string PlayerName;

    public Dictionary<string, int> HighScores;

    //public int[] HighScores;
    public int[] LastsScores;

    public Text UIGameOverDate;
    public Text UIGameOverPoints;

    public string points;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //Estou na primeira tela
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (!PlayerPrefs.HasKey(PlayerNameKey))
            {
                GlobalVariables.instance.ShowPlayerForm();
            }
            else
            {
                //GameObject.Find("PlayerName").GetComponent<Text>().text = $"Seja bem vindo {PlayerPrefs.GetString(PlayerNameKey)}";
                PlayerName = PlayerPrefs.GetString(PlayerNameKey, "Jogador");
                UIPlayerName.GetComponent<Text>().text = $"Seja bem vindo {PlayerName} !";
            };
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetupPlayerName(Text NameInformed)
    {
        if (NameInformed != null && NameInformed.text != "")
        {
            PlayerPrefs.SetString(PlayerNameKey, NameInformed.text);
            UIPlayerName.GetComponent<Text>().text = $"Seja bem vindo {PlayerPrefs.GetString(PlayerNameKey)} !";
            PlayerNameForm.SetActive(false);
        }
    }

    void setupDeath()
    {
        UIGameOverDate = GameObject.Find("TextGameOver").GetComponent<Text>();
        UIGameOverPoints = GameObject.Find("TextPointsGameOver").GetComponent<Text>();
        if (UIGameOverDate != null)
        {
            UIGameOverDate.text = DateTime.Now.ToString();
        }

        if (UIGameOverPoints != null)
        {
            UIGameOverPoints.text = points;
        }
    }

    public void OnLevelWasLoaded()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            setupDeath();
        }

        if (SceneManager.GetActiveScene().name == "RecordsScene")
        {

        }
    }
}
