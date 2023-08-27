using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class coinscollect : MonoBehaviour
{
    public int totalCoinsRequired = 5;
    public float breakDuration = 4f;
    private int collectedCoins = 0;
    private bool isLevelComplete = false;
    //[SerializeField] private AudioSource coinsSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coins"))
        {
            //coinsSound.Play();
            Destroy(other.gameObject);
            collectedCoins = collectedCoins + 1;
            if (collectedCoins >= totalCoinsRequired && !isLevelComplete)
            {
                isLevelComplete = true;
                StartCoroutine(MoveToNextLevelWithBreak());
                Debug.Log("Level Cleared");
            }
        }
    }

    IEnumerator MoveToNextLevelWithBreak()
    {
        yield return new WaitForSeconds(breakDuration);
        SceneManager.LoadScene(2);
    }
}

