using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleScencer : MonoBehaviour
{
    public GameObject Monster;
    public GameObject MoveScencer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find(Monster.name).GetComponent<MonsterDoubleAction>().Fire();
            MoveScencer.GetComponent<MoveCencer>().moveon = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MoveScencer.GetComponent<MoveCencer>().moveon = true;
        }
    }
}
