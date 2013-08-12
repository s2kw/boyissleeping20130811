using UnityEngine;
using System.Collections;

public class Spiner : MonoBehaviour {

  private Camera camera;
  private Status status;
  private Vector2 screenPosition;
  public GameObject particle;
  private float rotation = 10.0f;
  private bool isGround = false;
  private float impact = 10.0f;
  enum Status{
    none, spin, jump, vomit
  }
	// Use this for initialization
	void Start () {
      camera = Camera.main;
      status = Status.none;
	}
	
	// Update is called once per frame
	void Update () {
    ClickedChecker();

    switch(status){
      case Status.vomit:
        Vomitting();
        Jumping();
        Spining();
        break;
      case Status.jump:
        Jumping();
        Spining();
        break;
      case Status.spin:
        Spining();
        break;
      case Status.none:
        break;
      default:
        break;
    }
	}

  void ClickedChecker () {
    if (Input.GetButtonDown ("Fire1") ) {
      // Construct a ray from the current mouse coordinates
      Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
      RaycastHit hit = new RaycastHit();
      if ( Physics.Raycast (ray,out hit) ) {
        if( hit.rigidbody != null){
          status ++;
        }
      }
    }
  }

  void OnCollisionEnter(Collision collision){
    isGround = true;
  }
  void Jumping(){
    if(isGround){
      rigidbody.AddForce(Vector3.up * impact, ForceMode.Impulse);
      isGround = false;
    }
  }

  void Vomitting(){
    status --;
    GameObject clone = Instantiate (particle, transform.position, transform.rotation) as GameObject;
    {
      clone.transform.parent = transform;
    }
  }
  void Spining(){
    transform.Rotate(
      0f,
      rotation * Time.deltaTime * 50,
      0f,// + rotation * Time.deltaTime,
      Space.Self
      );
  }
}
