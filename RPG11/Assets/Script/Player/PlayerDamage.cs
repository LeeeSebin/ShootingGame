using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    GameObject PlayerHp;

    void Start()
    {
        PlayerHp = GameObject.Find("PlayerHp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    void Damage(int DMG)
    {
        PlayerHp.GetComponent<PlayerHP>().Damage(DMG);
    }
}
