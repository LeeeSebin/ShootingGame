using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar : MonoBehaviour
{
    public int damage = 3;
    public float UpPower;
    public float Power1;
    public float Power2;
    public float Power3;
    GameObject player;
    GameObject postion;
    int random;
    int dir;
    char m;
    private float power;
    private float time=0;
    public float overtime=5;
    void Start()
    {
        damage = 3;
        player = GameObject.Find("PlayerHp");
        postion = GameObject.Find("CharPosition");
        random = Random.Range(1, 4);
        if (this.gameObject.transform.position.x > postion.transform.position.x)
            dir = -1;
        else
            dir = 1;
        if (random == 1)
            power = Power1;
        else if (random == 2)
            power = Power2;
        else
            power = Power3;

        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * power*dir, ForceMode.Impulse);
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * UpPower, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}