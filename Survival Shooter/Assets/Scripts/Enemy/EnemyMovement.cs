using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth darahpemain;
    EnemyHealth darahmusuh;
    public NavMeshAgent nav;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        darahpemain = player.GetComponent<PlayerHealth>();
        darahmusuh = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (darahmusuh.currentHealth > 0 && darahpemain.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        else 
        {
            nav.enabled = false;
        }
    }
}
