using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{

    protected Vector3 direction;
    public float destroyAfterSeconds;

    //static PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
    //public static Vector3 shootingLine = new(playerMovement.moveDir.x - playerMovement.prevDir.x, playerMovement.moveDir.y - playerMovement.prevDir.y);
    //public Quaternion rotation = Quaternion.LookRotation(shootingLine, new Vector3(1, 0));    //Нахождение угла полёта снаряда

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    //private void Update()
    //{
    //    GetComponent<Collider2D>().GetComponent<CollisionHandler>().OnCollisionEnter2D.AddListener(HandleCollision);
    //}
    public void DirectionSetter(Vector3 dir)
    {
        direction = dir;

        float dirX = direction.x;
        float dirY = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (dirX < 0 && dirY == 0)//налево
        {
            scale.x *= -1;
            scale.y *= -1;
        }

        else if (dirX == 0 && dirY < 0)//вниз
        {
            rotation.z -= 90f;
        }

        else if (dirX == 0 && dirY > 0)//вверх
        {
            rotation.z = 20f;
        }

        else if (dir.x > 0 && dirY > 0)//вправо вверх
        {
            rotation.z = 0f;
        }
        else if (dir.x > 0 && dir.y < 0)//вправо вниз
        {
            rotation.z = -90f;
        }

        else if (dir.x > 0 && dir.y < 0)//вправо вниз
        {
            rotation.z = -90f;
        }

        else if (dir.x < 0 && dir.y > 0)//влево вниз
        {
            scale.x *= -1;
            scale.y *= -1;
            rotation.z = -100f;
        }
        else if (dir.x < 0 && dir.y < 0)//влево нвверух
        {
            scale.x *= -1;
            rotation.z = 100f;
        }

        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);

    }

    void OnCollisionEnter(Collision collision)//Проверка столкновения с объектом
    {
        if (collision.gameObject.name == "Box" || collision.gameObject.name == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        Debug.Log("Object has been destroyed!");
    }
}



