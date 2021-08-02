using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Queue<GameObject> queue;

    [SerializeField]
    GameObject spawnObject;
    [SerializeField]
    int objectCount;

    void Awake()
    {
        queue = new Queue<GameObject>();
    }
    void Start()
    {
        CreateBullet(objectCount);
    }
    void CreateBullet(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            GameObject spawnableObject = Instantiate(spawnObject, transform.position, transform.rotation, transform);
            spawnableObject.SetActive(false);
            queue.Enqueue(spawnableObject);
        }
    }
    public GameObject GetBullet(Transform newTransform)
    {
        GameObject newObject = queue.Dequeue();
        newObject.transform.position = newTransform.position;
        newObject.SetActive(true);
        return newObject;
    }
}
