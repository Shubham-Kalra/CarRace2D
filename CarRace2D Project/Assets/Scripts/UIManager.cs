using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scoreText;
    bool gameOver;
    int score;
    public Button[] buttons;
    public Button ResumeButton;
    public Button PauseButton;

    public AudioManager am;

    public Button Left;
    public Button Right;

    // Use this for initialization
    void Start () {
        score = 0;
        gameOver = false;
        InvokeRepeating("scoreUpdate", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score:" + score;
	}

    void scoreUpdate()
    {
        if(!gameOver)                           // if(gameOver == false)
        score += 1;
    }

    public void GameOverActivated()
    {
        gameOver = true;
        foreach(Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
        ResumeButton.gameObject.SetActive(false);

        Left.gameObject.SetActive(false);
        Right.gameObject.SetActive(false);

        PauseButton.interactable = false;

    }

    public void Play()
    {
        Application.LoadLevel(1);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            foreach (Button button in buttons)
                button.gameObject.SetActive(true);
            ResumeButton.gameObject.SetActive(true);

            am.carAcc.Stop();

            Left.gameObject.SetActive(false);
            Right.gameObject.SetActive(false);
        }
            
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            foreach (Button button in buttons)
                button.gameObject.SetActive(false);
            ResumeButton.gameObject.SetActive(false);
            am.carAcc.Play();

            //Left.gameObject.SetActive(true);
            //Right.gameObject.SetActive(true);
        }
    }

    public void Menu()
    {
        Application.LoadLevel(0);
    }

    public void Replay()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }

    public void Resume()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            foreach (Button button in buttons)
                button.gameObject.SetActive(false);
            ResumeButton.gameObject.SetActive(false);
            am.carAcc.Play();

            //Left.gameObject.SetActive(true);
            //Right.gameObject.SetActive(true);
        }
        else if (Time.timeScale == 1)
        {
            Time.timeScale = 1;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
