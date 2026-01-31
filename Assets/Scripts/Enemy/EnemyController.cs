using System.Collections;
using UnityEngine;

namespace Enemy
{
   public class EnemyController : MonoBehaviour
   {
      public Cream preferredCream;
      public Fruitable preferredFruitable;

      public enum CreamLevel
      {
         NoCream,
         Creamed,
         ThickCream
      }
      
      public CreamLevel creamLevel;
      
      public bool isBeingCreamed;
      public bool loosingCream;
      public bool isFullyCreamed;
      public float creamCounter = 2f;
      public float creamometer;
      public int score;

      private void Start()
      {
         preferredCream = GetComponent<Cream>();
         preferredFruitable = GetComponent<Fruitable>();
         /*Array fruitableValues = Enum.GetValues(typeof(Preferred_Fruitable));
         Array creamValues = Enum.GetValues(typeof(Preferred_Cream));
         
         preferredFruitable = (Preferred_Fruitable)fruitableValues.GetValue(Random.Range(0, fruitableValues.Length));
         preferredCream = (Preferred_Cream)creamValues.GetValue(Random.Range(0, creamValues.Length));
         
         */
      }
      
      private void OnTriggerEnter(Collider other)
      {
         if (other.CompareTag("Cream"))
         {
            creamCounter += 0.5f;
            print("Thanks for the cream Paddy: " + other.name);
            StartCoroutine(OnIsBeingCreamed());
         }

         if (other.CompareTag("Fruitable"))
         {
            
         }
         Destroy(other.gameObject);
      }

      IEnumerator OnIsBeingCreamed()
      {
         isBeingCreamed = true;
         if (Mathf.Approximately(creamCounter, 50f))
         {
            isFullyCreamed = true;
         }
         yield return new WaitForSeconds(10f);
         isFullyCreamed  = false;
         

         if (isFullyCreamed == false)
         {
            creamCounter -= 0.5f;
         }
      }
      
   }
}