using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    public int HP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP<=0)
        {
            Destroy(this.gameObject);
        }
    }
    public void Damage(int DMG)
    {
        HP -= DMG;
    }
}
