using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent; // Посилання на NavMeshAgent
    public Animator animator;
    private int Coins = 4;
    public GameObject coinPrefab; // Публічна змінна для префабу монетки

    void Update()
    {
        // Перевірка на натискання лівої кнопки миші
        if (Input.GetMouseButtonDown(0))
        {
            // Створення променя від камери через позицію миші
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Якщо промінь влучив у якийсь об'єкт, встановити цільове місце агента
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        // Перевірка на натискання правої кнопки миші
        if (Input.GetMouseButtonDown(1))
        {
            // Викликаємо метод для створення монетки
            SpawnCoin();

            // Відтворення анімації персонажа
            PlayCharacterAnimation();
        }

        // Перевірка чи агент рухається
        if (agent.velocity.magnitude > 0.1f)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    void SpawnCoin()
    {




        if (Coins == 0)
            return;

        Coins--;

        // Створення променя від камери через позицію миші
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Якщо промінь влучив у якийсь об'єкт, створити монетку в цій точці
        if (Physics.Raycast(ray, out hit))
        {
            // Створення монетки
            GameObject coin = Instantiate(coinPrefab, hit.point, Quaternion.identity);

            // Додавання компонента Coin
            coin.AddComponent<Coin>();

            // Відтворення звуку монетки
            AudioSource coinAudioSource = coin.GetComponent<AudioSource>();
            if (coinAudioSource != null)
            {
                coinAudioSource.Play();
            }
        }
    }

    void PlayCharacterAnimation()
    {
        animator.SetTrigger("IsThrow");
    }
}