using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;


    public float speed;
    public TextMeshProUGUI countText;
    public GameObject wintextObject;

    // Start is called before the first frame update
    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.count = 0;
        this.SetCountText();

        this.wintextObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(this.movementX, 0.0f, this.movementY);

        this.rb.AddForce(movement * this.speed);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        this.movementX = movementVector.x;
        this.movementY = movementVector.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            var randomX = Random.Range(-9, 9);
            var randomY = Random.Range(-9, 9);

            other.gameObject.transform.position = new Vector3(randomX, 0.5f, randomY);
            this.count++;
            this.SetCountText();
        }
    }

    private void SetCountText()
    {
        this.countText.text = $"Count: {this.count}";

        if (this.count >= 3)
        {
            this.wintextObject.SetActive(true);
        }
    }
}
