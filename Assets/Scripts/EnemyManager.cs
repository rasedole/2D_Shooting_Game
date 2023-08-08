using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 적을 생성한다.

public class EnemyManager : MonoBehaviour
{
    // 필요 속성: 특정 시간, 현재 시간, 적 GameObject 
    private float createTime = 1.0f;
    private float currentTime = 0;
    public float minTime = 0.5f;
    public float maxTime = 5.5f;
    public GameObject enemy;

    void Start()
    {
        float randomCreateTime = Random.Range(minTime, maxTime);
        createTime = randomCreateTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= createTime) 
        {
            GameObject enemyGO = Instantiate(enemy);
            enemyGO.transform.position = transform.position;

            currentTime = 0;
        }
    }
}
