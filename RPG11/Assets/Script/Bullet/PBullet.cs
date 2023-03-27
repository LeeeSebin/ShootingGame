using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    GameObject player;
    public float speed;
    public int damage = 1;
    Vector3 vec;
    private float time = 0;
    public float overtime = 5;
    GameObject postion;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerHp");
        postion = GameObject.Find("CharPosition");
        vec = postion.transform.position-this.gameObject.transform.position;
        speed = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vec * speed * Time.deltaTime);
        time += Time.deltaTime;
        if (time >= overtime)
            Destroy(this.gameObject);
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
