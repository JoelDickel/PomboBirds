using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag2 : MonoBehaviour
{
    private Collider2D drag;
    public LayerMask layer;
    [SerializeField]
    private bool cliked;
    private Touch touch;

    public LineRenderer lineFront;
    public LineRenderer lineBack;

    //para o elastico ir até o final do pássaro
    private Ray leftCatapultRay;
    private CircleCollider2D passaroCol;
    private Vector2 catapultToBird;
    private Vector3 pointL;


    //joint-efeito mola
    private SpringJoint2D spring;
    private Vector2 prevVel;
    private Rigidbody2D passaroRB;

    //efeito morte
    public GameObject bomb;

    //elastico limite
    private Transform catapult;
    private Ray rayToMT;

    //rastro
    private TrailRenderer rastro;

    void Start()
    {
        drag = GetComponent<Collider2D>();
        SetUpLine();
        
        leftCatapultRay = new Ray(lineFront.transform.position, Vector3.zero);
        passaroCol = GetComponent<CircleCollider2D>();
        spring = GetComponent<SpringJoint2D>();
        passaroRB = GetComponent<Rigidbody2D>();

        catapult = spring.connectedBody.transform;
        rayToMT = new Ray(catapult.position, Vector3.zero);

        rastro = GetComponentInChildren<TrailRenderer>();
    }

    void Update()
    {
        LineUpdate();
        SpringEfect();
        prevVel = passaroRB.velocity;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(wp, Vector2.zero, Mathf.Infinity, layer.value);

            if(hit.collider != null)
            {
                cliked = true;
            }
            if (cliked)
            {
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {

                    Vector3 tPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                    rastro.enabled = false;
                    catapultToBird = tPos - catapult.position;

                    if(catapultToBird.sqrMagnitude > 9f)
                    {
                        rayToMT.direction = catapultToBird;
                        tPos = rayToMT.GetPoint(3f);
                    }
                    
                    transform.position = tPos;
                    
                }
            }

            if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                rastro.enabled = true;
                passaroRB.isKinematic = false;
                cliked = false;
                MataPassaro();
            }

        }
    }

    void SetUpLine()
    {
        lineFront.SetPosition(0, lineFront.transform.position);
        lineBack.SetPosition(0, lineBack.transform.position);
    }

    void LineUpdate()
    {

        catapultToBird = transform.position - lineFront.transform.position;
        leftCatapultRay.direction = catapultToBird;

        pointL = leftCatapultRay.GetPoint(catapultToBird.magnitude + passaroCol.radius);

        lineFront.SetPosition(1, pointL);
        lineBack.SetPosition(1, pointL);
    }

    void SpringEfect()
    {
        if(spring != null)
        {
            if(passaroRB.isKinematic == false)
            {
                if(prevVel.sqrMagnitude > passaroRB.velocity.sqrMagnitude)
                {
                    lineBack.enabled = false;
                    lineFront.enabled = false;
                    Destroy(spring);
                    passaroRB.velocity = prevVel;
                }
            }
        }
    }

    void MataPassaro()
    {
        if (passaroRB.velocity.magnitude == 0 && passaroRB.IsSleeping())
        {
            StartCoroutine(TempoMorte());
        }

    }
    IEnumerator TempoMorte()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(bomb, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        Destroy(gameObject);
    }


}
