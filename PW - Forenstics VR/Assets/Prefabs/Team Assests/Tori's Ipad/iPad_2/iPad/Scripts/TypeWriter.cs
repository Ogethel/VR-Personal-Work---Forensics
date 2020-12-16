using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour {

 string word = null;
 int wordIndex = 0;
 string alpha;
 public TextMeshPro myName = null;
 // Use this for initialization

 public void alphabetFunction (string alphabet)
 {
  wordIndex++;
  word = word + alphabet;
  myName.text = word;
 }
}