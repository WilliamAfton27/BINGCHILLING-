using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    // Змінна для об'єкту кат-сцени, який буде включатися
    public GameObject cutsceneObject;

    // Start is called before the first frame update
    void Start()
    {
        // Переконаємося, що об'єкт кат-сцени спочатку вимкнений
        if (cutsceneObject != null)
        {
            cutsceneObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Cutscene object is not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Можливо, тут потрібно буде додати додаткову логіку
    }

    // Цей метод викликається, коли об'єкт входить в тригерну зону
    void OnTriggerEnter(Collider other)
    {
        // Перевіряємо, чи гравець торкнувся очей
        if (other.CompareTag("Player"))
        {
            if (cutsceneObject != null)
            {
                // Вмикаємо об'єкт кат-сцени
                cutsceneObject.SetActive(true);
                Debug.Log("Player touched the eyes. Cutscene started.");
            }
        }
    }
}