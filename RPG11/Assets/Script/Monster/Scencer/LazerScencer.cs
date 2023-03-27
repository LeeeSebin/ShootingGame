using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScencer : MonoBehaviour
{
    public GameObject Monster;
    public GameObject MoveScencer;

    private float time=0;
    public float lazerchargetime;
    private bool lazeron = false;

    private float cooltime = 0;
    public float lazercooltime;
    private bool lazerchargeon = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(lazeron==true)
        {
            time += Time.deltaTime;
            if(time>= lazerchargetime)
            {
                GameObject.Find(Monster.name).GetComponent<MonsterLazerAction>().Fire();
                time = 0;
                lazerchargeon = true;
                lazeron = false;
            }
        }

        if(lazerchargeon==true)
        {
            cooltime += Time.deltaTime;
            if(cooltime>=lazercooltime)
            {
                cooltime = 0;
                lazerchargeon = false;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (lazeron == false)
            {
                lazeron = true;

            }
            MoveScencer.GetComponent<MoveCencer>().moveon = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MoveScencer.GetComponent<MoveCencer>().moveon = true;
        }
    }
}
