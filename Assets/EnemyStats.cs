using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health;
    public int attackPower;
    public float attackRate;
    public string ability;

    private string[] abilities = { "Ninguna", "Aturdir", "Regenerar Vida", "Envenenar" };

    void Start()
    {
        GenerateStats();
        SendStatsToHUD();
    }

    public void GenerateStats()
    {
        health = Random.Range(50, 200); 
        attackPower = Random.Range(5, 30);
        attackRate = Random.Range(0.5f, 3.0f);

        int abilityChance = Random.Range(0, 100);
        ability = (abilityChance < 50) ? "Ninguna" : abilities[Random.Range(1, abilities.Length)];
    }

    private void SendStatsToHUD()
    {
        EnemyDifficultyManager hudManager = Object.FindFirstObjectByType<EnemyDifficultyManager>();

        if (hudManager == null)
        {
            Debug.LogError("No se encontró EnemyDifficultyManager en la escena. Asegúrate de que está en un GameObject activo.");
            return;
        }

        if (hudManager.difficultyText == null || hudManager.hpText == null)
        {
            Debug.LogError("Los TextMeshProUGUI no están asignados en EnemyDifficultyManager.");
            return;
        }

        hudManager.CalculateAndDisplayDifficulty(this);
    }
}
