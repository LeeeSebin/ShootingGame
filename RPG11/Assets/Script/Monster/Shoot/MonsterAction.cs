using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAction : MonoBehaviour
{
    public GameObject Mbullet;
    public GameObject spawnPoint;
    bool cool;
    float time;
    public float cooltime;
    private AudioSource audio;
    public AudioClip firesound;
    public char m;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        cool = false;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(cool == true)
        {
            time += Time.deltaTime;
            if(time>=cooltime)
            {
                cool = false;
                time = 0;
            }
        }
    }

    public void Fire()
    {
        if (cool == false)
        {
            //audio.clip = firesound;
            //audio.Play();
            Instantiate(Mbullet, spawnPoint.transform.position, Quaternion.identity);
            cool = true;
        }
    }
}
