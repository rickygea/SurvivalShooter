using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public int maxspawn;
    [SerializeField]
    MonoBehaviour a;
    IFactory Factory { get { return a as IFactory; } }

    void Start ()
    {

        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int spawnEnemy = Random.Range(0, maxspawn);
        Vector3 titikspawn = spawnPoints[spawnPointIndex].transform.position;
        Factory.FactoryMethod(spawnEnemy, titikspawn);
    }
}
