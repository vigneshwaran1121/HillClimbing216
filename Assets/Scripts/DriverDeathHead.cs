using UnityEngine;

public class DriverDeathHead : MonoBehaviour

{
    private bool isDead = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Ground"))
        {
            isDead = true;
            GameManager.instance.GameOver();
        }
    }
}
