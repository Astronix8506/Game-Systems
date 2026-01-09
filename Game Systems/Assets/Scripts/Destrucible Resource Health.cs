using System;
using UnityEngine;

public class DestrucibleResourceHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamagePercent(int percentDamage)
    {
        float percent = percentDamage / 100f;
        int damage = Mathf.RoundToInt(maxHealth * percent);
        currentHealth -= damage;
        CheckHealth();
    }
    private void CheckHealth()
    {
        if (currentHealth <= 0)
            Destroy(this.gameObject);
    }
}
