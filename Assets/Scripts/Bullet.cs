using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //Sprite do sujeito atirador, para pegar a direçao
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private float lifetime = 1;
  


    // Start is called before the first frame update
    void Start()
    {

        Invoke("DestroyBullet", lifetime);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //transform.Translate(transform.right * bulletSpeed * Time.deltaTime);
        transform.Translate(new Vector3(bulletSpeed * Time.deltaTime, 0, 0));
    }

    public void DestroyBullet()
    {

        Destroy(gameObject);

    }


}
