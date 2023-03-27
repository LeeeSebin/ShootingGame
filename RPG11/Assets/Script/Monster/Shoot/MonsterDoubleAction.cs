using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDoubleAction : MonoBehaviour
{
    public GameObject Mbullet;
    public GameObject Sbullet;
    public GameObject spawnPoint;
    public bool cool;
    float time;
    float secondtime;
    public float secondcooltime;
    bool secondon = false;
    public float cooltime;
    private AudioSource audio;
    public AudioClip firesound;
    public char m;
    // Start is called before the first frame update
    void Start()
    {
        cool = false;
        time = 0;
        secondtime = 0;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(secondon==true)
        {
            secondtime += Time.deltaTime;
            if(secondtime>=secondcooltime)
            {
                SecondFire();
            }
        }

        if (cool == true)
        {
            time += Time.deltaTime;
            if (time >= cooltime+secondcooltime)
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
            audio.clip = firesound;
            audio.Play();
            cool = true;
            Instantiate(Mbullet, spawnPoint.transform.position, Quaternion.identity);
            secondon = true;
        }
    }

    public void SecondFire()
    {
        if (cool == true&&secondon==true)
        {
            audio.clip = firesound;
            audio.Play();
            Instantiate(Sbullet, spawnPoint.transform.position, Quaternion.identity);
            secondtime = 0;
            secondon = false;
        }
    }
}
