using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice_Bullet : MonoBehaviour
{
    public float speed = 1f;
    protected Vector3 direction = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
