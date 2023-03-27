using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLazer : MonoBehaviour
{
    
    public int damage = 4;
    char m;
    private float time = 0;
    public float overtime = 0.5f;
    bool life = true;
    GameObject player;
    GameObject postion;
    void Start()
    {
        damage = 4;
        player = GameObject.Find("PlayerHp");
        postion = GameObject.Find("CharPosition");
    }

    // Update is called once per frame
    void Update()
    {
        //타이머와 총알삭제
        time += Time.deltaTime;
        if (time > overtime)
            Destroy(this.gameObject);

    }

    void OnTriggerEnter(Collider other)//총알이 다른 오브젝트와  충돌시
    {
        if (other.gameObject.tag == "Player")
        {
            if (life == true)
            {
                player.GetComponent<PlayerHP>().Damage(damage);
                life = false;
            }
        }
    }
}
