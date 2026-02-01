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
      public SpriteRenderer faceMaskRenderer;
      
      [Header("Sprites")]
      public Sprite creamed;
      public Sprite thickCream;

      public Sprite[] fruitableSlices;

      [Header("Audio")] 
      public AudioClip success;
      public AudioClip nearby;
     
      

      private void Start()
      {
         preferredCream = GetComponent<Cream>();
         preferredFruitable = GetComponent<Fruitable>();
      }

      private void Update()
      {

         if (isFullyCreamed) return;
         
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



      public IEnumerator OnIsBeingCreamed()
      {
         if (isFullyCreamed) yield break;
         
         isBeingCreamed = true;
         if (Mathf.Approximately(creamCounter, 50f))
         {
            creamLevel = CreamLevel.Creamed;
         }
         else if (Mathf.Approximately(creamCounter, 70f))
         {
            creamLevel = CreamLevel.ThickCream;
         }
         
         yield return new WaitForSeconds(10f);
         isBeingCreamed = false;
         
         if (isBeingCreamed == false)
         {
            creamCounter -= 0.5f;
         }
      }

      
   }
}