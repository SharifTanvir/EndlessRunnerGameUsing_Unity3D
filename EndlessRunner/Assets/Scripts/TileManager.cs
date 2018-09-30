using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {


	public GameObject[] tilePre;
	public GameObject currentTile;

	private static TileManager instance; 

	private Stack<GameObject> leftTiles = new Stack<GameObject>();
	public Stack<GameObject> LeftTiles{
		get{ return leftTiles;}
		set{ leftTiles = value;}
	}

	private Stack<GameObject> topTiles = new Stack<GameObject>();
	public Stack<GameObject> TopTiles{
		get{ return topTiles;}
		set{ topTiles = value;}
	}

	public static TileManager Instance{
		get{

			if (instance == null) {
				instance = GameObject.FindObjectOfType<TileManager> ();
			}

			return instance; 
		
		}

	}

	// Use this for initialization
	void Start () {

		CreatTiles (20);

		for (int i = 0; i < 10; i++) {
			
			SpawnTile ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void CreatTiles(int amount){
		for (int i = 0; i < amount; i++) {

			leftTiles.Push (Instantiate (tilePre [0]));
			topTiles.Push (Instantiate (tilePre [1]));
			topTiles.Peek ().name = "TopTile";
			topTiles.Peek ().SetActive (false);
			leftTiles.Peek ().name = "LeftTile";
			leftTiles.Peek ().SetActive (false);
		}

	}

	public void SpawnTile(){


		if(leftTiles.Count == 0 || topTiles.Count ==0){
			CreatTiles (10);
		}

		int randomIndex = Random.Range(0,2);

		if(randomIndex==0){
			GameObject temp = leftTiles.Pop ();
			temp.SetActive (true);
			temp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
			currentTile = temp;
		}
		else if (randomIndex==1){
			GameObject temp = topTiles.Pop ();
			temp.SetActive (true);
			temp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
			currentTile = temp;
		}
		int spawnPickup = Random.Range (0,10);
		if(spawnPickup==0){
			currentTile.transform.GetChild (1).gameObject.SetActive (true);
		}

		//currentTile= (GameObject) Instantiate (tilePre[randomIndex],currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position, Quaternion.identity);
	}

	public void ResetGame(){
		Application.LoadLevel (Application.loadedLevel);
	}
}
