using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipDaBoi : MonoBehaviour
{
    public Transform playerCharacter;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        playerCharacter = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    public void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        this.spriteRenderer.flipX = playerCharacter.transform.position.x < this.transform.position.x;
    }
}
