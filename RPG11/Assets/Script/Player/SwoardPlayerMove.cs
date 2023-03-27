using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwoardPlayerMove : MonoBehaviour
{
    bool moveon = true;
    float movetimer = 0;
    public float speed;
    Vector3 spawnPoint;
    public GameObject bullet;
    public char M = 'r';
    bool right = true;
    bool up, left, down, Jumping = false;
    private float Btime;
    public float Bcooltime;
    private bool Bon;
    public float JumpPower;
    public float FilePos;

    void Start()
    {
        Btime = 0;
        Bon = false;
        this.gameObject.name = "Player";
        spawnPoint = this.gameObject.transform.position;
        JumpPower = 8;
    }

    // Update is called once per frame
    void Update()
    {
        moveObject();
        if (Input.GetKeyDown(KeyCode.X) && Jumping == false)
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            Jumping = true;
        }

        if (moveon == false)
        {
            movetimer += Time.deltaTime;
            if (movetimer >= 0.1)
                moveon = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
            down = true;
        if (Input.GetKeyUp(KeyCode.DownArrow))
            down = false;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            up = true;
        if (Input.GetKeyUp(KeyCode.UpArrow))
            up = false;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            right = true;
            left = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            right = false;
            left = true;
        }

        //발사키
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Bon == false)
            {
                if (up == true)
                    M = 'u';
                else if (down == true)
                    M = 'd';
                else if (right == true)
                    M = 'r';
                else if (left == true)
                    M = 'l';
                Fire();
                Bon = true;
            }
        }

        //발사쿨타임
        if (Bon == true)
        {
            Btime += Time.deltaTime;
            if (Btime >= Bcooltime)
            {
                Bon = false;
                Btime = 0;
            }
        }
    }


    //이동
    void moveObject()
    {
        if (moveon == true)
        {
            float keyHorizontal = Input.GetAxis("Horizontal");
            float keyVertical = Input.GetAxis("Vertical");

            transform.Translate(Vector3.right * speed * Time.smoothDeltaTime * keyHorizontal, Space.World);
        }
    }

    //발사
    void Fire()
    {
        moveon = false;
        movetimer = 0;
        if (M == 'r')
            spawnPoint = new Vector3(this.gameObject.transform.position.x + FilePos, this.gameObject.transform.position.y, 0);
        else if (M == 'l')
            spawnPoint = new Vector3(this.gameObject.transform.position.x - FilePos, this.gameObject.transform.position.y, 0);
        else if (M == 'u')
            spawnPoint = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + FilePos, 0);
        else if (M == 'd')
            spawnPoint = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - FilePos, 0);
        Instantiate(bullet, spawnPoint, Quaternion.identity);
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
            Jumping = false;
    }
}