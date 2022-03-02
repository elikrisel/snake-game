using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace elikrisel
{

    public class Snake : MonoBehaviour
    {
        
        

        [Header("Components")]
        private Vector2 direction;

        //List of tail prefabs
        [SerializeField]private List<Transform> bodyPosition;
        //Tail prefab
        [SerializeField] private GameObject tail;
        //UI Screen
        [SerializeField] private GameObject gameOverScreen;

        [Header("Variables")]
        private bool portalConnected;
        private bool haveSpeedBoost;

        //snake speed
        private float speed = 1f;
        //Speed boost duration
        private float boostDuration = 5;
        private float boostTimer;
        //moving in how many frames/second
        private float speedRate = 0.3f;


        #region Main Methods


        private void Start()
        {
            gameOverScreen.SetActive(false);
            //boost timer set default in 0    
            boostTimer = 0;
            //move grid
            direction = new Vector2(0, 1);
            

            //Moving to the right direction
            direction = Vector2.right;
                
            //Move with a slight delay
            InvokeRepeating("Move",speedRate,speedRate);
            
            
        }

        private void Update()
        {
            
            HandleMovement();
          if(portalConnected)
            {
                Portal();

            }
            if(haveSpeedBoost)
            {   
                boostTimer += Time.deltaTime;
                //When the timer reaches the duration it returns to default value
                if(boostTimer >= boostDuration)
                {
                    speed = 1f;
                    boostTimer = 0f;
                    haveSpeedBoost = false;
                    Debug.Log(speed);
                }


            }
            

        }
        #endregion

        #region Custom Methods
        void Move()
        {   
            //last position of the snake
            Vector3 lastPosition = transform.position;
            
            transform.Translate(direction * speed);
            
            //Body grow
            if(bodyPosition.Count >= 1)
            {   

                bodyPosition.Last().position = lastPosition;
                bodyPosition.Insert(0, bodyPosition.Last());
                bodyPosition.RemoveAt(bodyPosition.Count - 1);
            }

        }
      
        
        void HandleMovement()
        {
            //Can't move in opposite when pressing the input

            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {   
                if (direction.y != -1)
                {
                    direction.x = 0;
                    direction.y = 1;

                }




            }
            else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
              
                if (direction.y != 1)
                {
                    direction.x = 0;
                    direction.y = -1;

                }


            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
               
                if(direction.x != -1)
                {
                    direction.x = 1;
                    direction.y = 0;
                }
        

            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                
                if(direction.x != 1)
                {
                    direction.x = -1;
                    direction.y = 0;
                }
                
            }

        
        }
        
        void Portal()
        {
            //Teleporting 
            transform.position = new Vector3(Random.Range(-20, 20), Random.Range(-10, 10), transform.position.z);
            portalConnected = false;
        }
        void Grow()
        {   
            Vector2 spawnPosition = new Vector2(0,18);
            //Prefab spawn
            GameObject tailBody = Instantiate(tail, spawnPosition, Quaternion.identity);
            //Adding prefabs in bodyholder gameobject in scene
            tailBody.transform.parent = GameObject.Find("Bodyholder").transform;
            //Adding prefab to list
            bodyPosition.Add(tailBody.transform);

        }
 
        #endregion

        #region OnTrigger

        private void OnTriggerEnter2D(Collider2D other)
        {
            
            if(other.gameObject.CompareTag("Portal"))
            {
                if(!portalConnected)
                {
                                    
                    Destroy(other.gameObject);
                    portalConnected = true;

                }

            }
            if(other.gameObject.CompareTag("Collectible"))
            {
                if(!haveSpeedBoost)
                {
                    haveSpeedBoost = true;
                    //Changing speedvalue
                    speed = 1.7f;
                    Destroy(other.gameObject);
                    

                }

            }
            if(other.gameObject.CompareTag("Food"))
            {

                //Adding tail to player
                Grow();

            }

            if(other.gameObject.CompareTag("Obstacle"))
            {

                //Game Over
                Time.timeScale = 0;
                gameOverScreen.SetActive(true);
                
            }


        }

        #endregion
        



    }
}


