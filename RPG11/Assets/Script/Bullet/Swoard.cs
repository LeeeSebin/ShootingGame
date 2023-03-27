using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swoard : MonoBehaviour
{
    public int damage = 1;
    char m;
    private float time = 0;
    public float overtime = 1;
    // Start is called before the first frame update
    void Start()
    {
        SwoardPlayerMove pm = GameObject.Find("Player").GetComponent<SwoardPlayerMove>();
        m = pm.M;
        if (m == 'l')
            this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (m == 'u')
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        else if (m == 'd')
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
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
        if (other.gameObject.tag == "Monster")
        {
            //몬스터와 충돌시 어떻게 될지
            MonsterHP monster = GameObject.Find(other.gameObject.name).GetComponent<MonsterHP>();
            monster.Damage(damage);
            Destroy(this.gameObject);
        }
    }
}