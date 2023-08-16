using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    public int poolSize = 10;
    public List<GameObject> itemObjectPool;

    protected float creatTime = 10.0f;
    protected float currentTime = 0;
    public GameObject item;
    public float minTime = 0.5f;
    public float maxTime = 10.0f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        creatTime = Random.Range(minTime, maxTime);
        itemObjectPool = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            GameObject itemGO = Instantiate(item);
            itemObjectPool.Add(itemGO);
            itemGO.SetActive(false);
            itemGO.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > creatTime)
        {
            if(itemObjectPool.Count > 0)
            {
                GameObject itemGO = itemObjectPool[0];
                itemGO.SetActive(true);
                itemGO.transform.position = transform.position;
                itemObjectPool.Remove(itemGO);
            }

            currentTime = 0;
            creatTime = Random.Range(minTime, maxTime);
        }
    }
}
