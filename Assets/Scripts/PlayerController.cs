using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject winText;
    [SerializeField]
    private float _speed;

    private Rigidbody _rb;
    private float _movX, _movY;
    private int _score;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _score = 0;

        SetScoreText();
        winText.gameObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        _movX = movementVector.x;
        _movY = movementVector.y;
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + _score.ToString();
        if (_score >= 15)
            winText.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_movX, 0.0f, _movY);
        _rb.AddForce(movement*_speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
            other.gameObject.SetActive(false);
        _score++;
        SetScoreText();
    }
}
