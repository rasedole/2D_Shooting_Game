using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//목표: 사용자 입력(Space)를 입력받아 총알을 생성한다

public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunPos;
    public int skillLevel = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExcuteSkill(skillLevel);
        }
    }

    private void ExcuteSkill(int _skillLevel)
    {
        switch (_skillLevel)
        {
            case 0:
                ExcuteSkill1();
                break;
            case 1:
                ExcuteSkill2();
                break;
            case 2:
                ExcuteSkill3();
                break;
            case 3:
                ExcuteSkill4(); 
                break;

        }
    }

    void ExcuteSkill1()
    {
        GameObject bulletGO = Instantiate(bullet);
        bulletGO.transform.position = gunPos.transform.position;
    }

    void ExcuteSkill2()
    {
        GameObject bulletGO = Instantiate(bullet);
        bulletGO.transform.position = gunPos.transform.position + new Vector3(-0.3f,0,0);

        GameObject bulletGO2 = Instantiate(bullet);
        bulletGO2.transform.position = gunPos.transform.position + new Vector3(0.3f,0,0);
    }

    void ExcuteSkill3()
    {
        GameObject bulletGO = Instantiate(bullet);
        bulletGO.transform.position = gunPos.transform.position + new Vector3(-0.3f, 0, 0);
        bulletGO.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 30));
        //bulletGO.GetComponent<Bullet>().dir += new Vector3(-0.3f, 0, 0);
        bulletGO.GetComponent<Bullet>().dir = bulletGO.transform.up;

        GameObject bulletGO2 = Instantiate(bullet);
        bulletGO2.transform.position = gunPos.transform.position + new Vector3(0.3f, 0, 0);
        bulletGO2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -30));
        //bulletGO2.GetComponent<Bullet>().dir += new Vector3(0.3f, 0, 0);
        bulletGO2.GetComponent<Bullet>().dir = bulletGO2.transform.up;

        GameObject bulletGO3 = Instantiate(bullet);
        bulletGO3.transform.position = gunPos.transform.position;
    }

    public static int degree = 15;
    private int bulletNum = 360 / degree;

    void ExcuteSkill4()
    {
        for(int i = 0; i < bulletNum; i++)
        {
            GameObject bulletGO = Instantiate(bullet);
            bulletGO.transform.position = gunPos.transform.position;
            bulletGO.transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree * i));
            bulletGO.GetComponent<Bullet>().dir = bulletGO.transform.up;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            skillLevel++;
            Destroy(other.gameObject);
        }
    }
}
