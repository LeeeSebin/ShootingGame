using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMachine : MonoBehaviour
{
    public GameObject Machine;
    public GameObject Sniper;
    public GameObject Pistol;
    public GameObject Sword1;
    public GameObject Sword2;
    GameObject PlayerType;
    int choice;
    bool on = true;
    // Start is called before the first frame update
    void Start()
    {
        PlayerType = GameObject.Find("PlayerHp");
        int P = 1;
        int M = 2;
        int S = 3;
        int B1 = 4;
        int B2 = 5;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (on == true)
        {
            if (other.gameObject.tag == "Player")
            {
                on = false;
                choice = Random.Range(1, 6);

                while (choice == PlayerType.GetComponent<PlayerHP>().Type)
                    choice = Random.Range(1, 6);
                PlayerType.GetComponent<PlayerHP>().Type = choice;

                if (choice == 1)
                {
                    Destroy(other.gameObject);
                    Instantiate(Pistol, other.transform.position, Quaternion.identity);
                }
                else if (choice == 2)
                {
                    Destroy(other.gameObject);
                    Instantiate(Machine, other.transform.position, Quaternion.identity);
                }
                else if (choice == 3)
                {
                    Destroy(other.gameObject);
                    Instantiate(Sniper, other.transform.position, Quaternion.identity);
                }
                else if (choice == 4)
                {
                    Destroy(other.gameObject);
                    Instantiate(Sword1, other.transform.position, Quaternion.identity);
                }
                else if (choice == 5)
                {
                    Destroy(other.gameObject);
                    Instantiate(Sword2, other.transform.position, Quaternion.identity);
                }
            }
        }
    }
}
