using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EdgeCollider2D))]
public class CollisionFixer : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("Fix collision")) {
            var collider = target as EdgeCollider2D;
            var points = collider.points;
            Array.Resize(ref points, 100);
            Debug.Log(points.Length);
            var newpoints = new Vector2[points.Length];
            for (int i = points.Length - 1; i > 0; i--) {
                var prevpoint = points[i - 1];
                var diff = points[i] - prevpoint;
                var normal = Vector2.Perpendicular(diff);
                newpoints.Append(points[i] + normal);
            }
            for (int i = 0; i < newpoints.Length; i++) {
                points[points.Length + i] = newpoints[i];
            }

            Debug.Log(points.Length);

            collider.points = points;
        }
    }
}