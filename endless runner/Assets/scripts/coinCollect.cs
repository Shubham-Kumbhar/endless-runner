using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollect : MonoBehaviour
{
    [SerializeField] private AudioClip collect;
    [SerializeField] private AudioSource source;
    [SerializeField]private GameManager manager;
    [SerializeField] private float rotateSpeed = 1.0f;


    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
        source = FindObjectOfType<AudioSource>();
    }
    private void Update()
    {
        transform.Rotate(transform.up, 360 * rotateSpeed * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            manager.coinIncrease();
            source.PlayOneShot(collect);
            Destroy(this.gameObject);
        }
    }
}
