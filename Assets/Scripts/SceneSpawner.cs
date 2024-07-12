using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSpawner : MonoBehaviour
{
    [SerializeField] GameObject sceneSpawner;
    [SerializeField] GameObject lossCollider;

    void OnTriggerEnter(Collider other)
    {
        InstantiateObjects();
    }

    public void InstantiateObjects()
    {
        Instantiate(sceneSpawner, lossCollider.transform.position + new Vector3(0, -0.5f, 2.5f), Quaternion.identity);
    }
}
