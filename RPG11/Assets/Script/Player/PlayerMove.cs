using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    Vector3 spawnPoint;
    public GameObject bullet;
    public char M = 'r';
    bool right = true;
    bool up, left,down,Jumping = false;
    private float Btime;
    public float Bcooltime;
    private bool Bon;
    public float JumpPower=8;
    public float FilePos;
    Rigidbody rigidbody;
    Vector3 move;
    private AudioSource audio;
    public AudioClip firesound;
    public AudioClip Jumpsound;
    void Start()
    {
        Btime = 0;
        Bon = false;
        this.gameObject.name = "Player";
        spawnPoint = this.gameObject.transform.position;
        rigidbody = GetComponent<Rigidbody>();
        JumpPower = 8;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        moveObject();
        if (Input.GetKeyDown(KeyCode.X) && Jumping == false)
        {
            audio.clip = Jumpsound;
            audio.Play();
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            Jumping = true;
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
        float keyHorizontal = Input.GetAxis("Horizontal");
        float keyVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speed * Time.smoothDeltaTime * keyHorizontal, Space.World);
    }

    //발사
    void Fire()
    {
        audio.clip = firesound;
        audio.Play();
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