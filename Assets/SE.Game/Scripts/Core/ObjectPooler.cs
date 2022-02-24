using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE.Game.Core
{

    [System.Serializable]
    public class ObjectPoolItem
    {
        public GameObject objectToPool;
        public string poolName; 
        public int amountToPool;
        public bool shouldExpand = true;

    }

    public class ObjectPooler : MonoBehaviour
    {
        public const string DefaultRootObjectPoolName = "Pooled Objects";

        public static ObjectPooler Instance;
        public string rootPoolName = DefaultRootObjectPoolName;
        public Dictionary<string, List<GameObject>> pooledObjects = new Dictionary<string, List<GameObject>>();
        public List<ObjectPoolItem> itemsToPool;

        void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            if (string.IsNullOrEmpty(rootPoolName))
                rootPoolName = DefaultRootObjectPoolName;

            GetParentPoolObject(rootPoolName);

            foreach (var item in itemsToPool)
            {
                for (int i = 0; i < item.amountToPool; i++)
                {
                    CreatePooledObject(item);
                }
            }
        }

        private GameObject GetParentPoolObject(string objectPoolName)
        {
            // Use the root object pool name if no name was specified
            if (string.IsNullOrEmpty(objectPoolName))
                objectPoolName = rootPoolName;

            GameObject parentObject = GameObject.Find(objectPoolName);

            // Create the parent object if necessary
            if (parentObject == null)
            {
                parentObject = new GameObject();
                parentObject.name = objectPoolName;

                // Add sub pools to the root object pool if necessary
                if (objectPoolName != rootPoolName)
                    parentObject.transform.parent = GameObject.Find(rootPoolName).transform;
            }

            return parentObject;
        }

        public GameObject GetPooledObject(string tag)
        {
            pooledObjects.TryGetValue(tag, out var pools);
            for (int i = 0; i < pools.Count; i++)
            {
                if(!pools[i].activeInHierarchy)
                {
                    pools[i].gameObject.SetActive(true);
                    return pools[i];
                }
            }
            for (int i = 0; i < itemsToPool.Count; i++)
            {
                if(itemsToPool[i].shouldExpand)
                {
                    return CreatePooledObject(itemsToPool[i]);
                }
            }

            return null;
        }

        private GameObject CreatePooledObject(ObjectPoolItem item)
        {
            GameObject obj = Instantiate<GameObject>(item.objectToPool);

            // Get the parent for this pooled object and assign the new object to it
            var parentPoolObject = GetParentPoolObject(item.poolName);
            obj.transform.parent = parentPoolObject.transform;

            obj.SetActive(false);
            if(pooledObjects.ContainsKey(item.poolName))
            {
                pooledObjects.TryGetValue(item.poolName, out var pool);
                pool.Add(obj);
            }
            else
            {
                pooledObjects.Add(item.poolName, new List<GameObject>());
                pooledObjects[item.poolName].Add(obj);
            }
            return obj;
        }
    }
}

