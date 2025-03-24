using UnityEngine;
using TMPro;

public class EnemyDifficultyManager : MonoBehaviour
{
    public TextMeshProUGUI difficultyText;
    public TextMeshProUGUI hpText;

    public void CalculateAndDisplayDifficulty(EnemyStats enemy)
    {
        if (difficultyText == null || hpText == null)
        {
            Debug.LogError("No se han asignado los TextMeshPro en el HUD.");
            return;
        }

        // Ajustamos la fórmula para que los valores sean más balanceados
        float rawDifficulty = (enemy.health * 0.5f) + (enemy.attackPower * 2f) - (enemy.attackRate * 5f);

        // Si el enemigo tiene una habilidad especial, agregamos un pequeño bono
        if (enemy.ability != "Ninguna")
        {
            rawDifficulty += Random.Range(5, 10);
        }

        // Normalizamos la dificultad para que caiga entre 1 y 5
        int difficultyLevel = GetDifficultyLevel(rawDifficulty);

        // Mostrar valores en el HUD
        difficultyText.text = $"Dificultad: {difficultyLevel}/5\nHabilidad: {enemy.ability}";
        hpText.text = $"HP: {enemy.health}";

        // Debug para ver los valores generados
        Debug.Log($"Enemigo generado - HP: {enemy.health}, Ataque: {enemy.attackPower}, Vel. Ataque: {enemy.attackRate}, Habilidad: {enemy.ability}, Dificultad Calculada: {rawDifficulty}, Nivel: {difficultyLevel}/5");
    }

    private int GetDifficultyLevel(float rawDifficulty)
    {
        if (rawDifficulty < 50) return 1;
        if (rawDifficulty < 90) return 2;
        if (rawDifficulty < 130) return 3;
        if (rawDifficulty < 170) return 4;
        return 5;
    }
}
