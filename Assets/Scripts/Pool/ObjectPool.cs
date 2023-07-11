using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public abstract class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private int _capacity;
        private List<GameObject> _pool = new List<GameObject>();

        protected void Initialized(GameObject[] prefabs)
        {
            for (int i = 0; i < _capacity; i++)
            {
                int randomIndex = Random.Range(0, prefabs.Length);
                GameObject spawned = Instantiate(prefabs[randomIndex], _container.transform);

                spawned.SetActive(false);

                _pool.Add(spawned);
            }
        }

        protected bool TryGetObject(out GameObject result)
        {
            int verifiedObjects = 0;
            while (true)
            {
                result = _pool[Random.Range(0, _pool.Count)];
                if (result.activeSelf == false) return result;
                
                verifiedObjects++;
                if (verifiedObjects >= _pool.Count) return result == null;
            }
        }
    }
}