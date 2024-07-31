using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipTrigger : MonoBehaviour
{
    // Змінна для зберігання звуку
    public AudioClip soundClip;

    // Компонент для відтворення звуку
    public AudioSource audioSource;

    // Метод, який викликається при запуску
    void Start()
    {
       

       

        // Опціонально: можна відключити автоматичне відтворення звуку
        audioSource.playOnAwake = false;
    }

    // Метод, який викликається при вході в тригер
    void OnTriggerEnter(Collider other)
    {
        // Перевірка, чи об'єкт, що зіштовхнувся, має ім'я "Player"
        if (other.gameObject.name == "Player")
        {
            // Перевірка наявності звукового кліпу
            if (audioSource != null && soundClip != null)
            {
                Debug.Log(7);

                // Призначаємо звуковий кліп для відтворення
                audioSource.clip = soundClip;

                // Відтворення звуку
                audioSource.Play();

                gameObject.SetActive(false);
            }
        }
    }
}
