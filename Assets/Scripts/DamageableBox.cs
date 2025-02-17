using UnityEngine;

public class DamageableBox : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    private Renderer boxRenderer;
    public Color damageColor = Color.red;
    private Color originalColor;
    public float damageAmount = 25f;
    public float damageDuration = 0.2f;
    private bool isTakingDamage = false;

    void Start()
    {
        currentHealth = maxHealth;
        boxRenderer = GetComponent<Renderer>();
        if (boxRenderer != null)
        {
            originalColor = boxRenderer.sharedMaterial.color; // Usar sharedMaterial para evitar errores con prefabs
        }
    }

    public void TakeDamage()
    {
        if (boxRenderer == null) return;

        if (!isTakingDamage)
            StartCoroutine(FlashDamage());

        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private System.Collections.IEnumerator FlashDamage()
    {
        isTakingDamage = true;
        boxRenderer.material.color = damageColor;
        yield return new WaitForSeconds(damageDuration);
        boxRenderer.material.color = originalColor;
        isTakingDamage = false;
    }
}
