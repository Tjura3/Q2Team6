using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnviromentScript : MonoBehaviour
{
    [SerializeField] Twening twening;//Script with the can eat bools

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "RockCandy" && twening.consumeRcok)
        {

            StartCoroutine(DestroyEnviroment(collision.gameObject));
        }else if(collision.gameObject.tag == "Tree" && twening.consumeVeggies)
        {
            StartCoroutine(DestroyEnviroment(collision.gameObject));
        }
        else if(collision.gameObject.tag == "Breaker" && twening.consumeRcok)
        {
            StartCoroutine(DestroyEnviroment(collision.gameObject));
        }
    }

    IEnumerator DestroyEnviroment(GameObject gameObject)
    {
        ParticleSystem ps = gameObject.transform.GetComponentInChildren<ParticleSystem>();
        if(ps == null)
        {
            yield return null;
        }

        Collider2D[] colliders = gameObject.GetComponents<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
        }

        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        ps.Play();
        yield return new WaitForSeconds(ps.main.duration);
        Destroy(gameObject);
    }
}
