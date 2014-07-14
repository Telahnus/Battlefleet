using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This class procedural generates a single mesh
public class ProcMesh {

	//Attributes
	private List<Vector3> Vertices = new List<Vector3>();
	private List<Vector3> Normals = new List<Vector3>();
	private List<Vector2> UVs = new List<Vector2>();
	private List<int> Indices = new List<int>();
	
	//Adds triangles when building mesh
	public void AddTriangle(int index0, int index1, int index2){
		Indices.Add(index0);
		Indices.Add(index1);
		Indices.Add(index2);
	}

	//Creates a single tile of size X at position Y
	public void BuildTile(float tileSize, Vector3 offset)
	{
		Vertices.Add(new Vector3(0.0f, 0.0f, 0.0f) + offset);
		UVs.Add(new Vector2(0.0f, 0.0f));
		Normals.Add(Vector3.up);
		
		Vertices.Add(new Vector3(0.0f, 0.0f, tileSize) + offset);
		UVs.Add(new Vector2(0.0f, 1.0f));
		Normals.Add(Vector3.up);
		
		Vertices.Add(new Vector3(tileSize, 0.0f, tileSize) + offset);
		UVs.Add(new Vector2(1.0f, 1.0f));
		Normals.Add(Vector3.up);
		
		Vertices.Add(new Vector3(tileSize, 0.0f, 0.0f) + offset);
		UVs.Add(new Vector2(1.0f, 0.0f));
		Normals.Add(Vector3.up);
		
		int baseIndex = Vertices.Count - 4;
		
		AddTriangle(baseIndex, baseIndex + 1, baseIndex + 2);
		AddTriangle(baseIndex, baseIndex + 2, baseIndex + 3);
	}

	//Creates mesh from list data
	public Mesh CreateMesh(){
		
		Mesh mesh = new Mesh();
		
		mesh.vertices = Vertices.ToArray();
		mesh.triangles = Indices.ToArray();
		
		//Normals are optional. Only use them if we have the correct amount:
		if (Normals.Count == Vertices.Count)
			mesh.normals = Normals.ToArray();
		
		//UVs are optional. Only use them if we have the correct amount:
		if (UVs.Count == Vertices.Count)
			mesh.uv = UVs.ToArray();
		
		mesh.RecalculateBounds();
		
		return mesh;
	}
}
