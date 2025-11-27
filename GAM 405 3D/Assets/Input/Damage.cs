using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class Damage : MonoBehaviour
{
    private bool canDoDamage = true;
    private bool inAttackRange = false;
    [SerializeField] float distanceToAttack = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(this.transform.position, Playermovement.i.transform.position);

        if(distanceToPlayer < distanceToAttack && canDoDamage)
        {
            Debug.Log("Is this running");
            DoDamage();
        }
    }

    private void DoDamage()
    {
        Playermovement.i.GetComponent<Health>().TakeDamage(1);
        StartCoroutine(WaitBetweenAttacks());
    }

    private IEnumerator WaitBetweenAttacks()
    {
        canDoDamage = false;
        yield return new WaitForSeconds(1f);
        canDoDamage = true;
    }
}
