using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace elikrisel
{

    public class Snake : MonoBehaviour
    {

        [Header("Components")]
        private Vector2 direction = Vector2.right;

        
        #region Main Methods

    
        private void Start()
        {   //Move to the right
            InvokeRepeating("Move", 0.2f, 0.2f);
        }

        private void Update()
        {
            HandleMovement();
        }
        #endregion

        #region Custom Methods
        void Move()
        {
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
        #endregion

    }
}


