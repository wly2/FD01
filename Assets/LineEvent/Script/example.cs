using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

public class example : MonoBehaviour {
	public Transform[] Target = new Transform[5];
	public Vector3[] TargetV3 = new Vector3[5];
	private LineRenderer lineRenderer;
	private int SmoothSens = 20;
	private int Targetlenght = 0;
	
	void Start(){
		Targetlenght = Target.Length;
	}
	
    void Update() {
		for (int i = 0; i < Targetlenght; i++)
		{
			TargetV3[i] = Target[i].position;
		}
		DrawPathHelper(TargetV3,Color.red);
	}
	
	public void DrawPathHelper(Vector3[] path, Color color){
		Targetlenght = Target.Length;
		SmoothSens = 20;
		
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetVertexCount(SmoothSens*Targetlenght+1);
		lineRenderer.SetWidth(0.001f, 0.001f);
		
		Vector3[] vector3s = PathControlPointGenerator(path);
		Vector3 prevPt = Interp(vector3s,0);
		Gizmos.color=color;
		int SmoothAmount = path.Length*SmoothSens;
		for (int i = 1; i <= SmoothAmount; i++) {
			float pm = (float) i / SmoothAmount;
			Vector3 currPt = Interp(vector3s,pm);
			lineRenderer.SetPosition(i-1, currPt);
			lineRenderer.SetPosition(i, prevPt);
			
			prevPt = currPt;
		}
	}
	
	public Vector3[] PathControlPointGenerator(Vector3[] path){
		Vector3[] suppliedPath;
		Vector3[] vector3s;
		
		//create and store path points:
		suppliedPath = path;

		//populate calculate path;
		int offset = 2;
		vector3s = new Vector3[suppliedPath.Length+offset];
		Array.Copy(suppliedPath,0,vector3s,1,suppliedPath.Length);
		
		//populate start and end control points:
		//vector3s[0] = vector3s[1] - vector3s[2];
		vector3s[0] = vector3s[1] + (vector3s[1] - vector3s[2]);
		vector3s[vector3s.Length-1] = vector3s[vector3s.Length-2] + (vector3s[vector3s.Length-2] - vector3s[vector3s.Length-3]);
		
		//is this a closed, continuous loop? yes? well then so let's make a continuous Catmull-Rom spline!
		if(vector3s[1] == vector3s[vector3s.Length-2]){
			Vector3[] tmpLoopSpline = new Vector3[vector3s.Length];
			Array.Copy(vector3s,tmpLoopSpline,vector3s.Length);
			tmpLoopSpline[0]=tmpLoopSpline[tmpLoopSpline.Length-3];
			tmpLoopSpline[tmpLoopSpline.Length-1]=tmpLoopSpline[2];
			vector3s=new Vector3[tmpLoopSpline.Length];
			Array.Copy(tmpLoopSpline,vector3s,tmpLoopSpline.Length);
		}	
		return(vector3s);
	}
	
	public Vector3 Interp(Vector3[] pts, float t){
		int numSections = pts.Length - 3;
		int currPt = Mathf.Min(Mathf.FloorToInt(t * (float) numSections), numSections - 1);
		float u = t * (float) numSections - (float) currPt;
				
		Vector3 a = pts[currPt];
		Vector3 b = pts[currPt + 1];
		Vector3 c = pts[currPt + 2];
		Vector3 d = pts[currPt + 3];
		
		return .5f * (
			(-a + 3f * b - 3f * c + d) * (u * u * u)
			+ (2f * a - 5f * b + 4f * c - d) * (u * u)
			+ (-a + c) * u
			+ 2f * b
		);
	}
}












