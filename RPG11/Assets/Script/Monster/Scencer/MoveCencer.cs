using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCencer : MonoBehaviour
{
    public float speed;
    public GameObject monster;
    public bool moveon;
    void Start()
    {
        moveon = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if (moveon == true)
        {
            if (other.gameObject.tag == "Player")
            {
                if (other.transform.position.x > monster.transform.position.x)
                    monster.transform.Translate(new Vector3(speed * Time.smoothDeltaTime, 0, 0));
                else
                    monster.transform.Translate(new Vector3(-speed * Time.smoothDeltaTime, 0, 0));
            }
        }
    }
}
