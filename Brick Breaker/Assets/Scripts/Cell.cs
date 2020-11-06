using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    private const float TIME_FOR_DESTROY = 2F;
    [SerializeField] private AudioClip[] clips = null;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clips[Random.Range(0, clips.Length)];
        source.Play();
        StartCoroutine(destroyObject());
    }



    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Plank")
        {
            GetComponent<Rigidbody>().AddExplosionForce(3, transform.position, 3);
        }
    }



    private IEnumerator destroyObject()
    {
        yield return new WaitForSeconds(TIME_FOR_DESTROY);
        Destroy(gameObject);
    }


}
