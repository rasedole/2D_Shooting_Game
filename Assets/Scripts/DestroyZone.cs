using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표 : 적 또는 총알이 감지되었을 경우, 그 물체를 비활성화한다.
public class DestroyZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            return;
        }

        if(other.gameObject.layer == 6)
        {
            PlayerFire playerFire = GameObject.Find("Player").GetComponent<PlayerFire>();
            other.gameObject.SetActive(false);
            other.transform.parent = GameManager.instance.player.transform;

            playerFire.bulletObjectPool.Add(other.gameObject);
        }

        if(other.gameObject.layer == 9)
        {
            EnemyBullet bullet = other.GetComponent<EnemyBullet>();
            
            other.gameObject.SetActive(false);
            other.transform.parent = GameManager.instance.player.transform;
        }
        if(other.gameObject.tag == "Item")
        {
            other.gameObject.SetActive(false);
            other.transform.parent = SkillManager.instance.transform;

            SkillManager.instance.itemObjectPool.Add(other.gameObject);
        }

    }
}
