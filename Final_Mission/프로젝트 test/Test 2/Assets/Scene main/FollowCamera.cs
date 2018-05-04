using UnityEngine;
using System.Collections
;
// 2017 10 07 - Y축 좌표한계 조정
// 카메라 Y한계 삭제시에 지형이랑 캐릭터 충돌 때문에 계속 충돌 판정됨 (fix)

public class FollowCamera : MonoBehaviour {
	public float distance = -5.0f;
	public float horizontalAngle = 0.0f;
	public float rotAngle = 180.0f; 
	public float verticalAngle = 10.0f;
	public Transform lookTarget;
	public Vector3 offset = Vector3.zero;

	public float xangle = 15.0f;
	public float yangle = 15.0f;
	public float rotationY = 0.0f;
	public float rotationX = 0.0f;


	// Update is called once per frame
	void LateUpdate () {
		rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * xangle;
		rotationY += Input.GetAxis ("Mouse Y") * yangle;
		//Y축 한계 설정
		rotationY = Mathf.Clamp (rotationY, -60.0f, 80.0f);

		transform.localEulerAngles = new Vector3 (-rotationY, rotationX,0 );



		
		// 카메라의 위치와 회전각을 갱신한다.
		if (lookTarget != null) {
			//바라볼 위치
			Vector3 lookPosition = lookTarget.position + offset;
			//실제 카메라가 있을 위치
			Vector3 relativePos = Quaternion.Euler(verticalAngle,horizontalAngle,0)*  new Vector3(0,0,0);
																						//카메라 보정 위치 -> 0,0,0 플레리어 위치
			// 주시 대상의 위치에 오프셋을 더한 위치로 이동시킨다.
			transform.position = lookPosition + relativePos ;
			transform.LookAt(lookPosition);
			
			// 장애물을 피한다.
			RaycastHit hitInfo;
			if (Physics.Linecast(lookPosition,transform.position,out hitInfo,1<<LayerMask.NameToLayer("Ground")))
				transform.position = hitInfo.point;
		}
	}
}
