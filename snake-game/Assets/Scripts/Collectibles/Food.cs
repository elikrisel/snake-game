using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace elikrisel
{

    public class Food : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player"))
            {

                Destroy(gameObject);

            }


        }



    }
    

}




  




