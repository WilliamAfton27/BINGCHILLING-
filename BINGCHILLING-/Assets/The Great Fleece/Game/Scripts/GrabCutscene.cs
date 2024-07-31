using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GrabCutscene : MonoBehaviour
{
    // Поле для посилання на об'єкт катсцени
    public GameObject cutSceneObject;

    // Start is called before the first frame update
    void Start()
    {
        // Переконайтесь, що Collider цього об'єкта встановлений як тригер
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }

        // Вимикаємо об'єкт катсцени, щоб він не був активний на початку
        if (cutSceneObject != null)
        {
            cutSceneObject.SetActive(false);
        }
    }

    // Метод, який спрацьовує при зіткненні з іншим Collider
    private void OnTriggerEnter(Collider other)
    {
        // Перевірка, чи зіткнення відбулося з гравцем
        if (other.CompareTag("Player"))
        {
            // Активуємо HasCard у GameManager
            GameManager.Instance.HasCard = true;
            Debug.Log("Гравець отримав картку!");

            // Активуємо катсцену
            ActivateCutScene();
        }
    }

    // Метод для активації катсцени
    private void ActivateCutScene()
    {
        Debug.Log("Катсцена активована!");
        gameObject.SetActive(false);

        if (cutSceneObject != null)
        {
            // Активуємо об'єкт катсцени
            cutSceneObject.SetActive(true);

            // Запускаємо катсцену, якщо використовується PlayableDirector
            PlayableDirector director = cutSceneObject.GetComponent<PlayableDirector>();
            if (director != null)
            {
                director.Play();
            }
        }
    }
}
