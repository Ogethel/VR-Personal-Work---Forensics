using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[CreateAssetMenu]

public class Buttons : ScriptableObject
{
   public string keyBoard;

   public void Words(string Character)
   {
      keyBoard += Character; 


   }

   public void ClearString()
   {
      keyBoard = "";
   }

}
