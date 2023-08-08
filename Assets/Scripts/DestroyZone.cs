using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표 : 적 또는 총알이 감지되었을 경우, 그 물체를 파괴한다.
public class DestroyZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if((other.gameObject.tag == "Player"))
        {
            return;
        }
        Destroy(other.gameObject);
    }
}
