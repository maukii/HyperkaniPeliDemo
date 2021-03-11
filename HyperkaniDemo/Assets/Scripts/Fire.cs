using UnityEngine;

public class Fire : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer rend;


    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.flipX = Random.value >= 0.5f;

        anim = GetComponent<Animator>();
        anim.speed = Random.Range(0.5f, 1.5f);
    }
}
