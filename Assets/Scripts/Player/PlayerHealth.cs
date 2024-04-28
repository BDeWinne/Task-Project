using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth; 
    [SerializeField] private int currentHealth; 
    PlayerMovement playerMovement;
    Animator animator;

    void Start()
    {
        GetReferences();
        currentHealth = maxHealth; 
        UI_Controller.Instance.deathEvt.AddListener(Die);
    }

    void GetReferences(){
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Damage taken"+ damage);
        currentHealth -= damage; 
        if (currentHealth <= 0)
        {
            Die(); 
        }
    }

    private void Die()
    {
        animator.Play("Death");
        playerMovement.enabled = false;
        this.enabled = false;
    }
}

