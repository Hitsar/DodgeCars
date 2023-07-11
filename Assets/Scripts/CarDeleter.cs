using UnityEngine;

public class CarDeleter : MonoBehaviour 
{
    private void OnTriggerEnter(Collider other) => other.gameObject.SetActive(false);
}