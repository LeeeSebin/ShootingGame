using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    char m;
    private float time = 0;
    public float overtime=1;
    public float speed;
    void Start()
    {
        //플레이어가 쏘려는 방향에 대한 정보
       PlayerMove pm = GameObject.Find("Player").GetComponent<PlayerMove>();
       m = pm.M;
    }

    // Update is called once per frame
    void Update()
    {
        //타이머와 총알삭제
        time += Time.deltaTime;
        if(time> overtime)
            Destroy(this.gameObject);

        //총알 이동
        if (m=='r')
            transform.Translate(new Vector3(speed * Time.smoothDeltaTime, 0, 0));
       else if(m=='l')
            transform.Translate(new Vector3(-speed * Time.smoothDeltaTime, 0, 0));
       else if (m == 'u')
            transform.Translate(new Vector3(0, speed * Time.smoothDeltaTime, 0));
        else if (m == 'd')
            transform.Translate(new Vector3(0, -speed * Time.smoothDeltaTime, 0));
    }

    void OnTriggerEnter(Collider other)//총알이 다른 오브젝트와  충돌시
    {
        if (other.gameObject.tag == "Monster")
        {
            //몬스터와 충돌시 어떻게 될지
            MonsterHP monster = GameObject.Find(other.gameObject.name).GetComponent<MonsterHP>();
            monster.Damage(damage);
            Destroy(this.gameObject);
        }
    }
}
