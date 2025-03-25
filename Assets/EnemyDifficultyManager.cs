using UnityEngine;
using TMPro;

public class EnemyDifficultyManager : MonoBehaviour
{
    public TextMeshProUGUI difficultyText;
    public TextMeshProUGUI hpText;

    public enum DifficultyMethod
    {
        Metodo1, // El método original
        Metodo2, // Segunda opción
        Metodo3, // Tercera opción
        Metodo4, // Cuarta opción
        MetodoPersonalizado // El que creamos nosotros
    }

    public DifficultyMethod selectedMethod = DifficultyMethod.Metodo1; // Método por defecto

    private const float MIN_HEALTH = 50;
    private const float MAX_HEALTH = 200;
    private const float MIN_ATTACK = 2;
    private const float MAX_ATTACK = 30;
    private const float MIN_ATTACK_RATE = 0.5f;
    private const float MAX_ATTACK_RATE = 3.0f;

    public void CalculateAndDisplayDifficulty(EnemyStats enemy)
    {
        if (difficultyText == null || hpText == null)
        {
            Debug.LogError("No se han asignado los TextMeshPro en el HUD.");
            return;
        }

        float rawDifficulty = 0f;

        switch (selectedMethod)
        {
            case DifficultyMethod.Metodo1:
                rawDifficulty = (enemy.health * 0.5f) + (enemy.attackPower * 2f) - (enemy.attackRate * 5f);
                break;

            case DifficultyMethod.Metodo2:
                rawDifficulty = (enemy.health * 0.3f) + (enemy.attackPower * 2.5f) - (enemy.attackRate * 4f);
                break;

            case DifficultyMethod.Metodo3:
                rawDifficulty = (enemy.health * 0.4f) + (enemy.attackPower * 3f) - (enemy.attackRate * 3.5f);
                break;

            case DifficultyMethod.Metodo4:
                rawDifficulty = (enemy.health * 0.6f) + (enemy.attackPower * 1.8f) - (enemy.attackRate * 6f);
                break;

            case DifficultyMethod.MetodoPersonalizado:
                rawDifficulty = (enemy.health * 0.55f) + (enemy.attackPower * 2.2f) - (enemy.attackRate * 4.5f) + (enemy.ability != "Ninguna" ? 8f : 0f);
                break;
        }

        if (enemy.ability != "Ninguna")
        {
            rawDifficulty += Random.Range(5, 10);
        }

        float minDifficulty = (MIN_HEALTH * 0.5f) + (MIN_ATTACK * 2f) - (MAX_ATTACK_RATE * 5f);
        float maxDifficulty = (MAX_HEALTH * 0.5f) + (MAX_ATTACK * 2f) - (MIN_ATTACK_RATE * 5f) + 10;

        float normalizedDifficulty = Mathf.Clamp01((rawDifficulty - minDifficulty) / (maxDifficulty - minDifficulty));

        int difficultyLevel = Mathf.CeilToInt(normalizedDifficulty * 4) + 1;

        difficultyText.text = $"Dificultad: {difficultyLevel}/5\nHabilidad: {enemy.ability}";
        hpText.text = $"HP: {enemy.health}";

        Debug.Log($"Enemigo generado - HP: {enemy.health}, Ataque: {enemy.attackPower}, Vel. Ataque: {enemy.attackRate}, Habilidad: {enemy.ability}, Dificultad Calculada: {rawDifficulty}, Normalizada: {normalizedDifficulty}, Nivel: {difficultyLevel}/5");
    }
}
