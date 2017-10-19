using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A class that enables UI notifications from the persistent UI canvas.
/// There are 3 types of notifications with different appearances: general notifications, warnings, and errors.
/// Notifications have titles and message bodies.
/// They last on screen for a specific duration.
/// They can be closed by tapping on them.
/// Notifications are queued: They will play as soon as the previous notification closes.
/// 
/// To queue a notification, use one of:
/// Notification.instance.Log(string title, string message)
/// Notification.instance.LogWarning(string title, string message)
/// Notification.instance.LogError(string title, string message)
/// Notification.instance.Log(string title, string message, float duration)
/// Notification.instance.LogWarning(string title, string message, float duration)
/// Notification.instance.LogError(string title, string message, float duration)
/// 
/// See also: Popup
/// </summary>

namespace ReGameVR {
    namespace UI {
        public class Notification : MonoBehaviour {

#pragma warning disable 0649
            [SerializeField]
            private Text titleText;
            [SerializeField]
            private Text messageText;
            [SerializeField]
            private Animator anim;
            [SerializeField]
            private AnimationClip open;
            [SerializeField]
            private AnimationClip close;
            [SerializeField]
            private Image sideBar, titleBar, circle;
            [SerializeField]
            private Text circleText;
            [SerializeField]
            private Color infoColor, warningColor, errorColor, lightSymbol, darkSymbol;
#pragma warning restore 0649

            private static Queue<string> titles, messages;
            private static Queue<Type> types;
            private static Queue<float> durations;
            private static bool messageDisplayed;

            public static Notification instance;
            public static float defaultDuration;

            enum Type { INFO, WARNING, ERROR };

            private void Awake() {
                DontDestroyOnLoad(this);
                instance = this;
            }

            private void Start() {
                defaultDuration = 4f;
                messageDisplayed = false;
                titles = new Queue<string>();
                messages = new Queue<string>();
                types = new Queue<Type>();
                durations = new Queue<float>();
            }

            // If there are messages queued and no message displayed, display the next message
            private void Update() {
                if (!messageDisplayed && messages.Count > 0) {
                    processNext();
                }


                /*
                
                // Uncomment this section to see example notifications

                if (Input.GetKeyDown(KeyCode.E)) {
                    LogError("This is an Error notification:", "Here is the body text.");
                }
                if (Input.GetKeyDown(KeyCode.W)) {
                    LogWarning("This is a Warning notification:", "Here is the body text.");
                }
                if (Input.GetKeyDown(KeyCode.I)) {
                    Log("This is a general info notification:", "Here is the body text.");
                }
                */
                
            }

            /// <summary>
            /// Queues a general notification with the given title and the given message. Uses the default duration.
            /// </summary>
            /// <param name="title"> The title of the notification to be displayed. </param>
            /// <param name="message"> The body of the notification to be displayed. </param>
            public void Log(string title, string message) {
                Log(title, message, defaultDuration);
            }

            /// <summary>
            /// Queues a warning notification with the given title and the given message. Uses the default duration.
            /// </summary>
            /// <param name="title"> The title of the notification to be displayed. </param>
            /// <param name="message"> The body of the notification to be displayed. </param>
            public void LogWarning(string title, string message) {
                LogWarning(title, message, defaultDuration);
            }

            /// <summary>
            /// Queues an error notification with the given title and the given message. Uses the default duration.
            /// </summary>
            /// <param name="title"> The title of the notification to be displayed. </param>
            /// <param name="message"> The body of the notification to be displayed. </param>
            public void LogError(string title, string message) {
                LogError(title, message, defaultDuration);
            }

            /// <summary>
            /// Queues a general notification with the given title and the given message that will last the given duration (in seconds).
            /// </summary>
            /// <param name="title"> The title of the notification to be displayed. </param>
            /// <param name="message"> The body of the notification to be displayed. </param>
            /// <param name="duration"> The duration the notification will last before closing. </param>
            public void Log(string title, string message, float duration) {
                titles.Enqueue(title);
                messages.Enqueue(message);
                durations.Enqueue(duration);
                types.Enqueue(Type.INFO);
            }

            /// <summary>
            /// Queues a warning notification with the given title and the given message that will last the given duration (in seconds).
            /// </summary>
            /// <param name="title"> The title of the notification to be displayed. </param>
            /// <param name="message"> The body of the notification to be displayed. </param>
            /// <param name="duration"> The duration the notification will last before closing (in seconds). </param>
            public void LogWarning(string title, string message, float duration) {
                titles.Enqueue(title);
                messages.Enqueue(message);
                durations.Enqueue(duration);
                types.Enqueue(Type.WARNING);
            }

            /// <summary>
            /// Queues an error notification with the given title and the given message that will last the given duration (in seconds).
            /// </summary>
            /// <param name="title"> The title of the notification to be displayed. </param>
            /// <param name="message"> The body of the notification to be displayed. </param>
            /// <param name="duration"> The duration the notification will last before closing (in seconds). </param>
            public void LogError(string title, string message, float duration) {
                titles.Enqueue(title);
                messages.Enqueue(message);
                durations.Enqueue(duration);
                types.Enqueue(Type.ERROR);
            }

            /// <summary>
            /// Processes the next notification in the queue, removing it from the queue.
            /// </summary>
            private void processNext() {

                // Determines the appearance for the next notification based on the type.
                Color color;
                Color symbolColor;
                string symbol;
                Type type = types.Dequeue();
                if (type == Type.ERROR) {
                    color = errorColor;
                    symbolColor = lightSymbol;
                    symbol = "X";
                } else if (type == Type.INFO) {
                    color = infoColor;
                    symbolColor = darkSymbol;
                    symbol = "i";
                } else {
                    color = warningColor;
                    symbolColor = darkSymbol;
                    symbol = "!";
                }

                // Displays the notification
                display(titles.Dequeue(), messages.Dequeue(), durations.Dequeue(), color, symbol, symbolColor);
            }

            /// <summary>
            /// Displays a notification on screen with the given title and given message which will last for the given duration (in seconds).
            /// </summary>
            /// <param name="title"> The title of the notification to be displayed. </param>
            /// <param name="message"> The body of the notification to be displayed. </param>
            /// <param name="duration"> The duration the notification will last before closing (in seconds). </param>
            private void display(string title, string message, float duration) {
                titleText.text = title;
                messageText.text = message;
                anim.Play("open");
                duration = Mathf.Clamp(duration, open.length, float.MaxValue);
                messageDisplayed = true;
                StartCoroutine(Close(duration));
            }

            /// <summary>
            /// Displays a notification on screen with the given parameters.
            /// </summary>
            /// <param name="title"> The title of the notification to be displayed. </param>
            /// <param name="message"> The body of the notification to be displayed. </param>
            /// <param name="duration"> The duration the notification will last before closing (in seconds). </param>
            /// <param name="color"> The accent color of the notification. </param>
            /// <param name="circleSymbol"> The symbol to be displayed in the notification circle. </param>
            /// <param name="symbolColor"> The color of the symbol to be displayed in the notification circle. </param>
            private void display(string title, string message, float duration, Color color, string circleSymbol, Color symbolColor) {
                setColor(color);
                circleText.text = circleSymbol;
                circleText.color = symbolColor;
                display(title, message, duration);
            }

            /// <summary>
            ///  Plays the close animation after the given duration (in seconds).
            /// </summary>
            /// <param name="duration"> The duration of the notification until it closes (in seconds). </param>
            private IEnumerator Close(float duration) {
                yield return new WaitForSeconds(duration);
                anim.Play("close");
                StartCoroutine(Closed());
            }

            /// <summary>
            /// When the closing animation finsihes, sets messageDisplayed to false.
            /// </summary>
            private IEnumerator Closed() {
                yield return new WaitForSeconds(close.length);
                messageDisplayed = false;
            }

            /// <summary>
            /// Sets the colors of the relevant notification elements to the given accent color.
            /// </summary>
            /// <param name="color"></param>
            private void setColor(Color color) {
                sideBar.color = color;
                titleText.color = color;
                titleBar.color = color;
                circle.color = color;
            }

            /// <summary>
            /// Forces the notification to close by stopping all coroutines, playing the closing animation, and starting the Closed coroutine. 
            /// To be used on notification click.
            /// </summary>
            public void Close() {
                StopAllCoroutines();
                anim.Play("close");
                StartCoroutine(Closed());
            }
        }
    }
}