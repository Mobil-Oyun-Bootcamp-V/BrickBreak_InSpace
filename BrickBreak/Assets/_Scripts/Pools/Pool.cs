using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public Queue<GameObject> queue;
    [SerializeField] GameObject spawnObject;
    [SerializeField] int objectCount;
    void Awake()
    {
        queue = new Queue<GameObject>();
    }
    void Start()
    {
        CreateObject(objectCount);
    }
    void CreateObject(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            GameObject spawnableObject = Instantiate(spawnObject, transform.position, transform.rotation, transform);
            spawnableObject.SetActive(false);
            queue.Enqueue(spawnableObject);
        }
    }
    public GameObject GetObject(Transform newTransform)
    {
        GameObject newObject = queue.Dequeue();
        newObject.transform.position = newTransform.position;
        newObject.SetActive(true);
        return newObject;
    }
    public void SetObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
        queue.Enqueue(gameObject);
    }
}
