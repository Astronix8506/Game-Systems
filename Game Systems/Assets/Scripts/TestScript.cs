using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject targetObject;
    private DestrucibleResourceHealth destructableHealth;
    [SerializeField] private int percentDamage;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseScreenPos = Input.mousePosition;
            Vector3  mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            Vector2 rayOrgin = new Vector2(mouseWorldPos.x, mouseWorldPos.y);
            
            Collider2D hit = Physics2D.OverlapPoint(rayOrgin);
            if (hit.CompareTag(targetObject.tag))
            {
                destructableHealth = hit.GetComponent<DestrucibleResourceHealth>();
                destructableHealth.TakeDamagePercent(percentDamage);
            }
        }
        
    }
    
    
}
