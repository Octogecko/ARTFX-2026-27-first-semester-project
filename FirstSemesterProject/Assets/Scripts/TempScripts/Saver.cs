using UnityEngine;

public class Saver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("C'est bon wlh");
            SaveController.Instance.SaveGame();
        }
    }
}
