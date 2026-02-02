using UnityEngine;

public class TestScript : MonoBehaviour
{
    private string targetObject = "Resource";
    private DestrucibleResourceHealth destructableHealth;
    [SerializeField] private int percentDamage;
    

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3  mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector2 rayOrgin = new Vector2(mouseWorldPos.x, mouseWorldPos.y);
            
        Collider2D hit = Physics2D.OverlapPoint(rayOrgin);
        
        if (!hit || !hit.CompareTag(targetObject)) return;
        destructableHealth = hit.GetComponent<DestrucibleResourceHealth>();
        destructableHealth.TakeDamagePercent(percentDamage);

    }
    
    
}
