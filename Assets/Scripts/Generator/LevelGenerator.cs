using UnityEngine;

namespace Generator
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _saveZone;
        [SerializeField] private GameObject _dangerZone;
        [SerializeField, Min(0)] private int _countGeneratedZones;
        [SerializeField] private Transform _spawnPoint;
        private int _currentCountGeneratedZones;
        
        private void Start()
        {
            while (_currentCountGeneratedZones != _countGeneratedZones)
                GenerateZones(Random.Range(0, 2) == 0 ? _saveZone : _dangerZone);
        }

        private void GenerateZones(GameObject zone)
        {
            int countGeneratedZones = Random.Range(1, 3);
            if (_currentCountGeneratedZones + countGeneratedZones > _countGeneratedZones)
                countGeneratedZones = _countGeneratedZones - _currentCountGeneratedZones;
            
            for (int i = 0; i < countGeneratedZones; i++)
            {
                Instantiate(zone, new Vector3(0, zone.transform.position.y, _spawnPoint.position.z), zone.transform.rotation, transform);
                _spawnPoint.position += Vector3.forward * 2;
            }

            _currentCountGeneratedZones += countGeneratedZones;
        }
    }
}