    using UnityEngine;

    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 30f;
        Rigidbody rb;
        ScoreManager scoreManager;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            scoreManager = FindObjectOfType<ScoreManager>();
    }

        private void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * moveSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Pickup"))
            {
                Destroy(other.gameObject);
                scoreManager.CollectPickup();
            }
        }
    }
