using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItem : MonoBehaviour
{
    public float speed = 1f;
    protected Vector3 dir = Vector3.down;
    public GameObject effect;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnDisable()
    {
        GameObject effectGO = Instantiate(effect);
        effectGO.transform.position = transform.position;

        AudioSource audioSource = SoundManager.instance.GetComponent<SoundManager>().effAS;
        audioSource.clip = SoundManager.instance.GetComponent<SoundManager>().itemAC[0];
        audioSource.Play();
    }
}
