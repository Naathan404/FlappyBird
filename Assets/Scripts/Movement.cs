using UnityEngine;
using UnityEngine.Audio;

public class Movement : MonoBehaviour
{
    private Rigidbody2D Rb2D;
    public int score = 0;
    public int highScore = 0;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationAngle;
    public AudioSource pointSound;
    public AudioSource dieSound;

    private void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            this.Rb2D.linearVelocity = new Vector2(Rb2D.linearVelocity.x, jumpForce);
        if (this.transform.position.y > 5.4f)
        {
            GameManager.instance.GameOver(score, highScore);
            dieSound.Play();
        }
    }

    private void FixedUpdate()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, this.Rb2D.linearVelocity.y * rotationAngle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver(score, highScore);
        dieSound.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Objective"))
        {
            score++;
            if (score >= highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
                highScore = score;
            }
            if (GameManager.instance != null)
                GameManager.instance.SetScore(score);
            pointSound.Play();
        }
    }

    public void _ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }
}
