using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
   public int points;
   public Text pointsText;

   void Update()
   {
      pointsText.text = ("Score: "+ points);

      if (points > PlayerPrefs.GetInt("HighScore",0))
      {
         PlayerPrefs.SetInt("HighScore", points);
      }

      if ((points >= 0) && (points <100))
         moving.timeScore = 1.8f;
           
      else if ((points >= 100) && (points <500))
         moving.timeScore = 1.6f;

      else if ((points >= 500) && (points <1000))
         moving.timeScore = 1.4f;

      else if ((points >= 1000) && (points <2000))
         moving.timeScore = 1.2f;

      else if ((points >= 2000) && (points <4000))
         moving.timeScore = 1.2f;

      else if (points >= 4000) 
         moving.timeScore = 1f;
           
   }
}
