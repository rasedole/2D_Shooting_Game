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
        attackScoreText.text = "0";
        destroyScoreText.text = "0";
        bestScore = PlayerPrefs.GetInt("Best Score");
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

        int tempBestScore = PlayerPrefs.GetInt("Best Score");
        if(bestScore > tempBestScore)
        {
            PlayerPrefs.SetInt("Best Score", bestScore);
        }

        bestScoreText.text = bestScore.ToString();
    }
}
