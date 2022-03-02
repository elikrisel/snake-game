using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace elikrisel
{

    public class Food : MonoBehaviour, ISpawnable
    {

        [SerializeField] private BoxCollider2D spawnArea;


        void Start()
        {
            Spawn();
          

        }




        private void OnTriggerEnter2D(Collider2D other)
        {

            Spawn();
            ScoreHandler.instance.AddScore();


        }

        public void Spawn()
        {
            Bounds bounds = this.spawnArea.bounds;

            float xPos = Random.Range(bounds.min.x, bounds.max.x);
            float yPos = Random.Range(bounds.min.y, bounds.max.y);

            this.transform.position = new Vector3(xPos, yPos, 0.0f);
        }
    }


}




  




