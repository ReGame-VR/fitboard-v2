using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A class that enables UI popups from the persistent UI canvas.
/// Popups have titles and message bodies.
/// They last on screen until closed.
/// They can be closed by tapping on them.
/// To trigger a popup, use Popup.instance.DisplayPopup(string title, string message)
/// 
/// See also: Notification
/// </summary>

namespace ReGameVR {
    namespace UI {
        public class Popup : MonoBehaviour {

#pragma warning disable 0649
            [SerializeField]
            private Text titleText, messageText, circleText;
            [SerializeField]
            private Animator anim;
            [SerializeField]
            private Image sideBar1, sideBar2, titleBar, circle, background;
            [SerializeField]
            private Color darkColor, lightColor, accentColor;
            [SerializeField]
            private RectTransform layout;
            [SerializeField]
            private Image image;
            private LayoutElement imageLayout;
#pragma warning restore 0649

            public static Popup instance;

            private void Awake() {
                DontDestroyOnLoad(this);
                instance = this;
            }

            private void Start() {
                setColor(accentColor, darkColor, darkColor);
                imageLayout = image.GetComponent<LayoutElement>();
            }

            private void Update() {

                
                /*
                // Uncomment this to see an example popup.

                if (Input.GetKeyDown(KeyCode.P)) {
                    DisplayPopup("This is an example popup.", "Here is the body text.");
                }
                */
                
            }

            /// <summary>
            /// Displays the popup with the given title and message. Forces a layout rebuild on the popup.
            /// </summary>
            /// <param name="title"> The title of the popup. </param>
            /// <param name="message"> The body of the popup. </param>
            public void DisplayPopup(string title, string message) {
                imageLayout.preferredHeight = 0;
                setPopupText(title, message);
            }

            /// <summary>
            /// Displays the popup with the given title, message, and image. Forces a layout rebuild on the popup.
            /// </summary>
            /// <param name="title"> The title of the popup. </param>
            /// <param name="message"> The body of the popup. </param>
            /// <param name="img"> The image accompanying the popup. </param>
            public void DisplayPopup(string title, string message, Sprite img) {
                imageLayout.preferredHeight = (imageLayout.preferredWidth * img.bounds.size.y) / img.bounds.size.x;
                image.sprite = img;
                setPopupText(title, message);
            }

            // Sets the text of the popup to the given text, opens the popup, rebuilds the layout.
            private void setPopupText(string title, string message) {
                titleText.text = title;
                messageText.text = message;
                anim.Play("open");
                LayoutRebuilder.ForceRebuildLayoutImmediate(layout);
            }

            /// <summary>
            /// Closes the popup by playing the closing animation. To be used on click.
            /// </summary>
            public void Close() {
                anim.Play("close");
            }

            /// <summary>
            /// Sets the relevant popup elements to their respective given colors.
            /// </summary>
            /// <param name="accentColor"> The color of the sidebars, title text, title bar, and X circle. </param>
            /// <param name="bgColor"> The background color. </param>
            /// <param name="symbolColor"> The X color. </param>
            private void setColor(Color accentColor, Color bgColor, Color symbolColor) {
                sideBar1.color = accentColor;
                sideBar2.color = accentColor;
                titleText.color = accentColor;
                titleBar.color = accentColor;
                circle.color = accentColor;
                background.color = bgColor;
                circleText.color = symbolColor;
            }
        }
    }
}