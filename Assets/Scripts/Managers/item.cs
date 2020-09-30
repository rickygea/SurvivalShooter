using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public PlayerMovement movesc;
    public PlayerHealth hpsc;
    public int jenis;

    private void Start()
    {
        hpsc = PlayerHealth.sgtplayerhealth;
        movesc = PlayerMovement.sgtplayermovement;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !other.isTrigger)
        {

            switch (jenis)
            {
                case 1:
                    
                    hpsc.ubahdarah(10);
                    break;
                case 2:
                    movesc.aktifkanbuff(10f,5f);
                    break;
                default:
                    
                    break;
            }

            Destroy(this.gameObject);
        }
    }

}
