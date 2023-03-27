using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    bool player;

    public GameObject P;
    private float z=-30;
    char m='r';
    int x;
    bool alive;
    Vector3 tragetPos;
    void Start()
    {
        x = 4;
        player = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        P = GameObject.Find("Player");
        if (Input.GetKeyDown(KeyCode.RightArrow))
            x = +4;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            x = -4;
        if (player)
        {
            tragetPos = new Vector3(P.transform.position.x + x, P.transform.position.y + 2, z);
            transform.position = Vector3.Lerp(transform.position, tragetPos, Time.deltaTime * 2f);
        }
    }

    public void PlayerDie()
    {
        player = false;
    }
    
    public void newTraget(string name)
    {
    }
}
