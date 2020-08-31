using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeComponent : MonoBehaviour
{
    public float LifeValue;
    public float MaxLifeValue;
    public float CurrentMaxLifeValue;

    public Image Lifebar;

    // Start is called before the first frame update
    void Start()
    {
        MaxLifeValue = LifeValue;
        CurrentMaxLifeValue = MaxLifeValue;    
    }

    // Update is called once per frame
    void Update()
    {
        Lifebar.fillAmount = LifeValue / CurrentMaxLifeValue;

        if (LifeValue <= 0)
        {
            PlayerPrefs.SetFloat($"{DataManager.instance.PlayerName}Pontuacao", float.Parse(PlayerMove.instance.Points.text));
            PlayerPrefs.SetString("Morte", DateTime.Now.ToString());
            DataManager.instance.points = PlayerMove.instance.Points.text;
            GameOver();
        }
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}
