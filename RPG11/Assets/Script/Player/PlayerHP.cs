using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int HP;
    public int Type = 1;
    public GameObject Camera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int DMG)
    {
        HP -= DMG;
        if (HP <= 0)
            die();
    }

    void die()
    {
        Camera.GetComponent<CameraMove>().PlayerDie();
        Destroy(GameObject.Find("Player"));
    }
}
