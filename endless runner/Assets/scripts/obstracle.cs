using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstracle : MonoBehaviour
{
    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioSource source;
    [SerializeField] private GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
        source = FindObjectOfType<AudioSource>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.decreaseHealth();
            source.PlayOneShot(hit);
            Destroy(this.gameObject);
        }
    }
}
