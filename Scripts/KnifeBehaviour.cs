using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{
    KnifeController knifeController;

    //static PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
    //public static Vector3 shootingLine = new(playerMovement.moveDir.x - playerMovement.prevDir.x, playerMovement.moveDir.y - playerMovement.prevDir.y);
    //public Quaternion rotation = Quaternion.LookRotation(shootingLine, new Vector3(1, 0));    //Нахождение угла полёта снаряда


    //public static Object FindObjectByName<T>(T inputObj) //Метод поиска объекта, потому что определение базового поиска лежит в С++, а там нельзя вызывать статические функции из конструктора (че за хуйня?!?!)
    //{
    //    GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject obj in allObjects)
    //    {
    //        if (typeof(GameObject).FullName == "KnifeController")
    //        {
    //            return obj;
    //        }
    //    }
    //    return null;
    //}

    protected override void Start()
    {
        base.Start();
        knifeController = FindObjectOfType<KnifeController>();
    }

    
    void Update()
    {
        transform.position += direction * knifeController.speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Prop") || other.CompareTag("Enemy"))
        {
            Debug.Log($"Collusin with{other.name}");
            Destroy(gameObject);
        }
        //else Debug.Log($"Collusin with{other.name}");
    }
}
