using UnityEngine;

namespace Pool
{
    public class Spawner : ObjectPool
    {
        [SerializeField] private GameObject[] _prefabObjects;
        [SerializeField] private Transform[] _spawners;
        [SerializeField] private float _secondForSpawn;
        private float _time = 0;

        private void Start() => Initialized(_prefabObjects);

        private void FixedUpdate()
        {
            _time += Time.fixedDeltaTime;
            
            if (_time >= _secondForSpawn && TryGetObject(out GameObject spawnedObject))
            {
                int spawnPointNumber = Random.Range(0, _spawners.Length);
                
                spawnedObject.SetActive(true);
                spawnedObject.transform.position = _spawners[spawnPointNumber].position;
                
                _time = 0;
            }
        }
    }
}