using UnityEngine;

public class ActivateEnemyTrigger : MonoBehaviour
{
    public GameObject[] enemyModels; // Tres modelos de enemigo posibles
    public Transform spawnPoint; // Empty Object donde aparecerá el enemigo

    private GameObject activeEnemy; // Referencia al enemigo activado

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && activeEnemy == null)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (enemyModels.Length == 0 || spawnPoint == null) return;

        int randomIndex = Random.Range(0, enemyModels.Length); // Selecciona un modelo aleatorio
        activeEnemy = Instantiate(enemyModels[randomIndex], spawnPoint.position, spawnPoint.rotation);
    }
}
