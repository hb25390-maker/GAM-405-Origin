using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(KillBullet());
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Bullet collider with " + collision.gameObject);

        if(collision.gameObject.tag == "Zombie")
        {
            Destroy(collision.gameObject);
            //collision.gameObject.GetComponent<Zombie>().DoDeathSequence();
        }

        Destroy(this.gameObject);
    }

    private IEnumerator KillBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
