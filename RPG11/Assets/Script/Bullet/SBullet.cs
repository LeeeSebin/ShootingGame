using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBullet : MonoBehaviour
{

    public float speed;
    public int damage = 1;
    char m;
    private float time = 0;
    private float overtime = 5;
    GameObject player;
    GameObject postion;
    public float upspeed;
    void Start()
    {
        player = GameObject.Find("PlayerHp");
        postion = GameObject.Find("CharPosition");
        if (this.gameObject.transform.position.x > postion.transform.position.x)
            m = 'l';
        else
            m = 'r';
    }

    // Update is called once per frame
    void Update()
    {
        //타이머와 총알삭제
        time += Time.deltaTime;
        if (time > overtime)
            Destroy(this.gameObject);

        //총알 이동
        if (m == 'r')
            transform.Translate(new Vector3(speed * Time.smoothDeltaTime, upspeed * Time.smoothDeltaTime, 0));
        else if (m == 'l')
            transform.Translate(new Vector3(-speed * Time.smoothDeltaTime, upspeed * Time.smoothDeltaTime, 0));

    }

    void OnTriggerEnter(Collider other)//총알이 다른 오브젝트와  충돌시
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerHP>().Damage(damage);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "wall")
            Destroy(this.gameObject);
    }
}
