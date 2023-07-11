using UnityEngine;

namespace Pool
{
    public class Spawner : ObjectPool
    {
        [SerializeField] private GameObject[] _prefabObjects;
        [SerializeField] private Transform[] _spawners;
        [SerializeField] private float _minSecondForSpawn, _maxSecondForSpawn;
        
        private float _secondForSpawn;
        private float _time;

        private void Start()
        {
            Initialized(_prefabObjects);
            _secondForSpawn = Random.Range(_minSecondForSpawn, _maxSecondForSpawn);
        }

        private void FixedUpdate()
        {
            _time += Time.fixedDeltaTime;
            
            if (_time >= _secondForSpawn && TryGetObject(out GameObject spawnedObject))
            {
                int spawnPointNumber = Random.Range(0, _spawners.Length);
                
                spawnedObject.SetActive(true);
                spawnedObject.transform.position = _spawners[spawnPointNumber].position;
                
                _secondForSpawn = Random.Range(_minSecondForSpawn, _maxSecondForSpawn);
                _time = 0;
            }
        }
    }
}