using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSit : MonoBehaviour
{
    BoxCollider b;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<BoxCollider>().center = new Vector3(0, -0.25f, 0);
            GetComponent<BoxCollider>().size = new Vector3(1, -0.5f, 1);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
            GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
        }
    }
}
