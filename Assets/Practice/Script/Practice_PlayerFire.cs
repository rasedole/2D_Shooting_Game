using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice_PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletGO = Instantiate(bullet);
            bulletGO.transform.position = transform.position;
        }
    }
}
