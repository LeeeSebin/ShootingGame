using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLazerAction : MonoBehaviour
{
    public GameObject Mbullet;
    public GameObject spawnPoint;
    GameObject player;
    bool cool;
    float time;
    public float cooltime;

    public char m;


    // Start is called before the first frame update
    void Start()
    {
        cool = false;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cool == true)
        {
            time += Time.deltaTime;
            if (time >= cooltime)
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
            player = GameObject.Find("Player");
            if (this.transform.position.x > player.transform.position.x)
                Instantiate(Mbullet, new Vector3(spawnPoint.transform.position.x-Mbullet.transform.localScale.x/2, spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity);
            else
               Instantiate(Mbullet, new Vector3(spawnPoint.transform.position.x + Mbullet.transform.localScale.x / 2 , spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity);
            cool = true;
        }
    }
}
