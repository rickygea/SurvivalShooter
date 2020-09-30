using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemspawn : MonoBehaviour
{
    public Renderer r;
    public GameObject healprefab, speedprefab;
    public Vector3 poskrg;
    public GameObject healskrg, speedskrg;
    private float offset;
    int jenis;
    private void Start()
    {
        offset = 0.5f;
    }
    void spawnitem()
    {
        poskrg = new Vector3(Random.Range(r.bounds.min.x + offset, r.bounds.max.x - offset), 1f, Random.Range(r.bounds.min.z + offset, r.bounds.max.z - offset));
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(poskrg.x, 105f, poskrg.z), -Vector3.up, out hit))
        {
            if (hit.collider.tag == "Floor")
            {
                switch (jenis) {
                    case 1:
                        healskrg = GameObject.Instantiate(healprefab, poskrg, Quaternion.identity) as GameObject;
                        break;
                    case 2:
                        speedskrg = GameObject.Instantiate(speedprefab, poskrg, Quaternion.identity) as GameObject;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                spawnitem();
            }
        }
    }

    void Update()
    {
       
        if (!healskrg)
        {
            jenis = 1;
            spawnitem();
        }
       
        if (!speedskrg)
        {
            jenis = 2;
            spawnitem();
        }
      
    }

}
