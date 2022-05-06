using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float v_x, v_z;

    public List<MyRay> rays;

    [SerializeField]
    private bool isMoving = false;
    public PlayerConfig config { get => ConfigCollector.instance.playerConfig; }

    [SerializeField]
    private bool canMove = false;
    void Update()
    {
        if (Input.GetMouseButton(0)&& canMove)
        {
            if (!isMoving)
            {
                CheckMove();
            }
        }
    }


    public void SetCanMove(bool _b)
    {
        if (_b)
            StartCoroutine(IECanMove());
        else
        {
            canMove = false;
            PlayerAudio.instance.OnCantMove();
        }
    }
    IEnumerator IECanMove()
    {
        PlayerAudio.instance.OnIdle();
        yield return new WaitForSeconds(1);
        canMove = true;
    }
    void CheckMove()
    {
        v_x = Input.GetAxis("Mouse X");
        v_z = Input.GetAxis("Mouse Y");

        if (Mathf.Abs(v_x)> Mathf.Abs(v_z))
        {
            if (v_x > 0)
                Move(rays[2]);
            if (v_x < 0)
                Move(rays[3]);
        }
        if (Mathf.Abs(v_x) < Mathf.Abs(v_z))
        {
            if (v_z > 0)
                Move(rays[0]);
            if (v_z < 0)
                Move(rays[1]);
        }
    }

    public void Move(MyRay m_ray)
    {
        if (m_ray.CheckHit()) return;
        PlayerAudio.instance.OnMoving();

        isMoving = true;

        switch (m_ray._TypeRay)
        {
            case TypeRay.top:
                transform.GetChild(0).localEulerAngles = new Vector3(0,90,0);break;
            case TypeRay.bot:
                transform.GetChild(0).localEulerAngles = new Vector3(0, -90, 0); break;
            case TypeRay.right:
                transform.GetChild(0).localEulerAngles = new Vector3(0, 180, 0); break;
            case TypeRay.left:
                transform.GetChild(0).localEulerAngles = new Vector3(0, 0, 0); break;
        }
        StartCoroutine(IEMoving(m_ray.GetTarget()));
    }
    
    IEnumerator IEMoving(Vector3 target)
    {
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, config.speed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;

        PlayerAudio.instance.OnIdle();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "grass")
        {
            if(canMove)
                PlayerAudio.instance.OnCutIce();
            GameObject eff = (GameObject)Instantiate(effect, null);
            eff.transform.position = other.transform.position;
            Destroy(other.gameObject);
        }
    }

    public GameObject effect;
}
