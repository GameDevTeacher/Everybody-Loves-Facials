using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
   public class EnemyController : MonoBehaviour
   {
      public enum Preferred_Cream
      {
         Natural,
         LabMade,
         AloeVera,
         HimalayanPinkSalt
      }

      public Preferred_Cream preferredCream;

      public enum Preferred_Fruitable
      {
         Cucumber,
         Eggplant,
         Orange,
         Apple,
         Potato,
         Broccoli,
         Lemon
      }
      
      public Preferred_Fruitable preferredFruitable;

      public enum CreamLevel
      {
         NoCream,
         Creamed,
         ThickCream
      }
      
      public CreamLevel creamLevel;

      public bool Roaming;
      public bool IsBeingCreamed;
      public bool LoosingCream;
      public bool IsFullyCreamed;
      public float CreamCounter = 2f;
      public float Creamometer;
      public int Score;
      

      private void Start()
      {
         Array fruitableValues = Enum.GetValues(typeof(Preferred_Fruitable));
         Array creamValues = Enum.GetValues(typeof(Preferred_Cream));
         
         preferredFruitable = (Preferred_Fruitable)fruitableValues.GetValue(Random.Range(0, fruitableValues.Length));
         preferredCream = (Preferred_Cream)creamValues.GetValue(Random.Range(0, creamValues.Length));
      }

      private void Update()
      {
         
      }
   
      private void OnTriggerEnter(Collider other)
      {
         if (other.CompareTag("Cream"))
         {
            other.TryGetComponent(out Cream projectileCream);
            Cream += 0.2f;
         }

         if (other.CompareTag("Fruitable"))
         {
            other.TryGetComponent(out Fruitable projectileFruitable);
            Fruitable += 0.2f;
         }
         Destroy(other.gameObject);
      }
      
      
   }
}