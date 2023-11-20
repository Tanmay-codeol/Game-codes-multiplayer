using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UnitsMovement : MonoBehaviourPunCallbacks
{
    public Vector3 TargetPosition;
    public float speed;
    public bool ReachedPoint;
    public SelectedObject so;
    public bool CanClickHex;
    public LineRenderer lineRenderer;
    private DragDrop dd;
    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        // ReachedPoint = true;
        // view=GetComponent<PhotonView>();
        // dd=GetComponent<DragDrop>();
        // so = GameObject.Find("Objects Info").GetComponent<SelectedObject>();
        // CanClickHex = true;
        // lineRenderer = gameObject.AddComponent<LineRenderer>();
        // lineRenderer.enabled = false;
        // lineRenderer.material = new Material(Shader.Find("Custom/DottedLine"));
        // lineRenderer.startColor = Color.black;
        // lineRenderer.endColor = Color.black;

        // lineRenderer.startWidth = 0.1f;
        // lineRenderer.endWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
{
    // if(view.IsMine)
    // {
    // if (!ReachedPoint)
    // {
    //     if (transform.position == TargetPosition)
    //     {
    //         ReachedPoint = true;
    //         // CanClickHex = true;
    //         lineRenderer.enabled = false;
    //         //dd.CurrentHex.GetComponent<MouseHover>().firstUnit=null;
    //         //dd.SnapToHex();

    //     }
    //     else
    //     {
    //         // CanClickHex = false;
    //         MoveToHex(TargetPosition);
            
    //         lineRenderer.enabled = true;
    //         lineRenderer.SetPositions(new Vector3[]{transform.position, TargetPosition});

    //         float dashSize = 0.1f;
    //         float gapSize = 0.1f;
    //         float dashGap = (dashSize + gapSize) * 2;
        
    //         float scale = (Time.time % dashGap) / dashGap;
    //         Vector3 startPos = Vector3.Lerp(transform.position, TargetPosition, scale);
    //         Vector3 endPos = Vector3.Lerp(transform.position, TargetPosition, scale - dashSize / dashGap);
    //         lineRenderer.SetPositions(new Vector3[] { startPos, endPos });
    //     }
    // }
// }
}


    // public void MoveToHex(Vector3 CurrentHexPos)
    // {
    //     transform.position = Vector3.MoveTowards(transform.position, CurrentHexPos, speed);
    //     GetComponent<BoxCollider>().enabled=true;
    // }

    // public void SnapToHexCentre()
    // {

    // }
}
