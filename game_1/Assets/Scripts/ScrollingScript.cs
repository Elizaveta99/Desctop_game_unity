//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//namespace RendererExtensions
//{
//    public class ScrollingScript : MonoBehaviour
//    {



//        /* public float scrollSpeed;
//         public float tileSizeZ;

//         private Vector3 startPosition;

//         void Start()
//         {
//             startPosition = transform.position;
//         }

//         void Update()
//         {
//             float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
//             transform.position = startPosition + Vector3.forward * newPosition;
//         }*/

//        /*  public Vector2 speed = new Vector2(2, 2);

//        // Направление движения
//        public Vector2 direction = new Vector2(-1, 0);

//        // Движения должны быть применены к камере
//        public bool isLinkedToCamera = false;

//        void Update()
//        {
//          // Перемещение
//          Vector3 movement = new Vector3(
//            speed.x * direction.x,
//            speed.y * direction.y,
//            0);

//          movement *= Time.deltaTime;
//          transform.Translate(movement);

//          // Перемещение камеры
//          if (isLinkedToCamera)
//          {
//            Camera.main.transform.Translate(movement);
//          }
//        }*/


//        //using RendererExtensions;
//        // Скорость прокрутки
//        public Vector2 speed = new Vector2(10, 10);

//        // Направление движения
//        public Vector2 direction = new Vector2(-1, 0);

//        // Движения должны быть применены к камере
//        public bool isLinkedToCamera = false;

//        // 1 – Бесконечный фон
//        public bool isLooping = false;

//        // 2 – Список детей с рендерером
//        private List<Transform> backgroundPart;

//        // 3 - Получаем всех детишек))
//        void Start()
//        {
//            // Только для безконечного фона
//            if (isLooping)
//            {
//                // Задействовать всех детей слоя с рендерером
//                backgroundPart = new List<Transform>();

//                for (int i = 0; i < transform.childCount; i++)
//                {
//                    Transform child = transform.GetChild(i);
//                    // Добавить только видимых детей
//                    if (child.GetComponent<Renderer>() != null)
//                    {
//                        backgroundPart.Add(child);
//                    }
//                }

//                // Сортировка по позиции.
//                // Примечание: получаем детей слева направо.
//                // Мы должны добавить несколько условий для обработки
//                // разных направлений прокрутки.
//                backgroundPart = backgroundPart.OrderBy(
//                  t => t.position.x
//                ).ToList();
//            }
//        }

//        void Update()
//        {
//            // Перемещение
//            Vector3 movement = new Vector3(
//              speed.x * direction.x,
//              speed.y * direction.y,
//              0);

//            movement *= Time.deltaTime;
//            transform.Translate(movement);

//            // Перемещение камеры
//            if (isLinkedToCamera)
//            {
//                Camera.main.transform.Translate(movement);
//            }

//            // 4 - Loop
//            if (isLooping)
//            {
//                // Получение первого объекта.
//                // Список упорядочен слева (позиция по оси X) направо.
//                Transform firstChild = backgroundPart.FirstOrDefault();

//                if (firstChild != null)
//                {
//                    // Проверить, находится ли ребенок (частично) перед камерой.
//                    // Первым делом мы тестируем позицию, т.к. метод IsVisibleFrom
//                    // немного сложнее воплотить в жизнь
//                    if (firstChild.position.x < Camera.main.transform.position.x)
//                    {
//                        // Если ребенок уже слева от камеры,
//                        // мы проверяем, покинул ли он область кадра, чтобы использовать его
//                        // повторно.
//                        if (firstChild.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
//                        {
//                            // Получить последнюю позицию ребенка.
//                            Transform lastChild = backgroundPart.LastOrDefault();
//                            Vector3 lastPosition = lastChild.transform.position;
//                            Vector3 lastSize = (lastChild.GetComponent<Renderer>().bounds.max - lastChild.GetComponent<Renderer>().bounds.min);

//                            // Переместить повторно используемый объект так, чтобы он располагался ПОСЛЕ
//                            // последнего ребенка
//                            // Примечание: Пока работает только для горизонтального скроллинга.
//                            firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z);

//                            // Поставить повторно используемый объект
//                            // в конец списка backgroundPart.
//                            backgroundPart.Remove(firstChild);
//                            backgroundPart.Add(firstChild);
//                        }
//                    }
//                }
//            }
//        }


//    }

//}




using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RendererExtensions
{

    /// <summary>
    /// Parallax scrolling script that should be assigned to a layer
    ///
    /// This is related to the tutorial http://pixelnest.io/tutorials/2d-game-unity/parallax-scrolling/
    ///
    /// See the result: http://pixelnest.io/tutorials/2d-game-unity/parallax-scrolling/-img/multidir_scrolling.gif
    /// </summary>
    public class ScrollingScript : MonoBehaviour
    {
        /// <summary>
        /// Scrolling speed
        /// </summary>
        public Vector2 speed = new Vector2(10, 10);

        /// <summary>
        /// Moving direction
        /// </summary>
        public Vector2 direction = new Vector2(-1, 0);

        /// <summary>
        /// Movement should be applied to camera
        /// </summary>
        public bool isLinkedToCamera = false;

        /// <summary>
        /// Background is inifnite
        /// </summary>
        public bool isLooping = false;

        private List<Transform> backgroundPart;
        private Vector2 repeatableSize;

        void Start()
        {
            // For infinite background only
            if (isLooping)
            {
                //---------------------------------------------------------------------------------
                // 1 - Retrieve background objects
                // -- We need to know what this background is made of
                // -- Store a reference of each object
                // -- Order those items in the order of the scrolling, so we know the item that will be the first to be recycled
                // -- Compute the relative position between each part before they start moving
                //---------------------------------------------------------------------------------

                // Get all part of the layer
                backgroundPart = new List<Transform>();

                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform child = transform.GetChild(i);

                    // Only visible children
                    if (child.GetComponent<Renderer>() != null)
                    {
                        backgroundPart.Add(child);
                    }
                }

                if (backgroundPart.Count == 0)
                {
                    Debug.LogError("Nothing to scroll!");
                }

                // Sort by position 
                // -- Depends on the scrolling direction
                backgroundPart = backgroundPart.OrderBy(t => t.position.x * (-1 * direction.x)).ThenBy(t => t.position.y * (-1 * direction.y)).ToList();

                // Get the size of the repeatable parts
                var first = backgroundPart.First();
                var last = backgroundPart.Last();

                repeatableSize = new Vector2(
                  Mathf.Abs(last.position.x - first.position.x),
                  Mathf.Abs(last.position.y - first.position.y)
                  );
            }
        }

        void Update()
        {
            // Movement
            Vector3 movement = new Vector3(
              speed.x * direction.x,
              speed.y * direction.y,
              0);

            movement *= Time.deltaTime;
            transform.Translate(movement);

            // Move the camera
            if (isLinkedToCamera)
            {
                Camera.main.transform.Translate(movement);
            }

            // Loop
            if (isLooping)
            {
                //---------------------------------------------------------------------------------
                // 2 - Check if the object is before, in or after the camera bounds
                //---------------------------------------------------------------------------------

                // Camera borders
                var dist = (transform.position - Camera.main.transform.position).z;
                float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
                float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
                float width = Mathf.Abs(rightBorder - leftBorder);
                var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
                var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
                float height = Mathf.Abs(topBorder - bottomBorder);

                // Determine entry and exit border using direction
                Vector3 exitBorder = Vector3.zero;
                Vector3 entryBorder = Vector3.zero;

                if (direction.x < 0)
                {
                    exitBorder.x = leftBorder;
                    entryBorder.x = rightBorder;
                }
                else if (direction.x > 0)
                {
                    exitBorder.x = rightBorder;
                    entryBorder.x = leftBorder;
                }

                if (direction.y < 0)
                {
                    exitBorder.y = bottomBorder;
                    entryBorder.y = topBorder;
                }
                else if (direction.y > 0)
                {
                    exitBorder.y = topBorder;
                    entryBorder.y = bottomBorder;
                }

                // Get the first object
                Transform firstChild = backgroundPart.FirstOrDefault();

                if (firstChild != null)
                {
                    bool checkVisible = false;

                    // Check if we are after the camera
                    // The check is on the position first as IsVisibleFrom is a heavy method
                    // Here again, we check the border depending on the direction
                    if (direction.x != 0)
                    {
                        if ((direction.x < 0 && (firstChild.position.x < exitBorder.x))
                        || (direction.x > 0 && (firstChild.position.x > exitBorder.x)))
                        {
                            checkVisible = true;
                        }
                    }
                    if (direction.y != 0)
                    {
                        if ((direction.y < 0 && (firstChild.position.y < exitBorder.y))
                        || (direction.y > 0 && (firstChild.position.y > exitBorder.y)))
                        {
                            checkVisible = true;
                        }
                    }

                    // Check if the sprite is really visible on the camera or not
                    if (checkVisible)
                    {
                        //---------------------------------------------------------------------------------
                        // 3 - The object was in the camera bounds but isn't anymore.
                        // -- We need to recycle it
                        // -- That means he was the first, he's now the last
                        // -- And we physically moves him to the further position possible
                        //---------------------------------------------------------------------------------

                        if (firstChild.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
                        {
                            // Set position in the end
                            firstChild.position = new Vector3(
                              firstChild.position.x + ((repeatableSize.x + firstChild.GetComponent<Renderer>().bounds.size.x) * -1 * direction.x),
                              firstChild.position.y + ((repeatableSize.y + firstChild.GetComponent<Renderer>().bounds.size.y) * -1 * direction.y),
                              firstChild.position.z
                              );

                            // The first part become the last one
                            backgroundPart.Remove(firstChild);
                            backgroundPart.Add(firstChild);
                        }
                    }
                }

            }
        }
    }

}
