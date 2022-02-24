using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace elikrisel
{

    public class Snake : MonoBehaviour
    {

        [Header("Components")]
        private Vector2 direction = Vector2.right;

        
        [Header("Variables")]
        private bool portalConnected;

        #region Main Methods

       
        private void Start()
        {   //Move with a slight delay
            InvokeRepeating("Move",0.2f,0.2f);
            
            
        }

        private void Update()
        {
            
            HandleMovement();
            if(portalConnected)
            {
                Portal();

            }

        }
        #endregion

        #region Custom Methods
        void Move()
        {
           
            //Moving to the right direction
            transform.Translate(direction);

        }
        void HandleMovement()
        {
            

            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = Vector2.up;
        

            }
            else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {

                direction = -Vector2.up;
        

            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {

                direction = Vector2.right;
        

            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {

                direction = -Vector2.right;
                
            }


        }

        void Portal()
        {

            transform.position = new Vector3(Random.Range(-7, 9), Random.Range(-10, 10), transform.position.z);
            portalConnected = false;
        }
        #endregion

        #region OnTrigger

        private void OnTriggerEnter2D(Collider2D other)
        {
                
            if(other.gameObject.CompareTag("Portal"))
            {
                if(!portalConnected)
                {
                    Debug.Log("Collided with portal");
                    Destroy(other.gameObject);
                    portalConnected = true;

                }

            }

        }

        #endregion




    }
}


