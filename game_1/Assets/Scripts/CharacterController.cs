using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    //переменная для установки макс. скорости персонажа
    public float maxSpeed = 30f;
    //переменная для определения направления персонажа вправо/влево
    private bool isFacingRight = true;
    private Rigidbody2D rigi;
    //ссылка на компонент анимаций
    private Animator anim;


    //находится ли персонаж на земле или в прыжке?
    private bool isGrounded = false;
    //ссылка на компонент Transform объекта
    //для определения соприкосновения с землей
    public Transform groundCheck;
    //радиус определения соприкосновения с землей
    private float groundRadius = 0.2f;
    //ссылка на слой, представляющий землю
    public LayerMask whatIsGround;


    /// <summary>
    /// Начальная инициализация
    /// </summary>
    //private void Start()
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Выполняем действия в методе FixedUpdate, т. к. в компоненте Animator персонажа
    /// выставлено значение Animate Physics = true и анимация синхронизируется с расчетами физики
    /// </summary>
    private void FixedUpdate()
    {
        //используем Input.GetAxis для оси Х. метод возвращает значение оси в пределах от -1 до 1.
        //при стандартных настройках проекта 
        //-1 возвращается при нажатии на клавиатуре стрелки влево (или клавиши А),
        //1 возвращается при нажатии на клавиатуре стрелки вправо (или клавиши D)
        //if (!dead)
        //{
            float move = Input.GetAxis("Horizontal");

            //в компоненте анимаций изменяем значение параметра Speed на значение оси Х.
            //приэтом нам нужен модуль значения
            anim.SetFloat("Speed", Mathf.Abs(move));

            //обращаемся к компоненту персонажа RigidBody2D. задаем ему скорость по оси Х, 
            //равную значению оси Х умноженное на значение макс. скорости
            rigi = GetComponent<Rigidbody2D>();
            rigi.velocity = new Vector2(move * maxSpeed, rigi.velocity.y);
            //если нажали клавишу для перемещения вправо, а персонаж направлен влево
            if (move > 0 && !isFacingRight)
                //отражаем персонажа вправо
                Flip();
            //обратная ситуация. отражаем персонажа влево
            else if (move < 0 && isFacingRight)
                Flip();
        //}
    }

    /// <summary>
    /// Метод для смены направления движения персонажа и его зеркального отражения
    /// </summary>
    private void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }

    void Update()
    {
        // ...

        // 6 – Убедиться, что игрок не выходит за рамки кадра
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //        dead = true;
    //}
}
