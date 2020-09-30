using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    public GameOverManager gameOverManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy" && !other.isTrigger)
        {
            gameOverManager.ShowWarning();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemy" && !other.isTrigger)
        {
            gameOverManager.closewarning();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "enemy" && !other.isTrigger)
        {
            gameOverManager.ShowWarning();
            float enemyDistance = Vector3.Distance(transform.position, other.transform.position);
            gameOverManager.ubahtext(enemyDistance);
        }
    }

}
