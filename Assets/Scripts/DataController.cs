using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DataController : MonoBehaviour
{

    public static DataController ornek;


    private const string High_Score = "High Score";
    void Awake()
    {
        TekilNesne();
        OyunIlkDefaBasladi();
    }
    void TekilNesne()
    {
        if (ornek != null)
        {
            Destroy(gameObject);
        }
        else
        {
            ornek = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    void OyunIlkDefaBasladi()
    {
        if (PlayerPrefs.HasKey("OyunIlkDefaBasladi"))
        {
            PlayerPrefs.SetInt(High_Score, 0);
            PlayerPrefs.SetInt("OyunIlkDefaBasladi", 0);
        }
    }

    public void setHighScore(int score)
    {
        PlayerPrefs.SetInt(High_Score, score);
    }

    public int getHighScore()
    {
        return PlayerPrefs.GetInt(High_Score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
