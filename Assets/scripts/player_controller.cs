using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour{
#region Inspector Variables    
    [Header("Movement")]
    [SerializeField][Range(10.0f, 100.0f)] float Speed=10.0f;
    
    [SerializeField]string AxisHorizontal="Horizontal", AxisVertical="Vertical";
    public Camera m_CameraTwo;
#endregion
#region Private Variables
    CharacterController _Character;
    float _MovX,_MovY;
    Vector3 PlayerInput;
    Vector3 _CamDirectionF,_CamDirectionR;
#endregion
#region  Unity Voids
    void Awake() => _Character= GetComponent<CharacterController>();
    void Update(){
    _MovX=Input.GetAxis(AxisHorizontal);
    _MovY= Input.GetAxis(AxisVertical);
    camDirection();
    Movement(_MovX, _MovY);
    }
#endregion     
#region Creates Voids    
    void Movement(float H, float V){
        PlayerInput= new Vector3(H, 0, V);
        PlayerInput = Vector3.ClampMagnitude(PlayerInput, 1);
        Vector3 CamCorrect= PlayerInput.x * _CamDirectionF + PlayerInput.z *_CamDirectionR;
        _Character.transform.LookAt(_Character.transform.position+ CamCorrect);
        _Character.Move((CamCorrect* Speed )*Time.deltaTime); 
    }
void camDirection(){
_CamDirectionF=m_CameraTwo.transform.forward;
_CamDirectionR=m_CameraTwo.transform.right;
_CamDirectionR.y=0;
_CamDirectionF.y=0;
_CamDirectionF=_CamDirectionF.normalized;
_CamDirectionR=_CamDirectionR.normalized;
}

#endregion
}

