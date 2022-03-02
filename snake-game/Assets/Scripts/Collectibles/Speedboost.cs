using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace elikrisel
{
    public class Speedboost : MonoBehaviour, ISpawnable
    {

        [Header("SpeedBoost Prefab")]
        [SerializeField] private GameObject speedBoostpf;

        //Spawn grid
        [Header("Walls")]
        [SerializeField] BoxCollider2D spawnArea;

        //Spawn time and time after spawn
        [Header("Variables")]
        private int initialSpawnTime = 25;
        private int spawnDelay = 15;


        void Start()
        {

            InvokeRepeating("Spawn", initialSpawnTime, spawnDelay);

        }


        public void Spawn()
        {
            //Spawning all collectibles in position within the gridArea
            Bounds bounds = this.spawnArea.bounds;

            float xPos = Random.Range(bounds.min.x, bounds.max.x);
            float yPos = Random.Range(bounds.min.y, bounds.max.y);
           
            GameObject speedboost = Instantiate(speedBoostpf, new Vector2(xPos, yPos), Quaternion.identity);
            //Adding prefabs in bodyholder gameobject in scene
            speedboost.transform.parent = GameObject.Find("Collectibleholder").transform;


        }
    }

}


