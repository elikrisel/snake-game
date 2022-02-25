using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace elikrisel
{
    public class Screenwrap : MonoBehaviour
    {   /*
        public enum Walls
        {
            
            Up,
            Down,
            Right,
            Left



        };
        public Walls screenDirection;
        */

      
        //player is coming out the opposite way
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Right"))
            {
                transform.position = new Vector3(-27, transform.position.y, transform.position.z);
                
            }
           
            else if (other.gameObject.CompareTag("Left"))
            {
                transform.position = new Vector3(27, transform.position.y, transform.position.z);
            }
            else if(other.gameObject.CompareTag("Up"))
            {

                transform.position = new Vector3(transform.position.x, -16, transform.position.z);

            }
            else if(other.gameObject.CompareTag("Down"))
            {

                transform.position = new Vector3(transform.position.x, 16, transform.position.z);

            }


        }



    }




}
