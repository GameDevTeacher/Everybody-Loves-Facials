using System.Collections;
using UnityEngine;

namespace Enemy
{
   public class EnemyController : MonoBehaviour
   {
      [Header("Creaming")]
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

      [Header("Renderers")] 
      public SpriteRenderer leftEyeRenderer;
      public SpriteRenderer rightEyeRenderer;
      public SpriteRenderer faceMaskRenderer;
      
      [Header("Sprites")]
      public Sprite creamed;
      public Sprite thickCream;

      public Sprite[] fruitableSlices;

      [Header("Audio")] 
      public AudioClip success;
      public AudioClip chest;
      public AudioClip bottom;
      public AudioClip nearby;
      

      private void Start()
      {
         preferredCream = GetComponent<Cream>();
         preferredFruitable = GetComponent<Fruitable>();
      }

      private void Update()
      {
         switch (creamLevel)
         {
            case CreamLevel.NoCream:
               faceMaskRenderer.sprite = null;
               break;
            case CreamLevel.Creamed:
               faceMaskRenderer.sprite = creamed;
               break;
            case CreamLevel.ThickCream:
               faceMaskRenderer.sprite = thickCream;
               break;
         }
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