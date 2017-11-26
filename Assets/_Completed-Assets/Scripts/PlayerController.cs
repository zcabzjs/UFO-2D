using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	private int count;
	public Text scoreText;
	public Text victoryText;

	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		count = 0;
		ScoreText ();
		victoryText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive (false);
			count++;
			ScoreText ();
		}
		if (count >= 12) {
			victoryText.text = "VI VON!!!!!";
		}
	}

	void ScoreText(){
		scoreText.text = "Score:" + count.ToString ();
	}
		
}
