using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace elikrisel
{
    public class Bomb : MonoBehaviour, ISpawnable
    {
        /// <summary>
        /// Speedboost script for summarization
        /// </summary>
        [Header("Bomb Prefab")]
        [SerializeField] private GameObject bombPf;

        [Header("Walls")]
        [SerializeField] BoxCollider2D spawnArea;

        [Header("Variables")]
        private int initialSpawnTime = 50;
        private int spawnDelay = 20;


        void Start()
        {

            InvokeRepeating("Spawn", initialSpawnTime, spawnDelay);

        }

        public void Spawn()
        {

            Bounds bounds = this.spawnArea.bounds;

            float xPos = Random.Range(bounds.min.x, bounds.max.x);
            float yPos = Random.Range(bounds.min.y, bounds.max.y);


            GameObject bomb = Instantiate(bombPf, new Vector2(xPos, yPos), Quaternion.identity);
            bomb.transform.parent = GameObject.Find("Collectibleholder").transform;
            


        }





    }

}
