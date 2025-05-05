using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField]


    private Text scoreText, endText , bestScoreText, gameOverText;
    public Image HelpIcon;


    [SerializeField]

    private GameObject restartButton, pauseButton; /// button

    [SerializeField]

    private GameObject pausePanel;

    [SerializeField]

    private Sprite[] medalIcon;

    [SerializeField]

    private Image medal;

    
    private void Awake()
    {
       MakeInstance();
        HelpIcon.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void MakeInstance()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    public void PauseGame()
    {
        if (BirdScript.instance != null)
        {
            if (BirdScript.instance.isAlive)
            {

                pausePanel.SetActive(true);

                Time.timeScale = 0;
                endText.text = "" + BirdScript.instance.score;
                bestScoreText.text = "" + DataController.ornek.getHighScore();

               
                restartButton.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
                restartButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => ResumeGame());

            }
        }
    }

    public void GoToMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("PlayScreen");
        gameOverText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true) ;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        HelpIcon.gameObject.SetActive(false);
    }
    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowScore(int score)
    {
        pausePanel.SetActive(true);

        endText.text = "" + BirdScript.instance.score;

        gameOverText.gameObject.SetActive(true );

        scoreText.gameObject.SetActive(false) ;

        if (score > DataController.ornek.getHighScore())
        {
            DataController.ornek.setHighScore(score);
        }

        bestScoreText.text = "" + DataController.ornek.getHighScore();

        if (score <= 10)
        {
            medal.sprite = medalIcon[0];
        }
        else if (score > 10 && score < 30)
        {
            medal.sprite = medalIcon[1];
        }
        else
        {
            medal.sprite = medalIcon[2];
        }

        restartButton.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners(); //
        restartButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => RestartGame()); //
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
