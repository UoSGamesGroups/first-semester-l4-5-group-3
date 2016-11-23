//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class ObjectPooling : MonoBehaviour
//{
//    public GameObject objectPool;

//    public int poolAmount;

//    List<GameObject> pooledObjects;

//	void Start ()
//    {
//        pooledObjects = new List<GameObject>();

//        for (int i = 0; i < poolAmount; i++)
//        {
//            GameObject obj = (GameObject)Instantiate(objectPool);
//            obj.SetActive(false);
//            pooledObjects.Add(obj);
//        }
//	}

//    public GameObject GetObjectPool()
//    {
//        for (int i = 0; i < pooledObjects.Count; i++)
//        {
//            if (pooledObjects[i].activeInHierarchy)
//            {
//                return pooledObjects[i];
//            }
//        }

//        GameObject obj = (GameObject)Instantiate(objectPool);
//        obj.SetActive(false);
//        pooledObjects.Add(obj);
//        return obj;

//    }
	
//}
