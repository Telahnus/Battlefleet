using UnityEngine;
using System.Collections;

public class GenMoveGrid : MonoBehaviour {
	
	//Attributes
	public float tileSize;
	public int speed;
	
	void Start () {
		
		ProcMesh mesh = new ProcMesh(); //create a procedural mesh
		
		for (int z = 2; z <= speed; z++){
			float zOffset= (tileSize * z) - tileSize/2;
			for (int x = -speed ; x <= speed; x++){
				float xOffset = (tileSize * x) - tileSize/2;

				//grid border rules
				bool upper = Mathf.Abs (x)+z <= speed;
				bool lower = Mathf.Abs (x)+z > speed/4;
				bool diag = Mathf.Abs (x) <= z;

				if (upper&lower&diag){
					Vector3 offset = new Vector3(xOffset, 0, zOffset);
					mesh.BuildTile (tileSize,offset); //create a tile
				}
			}
		}
		
		MeshFilter filter = GetComponent<MeshFilter>(); //cache the mesh
		if (filter != null){
			filter.sharedMesh = mesh.CreateMesh(); //create and apply the mesh
		}
		

		//sets the materials shader type as a transparent green
		Shader tran = Shader.Find ("Transparent/Diffuse");
		this.renderer.material.shader = tran;
		this.renderer.material.color = new Color (0,255,0,0.1f);
	}
}