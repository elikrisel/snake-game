using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace elikrisel
{

    public class Food : MonoBehaviour, ISpawnable
    {

        

        void Start()
        {
            Spawn();

        }

        public void Spawn()
        {
            int xPos = Random.Range(-25, 25);
            int yPos = Random.Range(-15, 15);
            transform.position = new Vector2(xPos, yPos);


                    

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {

                Spawn();
            }
        }


    }


}




  




