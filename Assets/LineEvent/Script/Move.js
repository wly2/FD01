#pragma strict
private var offset : Vector3 ;
private var screenSpace :Vector3;
private var curScreenSpace : Vector3;
private var curPosition : Vector3;
private var hit : RaycastHit;
private var ray : Ray;

function Start () {

}

function Update () {
	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	if (Input.GetMouseButtonDown(0)){
		if(Physics.Raycast(ray,hit ,1200)){
			Mousemove(hit.collider.gameObject);
		}
	}
}

function Mousemove(obj : GameObject){
	screenSpace = Camera.main.WorldToScreenPoint(obj.transform.position);//世界转屏幕
	offset = obj.transform.position - Camera.main.ScreenToWorldPoint(Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
	while (Input.GetMouseButton(0)){
		curScreenSpace= Vector3(Input.mousePosition.x,Input.mousePosition.y,screenSpace.z);
		curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
		obj.transform.position = curPosition;
		yield;
	}
}


