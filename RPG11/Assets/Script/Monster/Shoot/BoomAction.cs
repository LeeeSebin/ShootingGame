using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomAction : MonoBehaviour
{
    public GameObject bomb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Player"||other.gameObject.tag == "Ground")
        {
            Instantiate(bomb, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
