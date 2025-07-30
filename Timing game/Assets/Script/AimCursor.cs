using UnityEngine;
using UnityEngine.UI;

public class AIMCursor : MonoBehaviour
{
    public RectTransform cursorImage; // AIMカーソルのUIオブジェクト

    void Start()
    {
        Cursor.visible = false; // デフォルトのマウスカーソルを非表示
    }

    void Update()
    {
        // マウス位置を取得してAIMカーソルのUIを移動
        Vector2 mousePosition = Input.mousePosition;
        cursorImage.position = mousePosition;
    }
}
