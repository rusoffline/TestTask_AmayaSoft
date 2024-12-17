using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SpritePreviewAttribute))]
public class SpritePreviewDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (property.objectReferenceValue != null)
        {
            return EditorGUIUtility.singleLineHeight + 70; 
        }
        return EditorGUIUtility.singleLineHeight; 
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect fieldRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(fieldRect, property, label);

        if (property.objectReferenceValue is Sprite sprite)
        {
            Rect spriteRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 5, 60, 60);
            DrawSpritePreview(sprite, spriteRect);
        }
    }

    private void DrawSpritePreview(Sprite sprite, Rect rect)
    {
        Texture2D texture = sprite.texture;

        Rect spriteRect = sprite.rect; 
        Rect uv = new Rect(
            spriteRect.x / texture.width,
            spriteRect.y / texture.height,
            spriteRect.width / texture.width,
            spriteRect.height / texture.height
        );

        GUI.DrawTextureWithTexCoords(rect, texture, uv);
    }
}
