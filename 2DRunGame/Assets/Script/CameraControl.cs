using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    [Range(0,100)]
    public float speed = 1;
    [Header("攝影機拍攝的上下限")]
    public Vector2 limit = new Vector2(0, 0.7f);


    /// <summary>攝影機追蹤</summary>
    private void Track()
    {
        Vector3 posA = transform.position;  //攝影機
        Vector3 posB = target.position;     //目標:貓

        posB.z = -10;
        posB.y = Mathf.Clamp(posB.y, limit.x, limit.y);     //夾住

        posA = Vector3.Lerp(posA, posB, speed * Time.deltaTime);    //差值Lerp:趨近於兩點

        transform.position = posA;
    }
    //攝影機官方建議放這:延遲Updata
    private void LateUpdate()
    {
        Track();
    }
}
