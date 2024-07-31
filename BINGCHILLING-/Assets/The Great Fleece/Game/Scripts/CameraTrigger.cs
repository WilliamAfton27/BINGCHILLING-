using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{


    // Йде перевірка трігера чи торкається ігрока
    // Змінювати кут бачення камери

    public Camera MainCamera;

    public Transform newCameraPosition; // Нова позиція та ротація камери

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("123");
        if (other.gameObject.tag == "Player")
        {

            // Телепортуємо камеру до нової позиції та ротації
            Camera.main.transform.position = newCameraPosition.position;
            Camera.main.transform.rotation = newCameraPosition.rotation;
        }
    }
}
