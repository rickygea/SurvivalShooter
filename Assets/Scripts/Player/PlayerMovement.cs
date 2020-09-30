using UnityEngine;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement sgtplayermovement;
    public float kecepatan = 6f;
    Vector3 movement;
    public Animator anim;
    public Rigidbody rigid;
    int masklantai;
    float camraylength = 100f;

    private void Awake()
    {
        if (sgtplayermovement != null)
        {
            return;
        }
        else {
            sgtplayermovement = this;
        }
        masklantai = LayerMask.GetMask("Floor");
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Gerak(h, v);
        Belok();
        animasikan(h,v);
    }

   public void Gerak(float horizontal, float vertikal) {
        movement.Set(horizontal, 0f, vertikal);

        movement = movement.normalized * kecepatan * Time.deltaTime;
        rigid.MovePosition(transform.position + movement);
    }

    void Belok() {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;
        
        if (Physics.Raycast(camRay, out hit, camraylength, masklantai))
        {
            Vector3 playerkemouse = hit.point - transform.position;
            playerkemouse.y = 0f;
            Quaternion rotasi = Quaternion.LookRotation(playerkemouse);
            rigid.MoveRotation(rotasi);
        }
    }

   public void animasikan(float h, float v)
    {
        bool jalan = h != 0f || v != 0f;
        anim.SetBool("jalan", jalan);
    }

    public void aktifkanbuff(float cepat, float lama) {
        StartCoroutine(buff(cepat, lama));
    }

    public IEnumerator buff(float cepat, float lama) {
        kecepatan = cepat;
        yield return new WaitForSeconds(lama);
        kecepatan = 6f;
    }
}

