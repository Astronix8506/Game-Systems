using System;
using System.Collections.Generic;
using UnityEngine;

public class DestrucibleResourceHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField]private List<ResourceStage> _resourceStages = new();
    
    private int currentStage = 0;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        PercentCheck();
        currentHealth = maxHealth;
        spriteRenderer.sprite = _resourceStages[currentStage].Stageicon;
    }

    public void TakeDamagePercent(int percentDamage)
    {
        float percent = percentDamage / 100f;
        float damage = maxHealth * percent;
        currentHealth -= damage;
        Debug.Log(gameObject.name+ " Took damage: " + damage);
        StageCheck();
    }

    //Debug purposes
    public void PercentCheck()
    {
        int listCount = _resourceStages.Count;
        if (listCount == 0) return;
        
        if (_resourceStages[0].requiredPercent != 100) 
            Debug.LogWarning(gameObject.name + " Element ["+ (listCount - 1) +"] Incorrect percent - MUST BE 100");
        
        if (_resourceStages[listCount - 1].requiredPercent != 0) 
            Debug.LogWarning(gameObject.name + " Element [0] Incorrect Percent - MUST BE 0");
        
        for (int i = 0; i < listCount - 2; i++)
        {
            if (_resourceStages[i].requiredPercent < _resourceStages[i + 1].requiredPercent)
                Debug.LogWarning(gameObject.name + " Element ["+ (i+1) +"] not in correct descending order");
        }
    }
    
    public void StageCheck()
    {
        float healthPercent = (currentHealth / maxHealth) * 100;
        int nextStagePercent;
        ;
        nextStagePercent = _resourceStages[currentStage + 1].requiredPercent;
        
        Debug.Log("Amount of Stages: "+_resourceStages.Count+"  On Stage: "+currentStage+"  Next Stage : "+nextStagePercent +
                  "  Current Percent: " +healthPercent + "Current health: " + currentHealth + "  Maxhealth: " + maxHealth);
        
        if (healthPercent <= nextStagePercent)
            currentStage++;
        
        if (_resourceStages[currentStage].Stageicon)
            spriteRenderer.sprite = _resourceStages[currentStage].Stageicon;

        if (currentStage == _resourceStages.Count - 1)
        {
            //temporary destroy
            Destroy(this.gameObject);
        }
    }
}
