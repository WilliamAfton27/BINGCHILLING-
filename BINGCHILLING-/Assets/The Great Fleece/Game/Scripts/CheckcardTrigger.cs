using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCardTrigger : MonoBehaviour
{
    // Поле для дій, які потрібно виконати, якщо HasCard встановлено в true
    public GameObject actionObject;

    void Start()
    {
        // Переконайтесь, що Collider цього об'єкта встановлений як тригер
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }

        // Переконайтесь, що actionObject спочатку вимкнений
        if (actionObject != null)
        {
            actionObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Перевірка, чи зіткнення відбулося з гравцем
        if (other.CompareTag("Player"))
        {
            // Перевіряємо, чи встановлено HasCard в true
            if (GameManager.Instance.HasCard)
            {
                Debug.Log("Гравець має картку!");

                // Виконуємо дії, якщо гравець має картку
                PerformAction();
            }
            else
            {
                Debug.Log("Гравець не має картки!");
            }
        }
    }

    private void PerformAction()
    {
        // Активуємо actionObject або виконуємо інші дії
        if (actionObject != null)
        {
            actionObject.SetActive(true);
        }

        // Тут можна додати інші дії, які повинні виконуватися
        // Наприклад, перехід на іншу сцену, активація анімації, показ повідомлення тощо
    }
}
