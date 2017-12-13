using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {
	public enum FollowType{
		MoveTowards, 
		Lerp
	}

	public FollowType Type = FollowType.MoveTowards;
	public PathDefinition path;
	public float Speed=1;
	public float MaxDistance=0.1f;
	Rigidbody2D enemyRigidBody;
	private IEnumerator<Transform> _currentPoint;

	public void Start(){
		if (path == null) {
			Debug.LogError ("Path cannot be found", gameObject);
			return;
		}
		_currentPoint = path.GetPathEnumerator ();
		_currentPoint.MoveNext ();

		if (_currentPoint.Current == null) {
			return;
		}

		transform.position = _currentPoint.Current.position;
	}

	public void Update(){
		if (_currentPoint == null || _currentPoint.Current == null) {
			return;
		}
		if (Type == FollowType.MoveTowards) {
			transform.position = Vector3.MoveTowards (transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);

		} else if (Type == FollowType.Lerp) {
			transform.position = Vector3.Lerp (transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);

		}
		var distancesquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
		if (distancesquared < MaxDistance * MaxDistance) {
			_currentPoint.MoveNext ();
		}
	
	
	}


	}

