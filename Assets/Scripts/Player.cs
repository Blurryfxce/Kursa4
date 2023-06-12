using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    private int spriteIndex;


    private Vector3 direction;

    public float gravity = -25f;

    public float strength = 8f;


    private float rotationSpeed = 3.5f;

    private Quaternion targetRotation;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.04f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
            targetRotation = Quaternion.Euler(0, 0, 70);

            StartCoroutine(StartFalling());
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private IEnumerator StartFalling()
    {
        yield return new WaitForSeconds(0.1f);
        targetRotation = Quaternion.Euler(0, 0, -30);
    }



    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (collision.gameObject.CompareTag("Score"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
    
}
