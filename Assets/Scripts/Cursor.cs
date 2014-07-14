using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

	public float tileSize;
	Vector3 currentTileCoord;
	GameObject cursor;
	GameObject selected;
	GameObject player;
	float moveSpeed = 1;
	float destDist;

	void Start(){
		cursor = GameObject.Find ("Cursor");
		selected = GameObject.Find ("SelectedTile");
		//selected.renderer.material.SetColor ("_Color", Color.red);
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update(){

		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		RaycastHit hitInfo;
		if( collider.Raycast( ray, out hitInfo, Mathf.Infinity ) ) {
			int x = Mathf.RoundToInt( hitInfo.point.x / tileSize);
			int z = Mathf.RoundToInt( hitInfo.point.z / tileSize);
			
			currentTileCoord.x = x*tileSize;
			currentTileCoord.z = z*tileSize;
			
			cursor.transform.position = currentTileCoord;

			if (Input.GetMouseButtonDown(0)){
				selected.transform.position = currentTileCoord;
			}

			destDist = Vector3.Distance (selected.transform.position, player.transform.position);
		}

		if (destDist>0.5f){
			player.transform.position = Vector3.MoveTowards(player.transform.position, selected.transform.position, moveSpeed);
		}
	}
}
