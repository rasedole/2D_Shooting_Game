using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 적을 생성한다.

// 목표 : 에네미 오브젝트 풀을 만들어서 관리하고 싶다.
// 속성 : 에네미 오브젝트의 개수, 오브젝트 풀 배열
// 순서1. 에네미 오브젝트의 개수만큼의 배열을 생성한다.
// 순서2. 에네미 게임 오브젝트를 생성한다.
// 순서3. 생성한 게임 오브젝트를 풀에 넣는다.
// 순서4. 게임오브젝트를 비활성화 해준다.

// 목표 : 에네미 오브젝트 풀에서 에네미가 비활성화 되어있다면 활성화 시킨다.

public class EnemyManager : MonoBehaviour
{
    // 필요 속성: 특정 시간, 현재 시간, 적 GameObject 
    private float createTime = 1.0f;
    private float currentTime = 0;
    public float minTime = 0.5f;
    public float maxTime = 5.5f;
    public GameObject enemy;

    public int poolSize = 10;
    public List<GameObject> enemyObjectPool;

    void Start()
    {
        float randomCreateTime = Random.Range(minTime, maxTime);
        createTime = randomCreateTime;

        // 순서1. 에네미 오브젝트의 개수만큼의 배열을 생성한다.
        enemyObjectPool = new List<GameObject>();

        // 순서2. 에네미 게임 오브젝트를 생성한다.
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemyGO = Instantiate(enemy);
            // 순서3. 생성한 게임 오브젝트를 풀에 넣는다.
            enemyObjectPool.Add(enemyGO);

            // 순서4. 게임오브젝트를 비활성화 해준다.
            enemyGO.SetActive(false);

            enemyGO.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= createTime)
        {
            if(enemyObjectPool.Count > 0)
            {
                GameObject enemyGO = enemyObjectPool[0];

                enemyGO.SetActive(true);
                enemyGO.transform.position = transform.position;

                enemyObjectPool.Remove(enemyGO);
            }

            currentTime = 0;
        }
    }
}
