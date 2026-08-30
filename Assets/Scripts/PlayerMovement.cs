using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Vector3 inputVector;
    Vector3 spawn = new Vector3(-.6f, -.8f, 0f);
    float timer = 3f;
    public GameObject OutOfBoundsText;
    public GameObject StartText;
    public GameObject DeathText;
    public GameObject EatenText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        OutOfBoundsText.SetActive(false);
        DeathText.SetActive(false);
        EatenText.SetActive(false);
        StartText.SetActive(true);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position.y > -10f && transform.position.y < 10f && transform.position.x > -20f && transform.position.x < 20f)
        {
        transform.position += inputVector * Time.deltaTime * 5f; 
        }else
        {
        transform.position = spawn;
        OutOfBoundsText.SetActive(true);
        }
    }
    void Update()
    {
        if (StartText.activeSelf == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
        {
            StartText.SetActive(false);
            timer = 3f;
        }
        }
        if (OutOfBoundsText.activeSelf == true)
        {
        timer -= Time.deltaTime;
            if (timer <= 0f)
        {
            OutOfBoundsText.SetActive(false);
            timer = 3f;
        }
        }

    }
    public void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }
private void OnCollisionEnter2D(Collision2D collision)
    {

 if (collision.gameObject.CompareTag("Death"))
        {
            DeathText.SetActive(true);
        }
if(collision.gameObject.CompareTag("Eaten"))
        {
            EatenText.SetActive(true);
        }
    }
}
