using System;
using UnityEngine;


public class EnemyFactory : MonoBehaviour, IFactory
{

    [SerializeField]
    public GameObject[] enemyPrefab;
    public GameObject folderenemy;
    public GameObject FactoryMethod(int tag, Vector3 posisi)
    {
        GameObject enemy = Instantiate(enemyPrefab[tag]);
        enemy.transform.position = posisi;
        enemy.transform.parent = folderenemy.transform;
        return enemy;
    }
}
