using UnityEngine;
using System.Collections;
public class Asteroid : MonoBehaviour
{
    public GameObject explosion;
    public GameObject asteroid;
    public float explosionTime; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "asteroid")
        {
            explosion.SetActive(true);
            StartCoroutine(Fade(0.3f));
            Rigidbody rb = asteroid.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, 0);
         
        }
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth == null) { return; }

        playerHealth.Crash();
    }

    IEnumerator Fade(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        asteroid.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
