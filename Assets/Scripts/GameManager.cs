using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 목표 : 플레이어가 얻은 점수를 저장한다.
// 필요속성 : 타격점수, 최고점수, 점수, 처치점수
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int attackScore = 0;
    private int destroyScore = 0;
    private int bestScore;

    public TMP_Text attackScoreText;
    public TMP_Text destroyScoreText;
    public TMP_Text bestScoreText;

    public GameObject player;

    public EndingScreen endingScreen;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        attackScoreText.text = "0";
        destroyScoreText.text = "0";
        bestScore = PlayerPrefs.GetInt("Best Score");
        bestScoreText.text = bestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetDestroyScore()
    {
        return destroyScore;
    }

    public void SetDestroyScore()
    {
        destroyScore += 100;
        destroyScoreText.text = destroyScore.ToString();
    }

    public int GetAttackScore()
    {
        return attackScore;
    }

    public void SetAttackScore()
    {
        attackScore += 10;
        attackScoreText.text = attackScore.ToString();
    }

    public int GetBestScore()
    {
        return bestScore;
    }

    public void SetBestScore()
    {
        bestScore = attackScore + destroyScore;
        bestScoreText.text = bestScore.ToString();

        int tempBestScore = PlayerPrefs.GetInt("Best Score");
        if(bestScore > tempBestScore)
        {
            PlayerPrefs.SetInt("Best Score", bestScore);
        }

        bestScoreText.text = bestScore.ToString();
    }

    public void GameOver()
    {
        endingScreen.gameObject.SetActive(true);
        endingScreen.scoreText.text = bestScore.ToString();
    }

    public void Restart()
    {
        endingScreen.gameObject.SetActive(false);

        player.SetActive(true);
        player.GetComponent<PlayerMove>().hp = 10;
        player.GetComponent<PlayerFire>().skillLevel = 0;

        destroyScore = 0;
        attackScore = 0;
        bestScore = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
